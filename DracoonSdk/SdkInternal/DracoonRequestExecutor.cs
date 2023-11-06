using Dracoon.Sdk.Error;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.OAuth;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Dracoon.Sdk.SdkInternal {
    internal class DracoonRequestExecutor : IRequestExecutor {
        internal enum RequestType {
            GetServerVersion, GetServerTime, GetPublicDownloadShare, GetPublicUploadShare, GetPublicSystemInfo, GetPublicSystemActiveDirectoryAuth, GetPublicSystemOpenIdAuth,
            SetUserKeyPair, GetCustomerAccount, GetUserAccount, GetUserKeyPair, DeleteUserKeyPair,
            GetUserAvatar, DeleteUserAvatar, PostUserAvatar,
            GetUserProfileAttributes, PutUserProfileAttributes, DeleteUserProfileAttributes,
            GetResourcesAvatar, GetNodes, GetNode, PostRoom, PostFolder,
            PutFolder, PutRoom, PutEnableRoomEncryption, PutFile, DeleteNodes,
            PostDownloadToken, GetFileKey, PostUploadToken, PutCompleteUpload, PutCompleteS3Upload,
            PostUploadChunk, PutUploadS3Chunk, GetDownloadChunk, PostCopyNodes, PostMoveNodes,
            GetSearchNodes, GetMissingFileKeys, PostMissingFileKeys, PostCreateDownloadShare, DeleteDownloadShare,
            PostMailDownloadShare, PostMailUploadShare,
            GetDownloadShares, PostCreateUploadShare, DeleteUploadShare, GetUploadShares, PostFavorite,
            DeleteFavorite, GetAuthenticatedPing, PostOAuthToken, PostOAuthRefresh, GetGeneralSettings,
            GetInfrastructureSettings, GetDefaultsSettings, GetRecycleBin, DeleteRecycleBin, GetPreviousVersions,
            GetPreviousVersion, PostRestoreNodeVersion, DeletePreviousVersions, PostGetS3Urls, GetS3Status, GetPasswordPolicies,
            GetAlgorithms, GetClassificationPolicies, GenerateVirusProtectionInfo, DeleteMaliciousFile, GetDownloadShareSubscriptions,
            GetUploadShareSubscriptions, PostUploadShareSubscription, PostDownloadShareSubscription, DeleteDownloadShareSubscription,
            DeleteUploadShareSubscription,            
            GetRoomEvents, GetRoomGroups, GetRoomUsers, GetRoomPending, PutRoomConfig, PutRoomGroups, PutRoomUsers, DeleteRoomGroups, DeleteRoomUsers,
            GetServerGeneralConfig, PutServerGeneralConfig,
            GetSystemOAuthClientConfigs, GetSystemOAuthClientConfig, PutSystemOAuthClientConfig, PostSystemOAuthClientConfig, DeleteSystemOAuthClientConfig,
            GetAuthenticationSettings, GetAuthActiveDirectorySettings, GetAuthOpenIdIdpSettings, GetAuthRadiusSettings,
            GetGroups, GetGroup, GetGroupLastAdminRooms, GetGroupRoles, GetGroupUsers, PostGroup, PostGroupUsers, PutGroup, DeleteGroup, DeleteGroupUsers,
            GetUsers, GetUser, GetUserLastAdminRooms, GetUserRoles, GetUserGroups, GetUserUserAttributes, PostUser, PostUserUserAttributes, PutUser, PutUserUserAttributes, DeleteUser, DeleteUserUserAttribute,
            GetRoles, GetRoleGroups, GetRoleUsers, PostRoleGroups, PostRoleUsers, DeleteRoleGroups, DeleteRoleUsers,
            GetAuditNodes, GetEvents, GetOperations,
            GetBranding, GetBrandingServerVersion,
            GetUserKeyPairs
        }

        private const string Logtag = nameof(DracoonRequestExecutor);
        private readonly IOAuth _auth;
        private readonly IInternalDracoonClientBase _client;
        private bool _isServerVersionCompatible;
        private string[] _apiVersion;

        internal DracoonRequestExecutor(IInternalDracoonClientBase client, IOAuth auth) {
            _auth = auth;
            _client = client;
        }

        private static bool RequestIsOAuthRequest(RequestType rType) {
            return rType == RequestType.PostOAuthToken || rType == RequestType.PostOAuthRefresh;
        }


        void IRequestExecutor.CheckApiServerVersion(string minVersionForCheck) {
            if (_isServerVersionCompatible && minVersionForCheck == ApiConfig.MinimumApiVersion) {
                return;
            }

            if (_apiVersion == null) {
                ApiServerVersion serverVersion =
                    ((IRequestExecutor)this).DoSyncApiCall<ApiServerVersion>(_client.Builder.GetServerVersion(), RequestType.GetServerVersion);
                    ((IRequestExecutor)this).DoSyncApiCall<ApiServerVersion>(_client.Builder.GetServerVersion(), RequestType.GetServerVersion);
                string version = serverVersion.RestApiVersion;
                if (version.Contains("-")) {
                    version = version.Remove(version.IndexOf("-"));
                }

                _apiVersion = Regex.Split(version, "\\.", RegexOptions.None, new TimeSpan(0, 5, 0));
            }

            string[] minVersion = Regex.Split(minVersionForCheck, "\\.", RegexOptions.None, new TimeSpan(0, 5, 0));
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

                    throw new DracoonApiException(new DracoonApiCode(DracoonApiCode.API_VERSION_NOT_SUPPORTED.Code, "Server API versions < " + minVersionForCheck + " are not supported."));
                }
            }

            if (minVersionForCheck == ApiConfig.MinimumApiVersion) {
                _isServerVersionCompatible = true;
            }
        }

        T IRequestExecutor.DoSyncApiCall<T>(RestRequest request, RequestType requestType, int sendTry) {
            RestClientOptions clientOptions = new RestClientOptions(_client.ServerUri) {
                UserAgent = _client.HttpConfig.UserAgent,
            };
            if (_client.HttpConfig.WebProxy != null) {
                clientOptions.Proxy = _client.HttpConfig.WebProxy;
            }
            RestClient client = new RestClient(clientOptions);

            var sw = System.Diagnostics.Stopwatch.StartNew();
            RestResponse response = client.Execute(request);
            sw.Stop();
            try {
                if (response.ErrorException is WebException we) {
                    // It's an HTTP exception
                    DracoonErrorParser.ParseError(we, requestType);
                }

                if (!response.IsSuccessful) {
                    // It's an API exception
                    if (RequestIsOAuthRequest(requestType)) {
                        OAuthErrorParser.ParseError(response, requestType);
                    }

                    try {
                        DracoonErrorParser.ParseError(response, requestType, sw.ElapsedMilliseconds);
                    } catch (DracoonApiException apiError) {
                        if (apiError.ErrorCode.Code == DracoonApiCode.AUTH_UNAUTHORIZED.Code && sendTry < 2) {
                            _client.Log.Debug(Logtag, $"Retry the request after refreshing the access token{(sendTry <= 0 ? "" : $" in {sendTry} seconds")}.");
                            Thread.Sleep(1000 * sendTry);
                            _auth.RefreshAccessToken();
                            var authParameter = Parameter.CreateParameter(ApiConfig.AuthorizationHeader, _auth.BuildAuthString(), ParameterType.HttpHeader);
                            //if (request.Parameters.Exists(authParameter)) {
                            //    request.Parameters.RemoveParameter(authParameter);
                            //}
                            //request.Parameters.RemoveParameter(authParameter);
                            request.Parameters.AddParameter(authParameter);

                            return ((IRequestExecutor)this).DoSyncApiCall<T>(request, requestType, sendTry + 1);
                        }

                        throw;
                    }
                }
            } catch (DracoonApiException dae) {
                if (CanRetryRequest(sendTry, dae, response)) {
                    return ((IRequestExecutor)this).DoSyncApiCall<T>(request, requestType, sendTry + 1);
                }

                throw;
            }

            if (typeof(T) == typeof(VoidResponse)) {
                return new VoidResponse() as T;
            }

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        byte[] IRequestExecutor.ExecuteWebClientDownload(WebClient requestClient, Uri target, RequestType type, Thread asyncThread,
            int sendTry) {
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

                    try {
                        if (we.Status == WebExceptionStatus.ProtocolError) {
                            DracoonErrorParser.ParseError(we, type);
                        } else {
                            string message = "Server communication failed!";
                            _client.Log.Debug(Logtag, message);
                            if (_client.HttpConfig.RetryEnabled && sendTry < 3) {
                                _client.Log.Debug(Logtag, $"Retry the file download request in {sendTry} seconds.");
                                Thread.Sleep(1000 * sendTry);
                                return ((IRequestExecutor)this).ExecuteWebClientDownload(requestClient, target, type, asyncThread, sendTry + 1);
                            } else {
                                if (asyncThread != null && asyncThread.ThreadState == ThreadState.Aborted) {
                                    throw new ThreadInterruptedException();
                                }

                                DracoonErrorParser.ParseError(we, type);
                            }
                        }
                    } catch (DracoonApiException dae) {
                        if (CanRetryRequest(sendTry, dae, response)) {
                            return ((IRequestExecutor)this).ExecuteWebClientDownload(requestClient, target, type, asyncThread, sendTry + 1);
                        }

                        throw;
                    }

                }
            }

            return response;
        }

        public byte[] ExecuteWebClientChunkUpload(WebClient requestClient, Uri target, byte[] data, RequestType type, Thread asyncThread = null, int sendTry = 0) {
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

                    try {
                        if (we.Status == WebExceptionStatus.ProtocolError) {
                            DracoonErrorParser.ParseError(we, type);
                        } else {
                            string message = "Server communication failed!";
                            _client.Log.Debug(Logtag, message);
                            if (_client.HttpConfig.RetryEnabled && sendTry < _client.HttpConfig.MaxRetriesPerRequest) {
                                _client.Log.Debug(Logtag, $"Retry the chunk upload request in {sendTry} seconds.");
                                Thread.Sleep(1000 * sendTry);
                                return ((IRequestExecutor)this).ExecuteWebClientChunkUpload(requestClient, target, data, type, asyncThread, sendTry + 1);
                            } else {
                                if (asyncThread != null && asyncThread.ThreadState == ThreadState.Aborted) {
                                    throw new ThreadInterruptedException();
                                }

                                DracoonErrorParser.ParseError(we, type);
                            }
                        }
                    } catch (DracoonApiException dae) {
                        if (CanRetryRequest(sendTry, dae, response)) {
                            return ((IRequestExecutor)this).ExecuteWebClientChunkUpload(requestClient, target, data, type, asyncThread, sendTry + 1);
                        }

                        throw;
                    }
                }
            }

            return response;
        }

        /** Replaced by the more generic CanRetryRequest, see below
        private bool CheckTooManyRequestsResult(DracoonApiException error, object response) {
            if (error.ErrorCode.Code == DracoonApiCode.SERVER_TOO_MANY_REQUESTS.Code) {
                int retryAfter;
                if (!int.TryParse(DracoonErrorParser.GetResponseHeaderValue(response, "Retry-After"), out retryAfter)) {
                    retryAfter = 1;// retryAfter is given in seconds and if no header is given use fallback time of 1 second
                }

                int waitingTime = retryAfter * 1000 + new Random().Next(0, 500);
                _client.Log.Debug(Logtag, $"Http status code 429 was given. Retry the request in { waitingTime } millis again.");
                Thread.Sleep(waitingTime);

                return true;
            }

            return false;
        }
        **/

        private bool CanRetryRequest(int sendTry, DracoonApiException error, object response) {

            int retryAfter = -1;
            string retryReason = null;

            if (error?.ErrorCode != null) {
                if (error.ErrorCode.Code == DracoonApiCode.SERVER_TOO_MANY_REQUESTS.Code) {
                    if (sendTry < Math.Max(3, _client.HttpConfig.MaxRetriesPerRequest)) {
                        retryReason = "HTTP status code 429 Too Many Requests was given";
                    }
                }
                else if (_client.HttpConfig.RetryEnabled && sendTry < _client.HttpConfig.MaxRetriesPerRequest) {
                    if (error.ErrorCode.Code == DracoonApiCode.SERVER_UNAVAILABLE.Code) {
                        retryReason = "The API is not available";
                    }
                    else if (error.ErrorCode.Code == DracoonApiCode.SERVER_BAD_GATEWAY.Code) {
                        retryReason = "The API is not ready";

                    } else if (error.ErrorCode.Code == DracoonApiCode.SERVER_GATEWAY_TIMEOUT.Code) {
                        retryReason = "The API did not answer in time";
                    }
                    else if (error.ErrorCode.Code == DracoonApiCode.SERVER_MAINTENANCE.Code) {
                        retryReason = "The API is in maintenance";
                        // In maintenance mode, a retry is done after a minute
                        retryAfter = 60_000;
                    }
                }
            }

            if (string.IsNullOrEmpty(retryReason)) {
                return false;
            }

            // Check if the Retry-After header is present in the API's response
            if (int.TryParse(DracoonErrorParser.GetResponseHeaderValue(response, "Retry-After"), out int retryAfterHeader)) {
                // The Retry-After header represents the wait time in seconds, 1 second is used as a fallback for zero or negative header values
                retryAfter = Math.Max(1, retryAfterHeader) * 1000;
            }
            else if (retryAfter <= 0) { 
                // ...otherwise calculate the seconds to wait before retry from the current retry counter
                retryAfter = CalculateDefaultRetryWaitTime(sendTry);
            }

            _client.Log.Debug(Logtag, $"{retryReason}. Retry the request in {retryAfter} milliseconds (retry {sendTry + 1} of {_client.HttpConfig.MaxRetriesPerRequest}).");
            Thread.Sleep(retryAfter);

            return true;
        }

        private static int CalculateDefaultRetryWaitTime(int sendTry) {
            if (sendTry <= 0) {
                // first retry after 300 ms
                return 300;
            }
            else if (sendTry == 1) {
                // second retry after 500 ms
                return 500;
            }

            // use Fibonacci for the third and any additional retry wait time (800ms, 1300ms, 2100ms, 3400ms, ...)
            return CalculateDefaultRetryWaitTime(sendTry - 2) + CalculateDefaultRetryWaitTime(sendTry - 1);
        }
    }
}
