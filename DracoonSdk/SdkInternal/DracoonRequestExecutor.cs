using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Dracoon.Sdk.Error;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.OAuth;
using Newtonsoft.Json;
using RestSharp;

namespace Dracoon.Sdk.SdkInternal {
    internal class DracoonRequestExecutor : IRequestExecutor {
        internal enum RequestType {
            GetServerVersion, GetServerTime, GetPublicDownloadShare, GetPublicUploadShare,
            SetUserKeyPair, GetCustomerAccount, GetUserAccount, GetUserKeyPair, DeleteUserKeyPair,
            GetUserAvatar, DeleteUserAvatar, PostUserAvatar,
            GetUserProfileAttributes, PutUserProfileAttributes, DeleteUserProfileAttributes,
            GetResourcesAvatar,
            GetNodes, GetNode, PostFolder, PutFolder, PutFile, DeleteNodes,
            GetRoomEvents, GetRoomGroups, GetRoomUsers, GetRoomPending, PostRoom, PutRoom, PutRoomConfig, PutRoomGroups, PutRoomUsers, DeleteRoomGroups, DeleteRoomUsers, PutEnableRoomEncryption,
            PostDownloadToken, GetFileKey, PostUploadToken, PutCompleteUpload, PostUploadChunk,
            GetDownloadChunk, PostCopyNodes, PostMoveNodes, GetSearchNodes, GetMissingFileKeys, PostMissingFileKeys,
            PostCreateDownloadShare, DeleteDownloadShare, GetDownloadShares, PostCreateUploadShare, DeleteUploadShare,
            GetUploadShares, PostFavorite, DeleteFavorite, GetAuthenticatedPing, PostOAuthToken, PostOAuthRefresh, GetGeneralSettings, GetInfrastructureSettings, GetDefaultsSettings,
            GetAuthenticationSettings, GetAuthActiveDirectorySettings, GetAuthOpenIdIdpSettings, GetAuthRadiusSettings,
            GetRecycleBin, DeleteRecycleBin, GetPreviousVersions, GetPreviousVersion, PostRestoreNodeVersion, DeletePreviousVersions,
            GetGroups, GetGroup, GetGroupLastAdminRooms, GetGroupRoles, GetGroupUsers, PostGroup, PostGroupUsers, PutGroup, DeleteGroup, DeleteGroupUsers,
            GetUsers, GetUser, GetUserLastAdminRooms, GetUserRoles, GetUserGroups, GetUserUserAttributes, PostUser, PostUserUserAttributes, PutUser, PutUserUserAttributes, DeleteUser, DeleteUserUserAttribute,
            GetRoles, GetRoleGroups, GetRoleUsers, PostRoleGroups, PostRoleUsers, DeleteRoleGroups, DeleteRoleUsers,
            GetAuditNodes, GetEvents, GetOperations,
            PutCompleteS3Upload, PutUploadS3Chunk, PostGetS3Urls, GetS3Status, GetPasswordPolicies,
            GetBranding, GetBrandingServerVersion,
        }

        private const string Logtag = nameof(DracoonRequestExecutor);
        private readonly IOAuth _auth;
        private readonly IInternalDracoonClientBase _client;
        private readonly DracoonErrorParser _dracoonErrorParser;
        private readonly OAuthErrorParser _oauthErrorParser;
        private bool _isServerVersionCompatible;
        private string[] _apiVersion;

        internal DracoonRequestExecutor(IInternalDracoonClientBase client, IOAuth auth) {
            _auth = auth;
            _client = client;
            _dracoonErrorParser = new DracoonErrorParser(client);
            _oauthErrorParser = new OAuthErrorParser(client);
        }

        private static bool RequestIsOAuthRequest(RequestType rType) {
            return rType == RequestType.PostOAuthToken || rType == RequestType.PostOAuthRefresh;
        }


        void IRequestExecutor.CheckApiServerVersion(string minVersionForCheck = ApiConfig.MinimumApiVersion) {
            if (_isServerVersionCompatible && minVersionForCheck == ApiConfig.MinimumApiVersion) {
                return;
            }

            if (_apiVersion == null) {
                ApiServerVersion serverVersion =
                    ((IRequestExecutor)this).DoSyncApiCall<ApiServerVersion>(_client.Builder.GetServerVersion(), RequestType.GetServerVersion);
                string version = serverVersion.RestApiVersion;
                if (version.Contains("-")) {
                    version = version.Remove(version.IndexOf("-"));
                }

                _apiVersion = Regex.Split(version, "\\.");
            }

            string[] minVersion = Regex.Split(minVersionForCheck, "\\.");
            for (int iterate = 0; iterate < 3; iterate++) {
                int remoteVersionPart = int.Parse(_apiVersion[iterate]);
                int minVersionPart = int.Parse(minVersion[iterate]);
                if (remoteVersionPart > minVersionPart) {
                    break;
                }

                if (remoteVersionPart < minVersionPart) {
                    if (minVersionForCheck == ApiConfig.MinimumApiVersion) {
                        throw new DracoonApiException(DracoonApiCode.API_VERSION_NOT_SUPPORTED);
                    }

                    throw new DracoonApiException(new DracoonApiCode(0, "Server API versions < " + minVersionForCheck + " are not supported."));
                }
            }

            if (minVersionForCheck == ApiConfig.MinimumApiVersion) {
                _isServerVersionCompatible = true;
            }
        }

