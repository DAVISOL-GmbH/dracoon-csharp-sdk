using System;
using System.Globalization;
using System.Net;
using Dracoon.Sdk.Filter;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.ApiModel.Requests;
using Dracoon.Sdk.SdkInternal.OAuth;
using Dracoon.Sdk.SdkInternal.Util;
using Dracoon.Sdk.Sort;
using Newtonsoft.Json;
using RestSharp;

namespace Dracoon.Sdk.SdkInternal {
    internal class DracoonRequestBuilder : IRequestBuilder {
        private readonly IOAuth _auth;

        private readonly IInternalDracoonClientBase _client;

        internal DracoonRequestBuilder(IInternalDracoonClientBase client, IOAuth auth) {
            _client = client;
            _auth = auth;
        }

        private void SetGeneralRestValues(IRestRequest request, bool requiresAuth, object optionalJsonBody = null) {
            if (requiresAuth) {
                request.AddHeader(ApiConfig.AuthorizationHeader, _auth.BuildAuthString());
            }

            if (optionalJsonBody != null) {
                request.AddParameter("application/json", JsonConvert.SerializeObject(optionalJsonBody), ParameterType.RequestBody);
            }

            request.ReadWriteTimeout = _client.HttpConfig.ReadWriteTimeout;
            request.Timeout = _client.HttpConfig.ConnectionTimeout;
        }

        private void SetGeneralWebClientValues(DracoonWebClientExtension requestClient) {
            requestClient.Headers.Add(HttpRequestHeader.UserAgent, _client.HttpConfig.UserAgent);
            requestClient.SetHttpConfigParams(_client.HttpConfig);
        }

        private DracoonWebClientExtension CreateDefaultWebClient() {
            DracoonWebClientExtension requestClient = new DracoonWebClientExtension();
            SetGeneralWebClientValues(requestClient);
            return requestClient;
        }

        private void AddFilters<T>(T filter, IRestRequest requestForFilterAdding) where T : DracoonFilter {
            if (filter == null)
                return;
            string filterString = filter.ToString();
            if (string.IsNullOrWhiteSpace(filterString))
                return;
            requestForFilterAdding.AddQueryParameter("filter", filterString);
        }

        private void AddSort<T>(T sort, IRestRequest requestForSortAdding) where T : DracoonSort {
            if (sort == null)
                return;
            string sortString = sort.ToString();
            if (string.IsNullOrWhiteSpace(sortString))
                return;
            requestForSortAdding.AddQueryParameter("sort", sortString);
        }

        private void AddFlag(RestRequest restRequest, string flagName, bool? flagValue) {
            if (!flagValue.HasValue)
                return;
            restRequest.AddQueryParameter(flagName, flagValue.Value.ToString(CultureInfo.InvariantCulture).ToLowerInvariant());
        }

        private void AddDate(RestRequest restRequest, string flagName, DateTime? dateValue) {
            if (!dateValue.HasValue)
                return;
            restRequest.AddQueryParameter(flagName, dateValue.Value.ToString("s", CultureInfo.InvariantCulture));
        }

        private void AddNumber(RestRequest restRequest, string flagName, long? numericValue) {
            if (!numericValue.HasValue)
                return;
            restRequest.AddQueryParameter(flagName, numericValue.Value.ToString(CultureInfo.InvariantCulture));
        }

        #region Public-Endpoint

        #region GET