        T IRequestExecutor.DoSyncApiCall<T>(IRestRequest request, RequestType requestType, int authTry = 0) {
            IRestClient client = new RestClient(_client.ServerUri) {
                UserAgent = _client.HttpConfig.UserAgent,
            };
            if (_client.HttpConfig.WebProxy != null) {
                client.Proxy = _client.HttpConfig.WebProxy;
            }

            IRestResponse response = client.Execute(request);
            if (response.ErrorException is WebException we) {
                // It's an HTTP exception
                _dracoonErrorParser.ParseError(we, requestType);
            }

            if (!response.IsSuccessful) {
                // It's an API exception
                if (RequestIsOAuthRequest(requestType)) {
                    _oauthErrorParser.ParseError(response, requestType);
                }

                try {
                    _dracoonErrorParser.ParseError(response, requestType);
                } catch (DracoonApiException apiError) {
                    if (apiError.ErrorCode == DracoonApiCode.AUTH_UNAUTHORIZED && authTry < 3) {
                        _client.Log.Debug(Logtag, "Retry the refresh of the access token in " + authTry * 1000 + " millis again.");
                        Thread.Sleep(1000 * authTry);
                        _auth.RefreshAccessToken();
                        foreach (Parameter cur in request.Parameters) {
                            if (cur.Name == ApiConfig.AuthorizationHeader) {
                                cur.Value = _auth.BuildAuthString();
                            }
                        }

                        return ((IRequestExecutor)this).DoSyncApiCall<T>(request, requestType, authTry + 1);
                    }

                    throw apiError;
                }
            }

            if (typeof(T) == typeof(VoidResponse)) {
                return new VoidResponse() as T;
            }

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        byte[] IRequestExecutor.ExecuteWebClientDownload(WebClient requestClient, Uri target, RequestType type, Thread asyncThread = null,
            int sendTry = 0) {
            byte[] response = null;
            try {
                Task<byte[]> responseTask = requestClient.DownloadDataTaskAsync(target);
                response = responseTask.Result;
            } catch (AggregateException ae) {
                if (ae.InnerException is WebException we) {
                    if (we.Status == WebExceptionStatus.SecureChannelFailure) {
                        const string message = "Server SSL handshake failed!";
                        _client.Log.Error(Logtag, message, we);
                        throw new DracoonNetInsecureException(message, we);
                    }

                    if (we.Status == WebExceptionStatus.RequestCanceled) {
                        throw new ThreadInterruptedException();
                    }

                    if (we.Status == WebExceptionStatus.ProtocolError) {
                        _dracoonErrorParser.ParseError(we, type);
                    } else {
                        string message = "Server communication failed!";
                        _client.Log.Debug(Logtag, message);
                        if (_client.HttpConfig.RetryEnabled && sendTry < 3) {
                            _client.Log.Debug(Logtag, "Retry the request in " + sendTry * 1000 + " millis again.");
                            Thread.Sleep(1000 * sendTry);
                            return ((IRequestExecutor)this).ExecuteWebClientDownload(requestClient, target, type, asyncThread, sendTry + 1);
                        } else {
                            if (asyncThread != null && asyncThread.ThreadState == ThreadState.Aborted) {
                                throw new ThreadInterruptedException();
                            }

                            _dracoonErrorParser.ParseError(we, type);
                        }
                    }
                }
            }

            return response;
        }

        public byte[] ExecuteWebClientChunkUpload(WebClient requestClient, Uri target, byte[] data, RequestType type, Thread asyncThread = null,
            int sendTry = 0) {
            byte[] response = null;
            try {
                string method = "POST";
                if (type == RequestType.PutUploadS3Chunk) {
                    method = "PUT";
                }

                Task<byte[]> responseTask = requestClient.UploadDataTaskAsync(target, method, data);
                if (type == RequestType.PutUploadS3Chunk) {
                    responseTask.Wait();
                    for (int i = 0; i < requestClient.ResponseHeaders.Count; i++) {
                        if (requestClient.ResponseHeaders.GetKey(i).ToLower().Equals("etag")) {
                            string eTag = requestClient.ResponseHeaders.Get(i);
                            eTag = eTag.Replace("\"", "").Replace("\\", "").Replace("/", "");
                            response = ApiConfig.ENCODING.GetBytes(eTag);
                        }
                    }
                } else {
                    response = responseTask.Result;
                }
            } catch (AggregateException ae) {
                if (ae.InnerException is WebException we) {
                    if (we.Status == WebExceptionStatus.SecureChannelFailure) {
                        string message = "Server SSL handshake failed!";
                        _client.Log.Error(Logtag, message, we);
                        throw new DracoonNetInsecureException(message, we);
                    }

                    if (we.Status == WebExceptionStatus.RequestCanceled) {
                        throw new ThreadInterruptedException();
                    }

                    if (we.Status == WebExceptionStatus.ProtocolError) {
                        _dracoonErrorParser.ParseError(we, type);
                    } else {
                        string message = "Server communication failed!";
                        _client.Log.Debug(Logtag, message);
                        if (_client.HttpConfig.RetryEnabled && sendTry < 3) {
                            _client.Log.Debug(Logtag, "Retry the request in " + sendTry * 1000 + " millis again.");
                            Thread.Sleep(1000 * sendTry);
                            return ((IRequestExecutor)this).ExecuteWebClientChunkUpload(requestClient, target, data, type, asyncThread, sendTry + 1);
                        } else {
                            if (asyncThread != null && asyncThread.ThreadState == ThreadState.Aborted) {
                                throw new ThreadInterruptedException();
                            }

                            _dracoonErrorParser.ParseError(we, type);
                        }
                    }
                }
            }

            return response;
        }
    }
}