        IRestRequest IRequestBuilder.GetServerVersion() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetServerVersion, Method.GET);
            SetGeneralRestValues(request, false);
            return request;
        }

        IRestRequest IRequestBuilder.GetServerTime() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetServerTime, Method.GET);
            SetGeneralRestValues(request, false);
            return request;
        }

        IRestRequest IRequestBuilder.GetPublicDownloadShare(string accessKey) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetPublicDownloadShare, Method.GET);
            SetGeneralRestValues(request, false);
            request.AddUrlSegment("accessKey", accessKey);
            return request;
        }

        IRestRequest IRequestBuilder.GetPublicUploadShare(string accessKey) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetPublicUploadShare, Method.GET);
            SetGeneralRestValues(request, false);
            request.AddUrlSegment("accessKey", accessKey);
            return request;
        }

        #endregion

        #endregion

        #region User-Endpoint

        #region GET

        IRestRequest IRequestBuilder.GetUserAccount() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetUserAccount, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        IRestRequest IRequestBuilder.GetCustomerAccount() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetCustomerAccount, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        IRestRequest IRequestBuilder.GetUserKeyPair(string algorithm) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetUserKeyPair, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddQueryParameter("version", algorithm);
            return request;
        }

        public IRestRequest GetUserKeyPairs() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetUserKeyPairs, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        IRestRequest IRequestBuilder.GetAuthenticatedPing() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetAuthenticatedPing, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddHeader("Accept", "*/*");
            return request;
        }

        IRestRequest IRequestBuilder.GetAvatar() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetAvatar, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        IRestRequest IRequestBuilder.GetUserProfileAttributes() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetUserProfileAttributes, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        IRestRequest IRequestBuilder.GetUserProfileAttribute(string attributeKey) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetUserProfileAttributes, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddQueryParameter("filter", "key:eq:" + attributeKey);
            return request;
        }

        #endregion

        #region POST

        IRestRequest IRequestBuilder.SetUserKeyPair(ApiUserKeyPair apiUserKeyPair) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostUserKeyPair, Method.POST);
            SetGeneralRestValues(request, true, apiUserKeyPair);
            return request;
        }

        #endregion

        #region PUT

        IRestRequest IRequestBuilder.PutUserProfileAttributes(ApiAddOrUpdateAttributeRequest addOrUpdateParam) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutUserProfileAttributes, Method.PUT);
            SetGeneralRestValues(request, true, addOrUpdateParam);
            return request;
        }

        #endregion

        #region DELETE

        IRestRequest IRequestBuilder.DeleteUserKeyPair(string algorithm) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteUserKeyPair, Method.DELETE);
            SetGeneralRestValues(request, true);
            request.AddQueryParameter("version", algorithm);
            return request;
        }

        IRestRequest IRequestBuilder.DeleteUserProfileAttributes(string attributeKey) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteUserProfileAttributes, Method.DELETE);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("key", attributeKey);
            return request;
        }

        IRestRequest IRequestBuilder.DeleteAvatar() {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteAvatar, Method.DELETE);
            SetGeneralRestValues(request, true);
            return request;
        }

        #endregion

        #region HTTP-Request

        WebClient IRequestBuilder.ProvideAvatarDownloadWebClient() {
            return CreateDefaultWebClient();
        }

        WebClient IRequestBuilder.ProvideAvatarUploadWebClient(string formDataBoundary) {
            DracoonWebClientExtension requestClient = new DracoonWebClientExtension();
            requestClient.Headers.Add(HttpRequestHeader.ContentType, "multipart/form-data; boundary=" + formDataBoundary);
            requestClient.Headers.Add(ApiConfig.AuthorizationHeader, _auth.BuildAuthString());
            SetGeneralWebClientValues(requestClient);
            return requestClient;
        }

        #endregion

        #endregion

        #region Nodes-Endpoint

        #region GET

        IRestRequest IRequestBuilder.GetNodes(long parentNodeId, long? offset, long? limit, GetNodesFilter filter) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetChildNodes, Method.GET);
            SetGeneralRestValues(request, true);
            AddFilters(filter, request);
            request.AddQueryParameter("parent_id", parentNodeId.ToString());
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetNode(long nodeId) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetNode, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("nodeId", nodeId);
            return request;
        }

        IRestRequest IRequestBuilder.GetFileKey(long nodeId) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetFileKey, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("fileId", nodeId);
            return request;
        }

        IRestRequest IRequestBuilder.GetSearchNodes(long parentNodeId, string searchString, long offset, long limit, int depthLevel,
            SearchNodesFilter filter, SearchNodesSort sort) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetSearchNodes, Method.GET);
            SetGeneralRestValues(request, true);
            AddFilters(filter, request);
            AddSort(sort, request);
            request.AddQueryParameter("search_string", searchString);
            request.AddQueryParameter("parent_id", parentNodeId.ToString());
            request.AddQueryParameter("depth_level", depthLevel.ToString());
            request.AddQueryParameter("offset", offset.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetMissingFileKeys(long? fileId, int limit, int offset) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetMissingFileKeys, Method.GET);
            SetGeneralRestValues(request, true);
            if (fileId.HasValue) {
                request.AddQueryParameter("fileId", fileId.ToString());
            }

            request.AddQueryParameter("offset", offset.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetRecycleBin(long parentRoomId, long? offset, long? limit) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetRecycleBin, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("roomId", parentRoomId);
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetPreviousVersions(long nodeId, string type, string nodeName, long? offset, long? limit) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetPreviousVersions, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("nodeId", nodeId);
            request.AddQueryParameter("type", type);
            request.AddQueryParameter("name", nodeName);
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetPreviousVersion(long previousNodeId) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetPreviousVersion, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("previousNodeId", previousNodeId);
            return request;
        }

        IRestRequest IRequestBuilder.GetS3Status(string uploadId) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetS3Status, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("uploadId", uploadId);
            return request;
        }

        IRestRequest IRequestBuilder.GetRoomEvents(long roomId, DateTime? dateStart, DateTime? dateEnd, EventStatus? status, int? type, long? userId, long? offset, long? limit, EventLogsSort sort) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetRoomEvents, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("roomId", roomId);
            AddSort(sort, request);
            AddDate(request, "date_start", dateStart);
            AddDate(request, "date_end", dateEnd);
            AddNumber(request, "type", type);
            AddNumber(request, "user_id", userId);
            if (status.HasValue)
                request.AddQueryParameter("status", Convert.ToInt32(status.Value).ToString(CultureInfo.InvariantCulture));
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetRoomGroups(long roomId, long? offset, long? limit, GetRoomGroupsFilter filter) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetRoomGroups, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("roomId", roomId);
            AddFilters(filter, request);
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetRoomUsers(long roomId, long? offset, long? limit, GetRoomUsersFilter filter) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetRoomUsers, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("roomId", roomId);
            AddFilters(filter, request);
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetRoomPending(long roomId, long? offset, long? limit, GetRoomPendingFilter filter, PendingAssignmentsSort sort) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetRoomPending, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("roomId", roomId);
            AddSort(sort, request);
            AddFilters(filter, request);
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        #endregion

        #region POST

        IRestRequest IRequestBuilder.PostRoom(ApiCreateRoomRequest roomParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostRoom, Method.POST);
            SetGeneralRestValues(request, true, roomParams);
            return request;
        }

        IRestRequest IRequestBuilder.PostFolder(ApiCreateFolderRequest folderParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostFolder, Method.POST);
            SetGeneralRestValues(request, true, folderParams);
            return request;
        }

        IRestRequest IRequestBuilder.PostFileDownload(long fileId) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostCreateFileDownload, Method.POST);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("fileId", fileId);
            return request;
        }

        IRestRequest IRequestBuilder.PostCreateFileUpload(ApiCreateFileUpload uploadParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostCreateFileUpload, Method.POST);
            SetGeneralRestValues(request, true, uploadParams);
            return request;
        }

        IRestRequest IRequestBuilder.PostGetS3Urls(string uploadId, ApiGetS3Urls s3UrlParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostGetS3Urls, Method.POST);
            SetGeneralRestValues(request, true, s3UrlParams);
            request.AddUrlSegment("uploadId", uploadId);
            return request;
        }

        IRestRequest IRequestBuilder.PostCopyNodes(long targetNodeId, ApiCopyNodesRequest copyParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostCopyNodes, Method.POST);
            SetGeneralRestValues(request, true, copyParams);
            request.AddUrlSegment("nodeId", targetNodeId);
            return request;
        }

        IRestRequest IRequestBuilder.PostMoveNodes(long targetNodeId, ApiMoveNodesRequest moveParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostMoveNodes, Method.POST);
            SetGeneralRestValues(request, true, moveParams);
            request.AddUrlSegment("nodeId", targetNodeId);
            return request;
        }

        IRestRequest IRequestBuilder.PostMissingFileKeys(ApiSetUserFileKeysRequest fileKeyParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostMissingFileKeys, Method.POST);
            SetGeneralRestValues(request, true, fileKeyParams);
            return request;
        }

        IRestRequest IRequestBuilder.PostFavorite(long nodeId) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostFavorite, Method.POST);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("nodeId", nodeId);
            return request;
        }

        IRestRequest IRequestBuilder.PostRestoreNodeVersion(ApiRestorePreviousVersionsRequest restoreParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostRestoreNodeVersion, Method.POST);
            SetGeneralRestValues(request, true, restoreParams);
            return request;
        }

        #endregion

        #region PUT

        IRestRequest IRequestBuilder.PutRoom(long roomId, ApiUpdateRoomRequest roomParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutRoom, Method.PUT);
            SetGeneralRestValues(request, true, roomParams);
            request.AddUrlSegment("roomId", roomId);
            return request;
        }

        IRestRequest IRequestBuilder.PutRoomConfig(long roomId, ApiConfigRoomRequest roomParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutRoomConfig, Method.PUT);
            SetGeneralRestValues(request, true, roomParams);
            request.AddUrlSegment("roomId", roomId);
            return request;
        }

        IRestRequest IRequestBuilder.PutRoomGroups(long roomId, ApiRoomGroupsAddBatchRequest roomGroupParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutRoomGroups, Method.PUT);
            SetGeneralRestValues(request, true, roomGroupParams);
            request.AddUrlSegment("roomId", roomId);
            return request;
        }

        IRestRequest IRequestBuilder.PutRoomUsers(long roomId, ApiRoomUsersAddBatchRequest roomUserParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutRoomUsers, Method.PUT);
            SetGeneralRestValues(request, true, roomUserParams);
            request.AddUrlSegment("roomId", roomId);
            return request;
        }

        IRestRequest IRequestBuilder.PutEnableRoomEncryption(long roomId, ApiEnableRoomEncryptionRequest encryptionParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutEnableRoomEncryption, Method.PUT);
            SetGeneralRestValues(request, true, encryptionParams);
            request.AddUrlSegment("roomId", roomId);
            return request;
        }

        IRestRequest IRequestBuilder.PutFolder(long folderId, ApiUpdateFolderRequest folderParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutFolder, Method.PUT);
            SetGeneralRestValues(request, true, folderParams);
            request.AddUrlSegment("folderId", folderId);
            return request;
        }

        IRestRequest IRequestBuilder.PutFile(long fileId, ApiUpdateFileRequest fileParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutFileUpdate, Method.PUT);
            SetGeneralRestValues(request, true, fileParams);
            request.AddUrlSegment("fileId", fileId);
            return request;
        }

        IRestRequest IRequestBuilder.PutCompleteFileUpload(string uploadPath, ApiCompleteFileUpload completeParams) {
            RestRequest request = new RestRequest(uploadPath, Method.PUT);
            SetGeneralRestValues(request, true, completeParams);
            return request;
        }

        IRestRequest IRequestBuilder.PutCompleteS3FileUpload(string uploadId, ApiCompleteFileUpload completeParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutCompleteS3Upload, Method.PUT);
            SetGeneralRestValues(request, true, completeParams);
            request.AddUrlSegment("uploadId", uploadId);
            return request;
        }

        #endregion

        #region DELETE

        IRestRequest IRequestBuilder.DeleteNodes(ApiDeleteNodesRequest deleteParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteNodes, Method.DELETE);
            SetGeneralRestValues(request, true, deleteParams);
            return request;
        }

        IRestRequest IRequestBuilder.DeleteFavorite(long nodeId) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteFavorite, Method.DELETE);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("nodeId", nodeId);
            return request;
        }

        IRestRequest IRequestBuilder.DeleteRecycleBin(long parentRoomId) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteRecycleBin, Method.DELETE);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("roomId", parentRoomId);
            return request;
        }

        IRestRequest IRequestBuilder.DeletePreviousVersion(ApiDeletePreviousVersionsRequest deleteParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeletePreviousVersions, Method.DELETE);
            SetGeneralRestValues(request, true, deleteParams);
            return request;
        }

        IRestRequest IRequestBuilder.DeleteRoomGroups(long roomId, ApiRoomGroupsDeleteBatchRequest deleteParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteRoomGroups, Method.DELETE);
            SetGeneralRestValues(request, true, deleteParams);
            request.AddUrlSegment("roomId", roomId);
            return request;
        }

        IRestRequest IRequestBuilder.DeleteRoomUsers(long roomId, ApiRoomUsersDeleteBatchRequest deleteParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteRoomUsers, Method.DELETE);
            SetGeneralRestValues(request, true, deleteParams);
            request.AddUrlSegment("roomId", roomId);
            return request;
        }

        #endregion

        #region HTTP-Request

        WebClient IRequestBuilder.ProvideChunkDownloadWebClient(long offset, long count) {
            DracoonWebClientExtension requestClient = new DracoonWebClientExtension(rangeFrom: offset, rangeTo: (offset + count) - 1);
            SetGeneralWebClientValues(requestClient);
            return requestClient;
        }

        WebClient IRequestBuilder.ProvideChunkUploadWebClient(int chunkLength, long offset, string formDataBoundary, string totalFileSize) {
            DracoonWebClientExtension requestClient = new DracoonWebClientExtension();
            requestClient.Headers.Add(HttpRequestHeader.ContentRange, "bytes " + offset + "-" + (offset + chunkLength) + "/" + totalFileSize);
            requestClient.Headers.Add(HttpRequestHeader.ContentType, "multipart/form-data; boundary=" + formDataBoundary);
            SetGeneralWebClientValues(requestClient);
            return requestClient;
        }

        WebClient IRequestBuilder.ProvideS3ChunkUploadWebClient() {
            return CreateDefaultWebClient();
        }

        #endregion

        #endregion

        #region Share-Endpoint

        #region GET

        IRestRequest IRequestBuilder.GetDownloadShares(long? offset, long? limit, GetDownloadSharesFilter filter, SharesSort sort) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetDownloadShares, Method.GET);
            SetGeneralRestValues(request, true);
            AddFilters(filter, request);
            AddSort(sort, request);
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetUploadShares(long? offset, long? limit, GetUploadSharesFilter filter, SharesSort sort) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetUploadShares, Method.GET);
            SetGeneralRestValues(request, true);
            AddFilters(filter, request);
            AddSort(sort, request);
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        #endregion

        #region POST

        IRestRequest IRequestBuilder.PostCreateDownloadShare(ApiCreateDownloadShareRequest downloadShareParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostCreateDownloadShare, Method.POST);
            SetGeneralRestValues(request, true, downloadShareParams);
            return request;
        }

        IRestRequest IRequestBuilder.PostCreateUploadShare(ApiCreateUploadShareRequest uploadShareParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostCreateUploadShare, Method.POST);
            SetGeneralRestValues(request, true, uploadShareParams);
            return request;
        }

        #endregion

        #region DELETE

        IRestRequest IRequestBuilder.DeleteDownloadShare(long shareId) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteDownloadShare, Method.DELETE);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("shareId", shareId);
            return request;
        }

        IRestRequest IRequestBuilder.DeleteUploadShare(long shareId) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteUploadShare, Method.DELETE);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("shareId", shareId);
            return request;
        }

        #endregion

        #endregion

        #region OAuth-Endpoint

        #region POST

        IRestRequest IRequestBuilder.PostOAuthToken(string clientId, string clientSecret, string grantType, string code) {
            RestRequest request = new RestRequest(OAuthConfig.OAuthPostAuthToken, Method.POST);
            SetGeneralRestValues(request, false);
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(ApiConfig.ENCODING.GetBytes(clientId + ":" + clientSecret)));
            request.AddParameter("grant_type", grantType, ParameterType.GetOrPost);
            request.AddParameter("code", code, ParameterType.GetOrPost);
            return request;
        }

        IRestRequest IRequestBuilder.PostOAuthRefresh(string clientId, string clientSecret, string grantType, string refreshToken) {
            RestRequest request = new RestRequest(OAuthConfig.OAuthPostRefreshToken, Method.POST);
            SetGeneralRestValues(request, false);
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(ApiConfig.ENCODING.GetBytes(clientId + ":" + clientSecret)));
            request.AddParameter("grant_type", grantType, ParameterType.GetOrPost);
            request.AddParameter("refresh_token", refreshToken, ParameterType.GetOrPost);
            return request;
        }

        #endregion

        #endregion

        #region Config-Endpoint

        #region GET

        IRestRequest IRequestBuilder.GetGeneralSettings() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetGeneralConfig, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        IRestRequest IRequestBuilder.GetInfrastructureSettings() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetInfrastructureConfig, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        IRestRequest IRequestBuilder.GetDefaultsSettings() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetDefaultsConfig, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        public IRestRequest GetPasswordPolicies() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetPasswordPolicies, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        public IRestRequest GetAlgorithms() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetAlgorithms, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        public IRestRequest GetClassificationPolicies() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetClassificationPolicies, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        #endregion

        #endregion

        #region Resources-Endpoint

        #region GET

        IRestRequest IRequestBuilder.GetUserAvatar(long userId, string avatarUuid) {
            RestRequest request = new RestRequest(ApiConfig.ApiResourcesGetAvatar, Method.GET);
            SetGeneralRestValues(request, false);
            request.AddUrlSegment("userId", userId);
            request.AddUrlSegment("uuid", avatarUuid);
            return request;
        }

        #endregion

        #endregion

        #region System-Settings-Config-Endpoint

        #region GET

        IRestRequest IRequestBuilder.GetAuthenticationSettings() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetAuthenticationConfig, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        #endregion

        #endregion

        #region System-Auth-Config-Endpoint

        #region GET

        IRestRequest IRequestBuilder.GetAuthActiveDirectorySettings() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetAuthActiveDirectorySettings, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        IRestRequest IRequestBuilder.GetAuthOpenIdIdpSettings() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetAuthOpenIdIdpSettings, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        IRestRequest IRequestBuilder.GetAuthRadiusSettings() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetAuthRadiusSettings, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        #endregion

        #endregion

        #region Groups-Endpoint

        #region GET

        IRestRequest IRequestBuilder.GetGroups(long? offset, long? limit, GetGroupsFilter filter, GroupsSort sort) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetGroups, Method.GET);
            SetGeneralRestValues(request, true);
            AddFilters(filter, request);
            AddSort(sort, request);
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetGroup(long groupId) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetGroup, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("groupId", groupId.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetGroupLastAdminRooms(long groupId) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetGroupLastAdminRooms, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("groupId", groupId.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetGroupRoles(long groupId) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetGroupRoles, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("groupId", groupId.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetGroupUsers(long groupId, long? offset, long? limit, GetGroupUsersFilter filter) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetGroupUsers, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("groupId", groupId.ToString());
            AddFilters(filter, request);
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        #endregion
        #region POST

        IRestRequest IRequestBuilder.PostGroup(ApiCreateGroupRequest groupParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostGroup, Method.POST);
            SetGeneralRestValues(request, true, groupParams);
            return request;
        }

        IRestRequest IRequestBuilder.PostGroupUser(long groupId, ApiChangeMembersRequest groupUsersParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostGroupUser, Method.POST);
            SetGeneralRestValues(request, true, groupUsersParams);
            request.AddUrlSegment("groupId", groupId.ToString());
            return request;
        }

        #endregion
        #region PUT

        IRestRequest IRequestBuilder.PutGroup(long groupId, ApiUpdateGroupRequest groupParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutGroup, Method.PUT);
            SetGeneralRestValues(request, true, groupParams);
            request.AddUrlSegment("groupId", groupId.ToString());
            return request;
        }

        #endregion
        #region DELETE


        IRestRequest IRequestBuilder.DeleteGroup(long groupId) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteGroup, Method.DELETE);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("groupId", groupId.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.DeleteGroupUsers(long groupId, ApiChangeMembersRequest deleteUsersParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteGroupUsers, Method.DELETE);
            SetGeneralRestValues(request, true, deleteUsersParams);
            request.AddUrlSegment("groupId", groupId.ToString());
            return request;
        }

        #endregion

        #endregion

        #region Users-Endpoint

        #region GET

        IRestRequest IRequestBuilder.GetUsers(bool? includeAttributes, bool? includeRoles, bool? includeHasManageableRooms, long? offset, long? limit, GetUsersFilter filter, UsersSort sort) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetUsers, Method.GET);
            SetGeneralRestValues(request, true);
            AddFilters(filter, request);
            AddSort(sort, request);
            AddFlag(request, "include_attributes", includeAttributes);
            AddFlag(request, "include_user_attributes", includeAttributes);
            AddFlag(request, "include_user_roles", includeRoles);
            AddFlag(request, "include_roles", includeRoles);
            AddFlag(request, "include_manageable_rooms", includeHasManageableRooms);
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetUser(long userId, bool? effectiveRoles) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetUser, Method.GET);
            SetGeneralRestValues(request, true);
            AddFlag(request, "effective_roles", effectiveRoles);
            request.AddUrlSegment("userId", userId.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetUserGroups(long userId, long? offset, long? limit, GetUserGroupsFilter filter) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetUserGroups, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("userId", userId.ToString());
            AddFilters(filter, request);
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetUserLastAdminRooms(long userId) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetUserLastAdminRooms, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("userId", userId.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetUserRoles(long userId) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetUserRoles, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("userId", userId.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetUserUserAttributes(long userId, long? offset, long? limit, GetUserAttributesFilter filter, UserAttributesSort sort) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetUserUserAttributes, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("userId", userId.ToString());
            AddFilters(filter, request);
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        #endregion
        #region POST

        IRestRequest IRequestBuilder.PostUser(ApiCreateUserRequest userParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostUser, Method.POST);
            SetGeneralRestValues(request, true, userParams);
            return request;
        }

        IRestRequest IRequestBuilder.PostUserUserAttributes(long userId, ApiUserAttributes userAttributeParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostUserAttributes, Method.POST);
            SetGeneralRestValues(request, true, userAttributeParams);
            request.AddUrlSegment("userId", userId.ToString());
            return request;
        }

        #endregion
        #region PUT

        IRestRequest IRequestBuilder.PutUser(long userId, ApiUpdateUserRequest userParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutUser, Method.PUT);
            SetGeneralRestValues(request, true, userParams);
            request.AddUrlSegment("userId", userId.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.PutUserUserAttributes(long userId, ApiUserAttributes userAttributeParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutUserUserAttributes, Method.PUT);
            SetGeneralRestValues(request, true, userAttributeParams);
            request.AddUrlSegment("userId", userId.ToString());
            return request;
        }

        #endregion
        #region DELETE

        IRestRequest IRequestBuilder.DeleteUser(long userId) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteUser, Method.DELETE);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("userId", userId.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.DeleteUserUserAttribute(long userId, string userAttributeKey) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteUserUserAttribute, Method.DELETE);
            request.AddUrlSegment("userId", userId.ToString());
            request.AddUrlSegment("key", userAttributeKey);
            return request;
        }

        #endregion

        #endregion

        #region Roles-Endpoint

        #region GET

        IRestRequest IRequestBuilder.GetRoles() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetRoles, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        IRestRequest IRequestBuilder.GetRoleGroups(long roleId, long? offset, long? limit, GetUserGroupsFilter filter) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetRoleGroups, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("roleId", roleId.ToString());
            AddFilters(filter, request);
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetRoleUsers(long roleId, long? offset, long? limit, GetGroupUsersFilter filter) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetRoleUsers, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("roleId", roleId.ToString());
            AddFilters(filter, request);
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        #endregion
        #region POST

        IRestRequest IRequestBuilder.PostRoleGroups(long roleId, ApiChangeMembersRequest addGroupsParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostRoleGroups, Method.POST);
            SetGeneralRestValues(request, true, addGroupsParams);
            request.AddUrlSegment("roleId", roleId.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.PostRoleUsers(long roleId, ApiChangeMembersRequest addUsersParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostRoleUsers, Method.POST);
            SetGeneralRestValues(request, true, addUsersParams);
            request.AddUrlSegment("roleId", roleId.ToString());
            return request;
        }

        #endregion
        #region DELETE

        IRestRequest IRequestBuilder.DeleteRoleGroups(long roleId, ApiChangeMembersRequest deleteGroupsParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteRoleGroups, Method.DELETE);
            SetGeneralRestValues(request, true, deleteGroupsParams);
            request.AddUrlSegment("roleId", roleId.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.DeleteRoleUsers(long roleId, ApiChangeMembersRequest deleteUsersParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteRoleUsers, Method.DELETE);
            SetGeneralRestValues(request, true, deleteUsersParams);
            request.AddUrlSegment("roleId", roleId.ToString());
            return request;
        }

        #endregion

        #endregion

        #region EventLog-Endpoint

        #region GET

        IRestRequest IRequestBuilder.GetAuditNodes(long? offset, long? limit, GetAuditNodesFilter filter, AuditNodesSort sort) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetAuditNodes, Method.GET);
            SetGeneralRestValues(request, true);
            AddFilters(filter, request);
            AddSort(sort, request);
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetEvents(DateTime? dateStart, DateTime? dateEnd, EventStatus? status, int? type, long? userId, string userClient, long? offset, long? limit, EventLogsSort sort) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetEvents, Method.GET);
            SetGeneralRestValues(request, true);
            AddSort(sort, request);
            AddDate(request, "date_start", dateStart);
            AddDate(request, "date_end", dateEnd);
            AddNumber(request, "type", type);
            AddNumber(request, "user_id", userId);
            if (status.HasValue)
                request.AddQueryParameter("status", Convert.ToInt32(status.Value).ToString(CultureInfo.InvariantCulture));
            if (!string.IsNullOrWhiteSpace(userClient))
                request.AddQueryParameter("user_client", userClient);
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        IRestRequest IRequestBuilder.GetOperations(bool? isDeprecated) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetOperations, Method.GET);
            SetGeneralRestValues(request, true);
            AddFlag(request, "is_deprecated", isDeprecated);
            return request;
        }

        #endregion

        #endregion

        #region Branding-Endpoint (Branding API)

        IRestRequest IRequestBuilder.GetBranding() {
            RestRequest request = new RestRequest(ApiConfig.BrandingApiGetBranding, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        IRestRequest IRequestBuilder.GetBrandingServerVersion() {
            RestRequest request = new RestRequest(ApiConfig.BrandingApiGetBrandingServerVersion, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        #endregion
    }
}
