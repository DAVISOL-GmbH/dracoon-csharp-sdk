using System;
using System.Globalization;
using System.Net;
using System.Text;
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
    internal class DracoonRequestBuilder {

        private DracoonClientBase client;

        internal DracoonRequestBuilder(DracoonClientBase client) {
            this.client = client;
        }

        private void SetGeneralRestValues(RestRequest request, bool requiresAuth, object optionalJsonBody = null) {
            if (requiresAuth) {
                request.AddHeader(ApiConfig.AuthorizationHeader, client.OAuthClient.BuildAuthString());
            }
            if (optionalJsonBody != null) {
                request.AddParameter("application/json", JsonConvert.SerializeObject(optionalJsonBody), ParameterType.RequestBody);
            }
            request.ReadWriteTimeout = client.HttpConfig.ReadWriteTimeout;
            request.Timeout = client.HttpConfig.ConnectionTimeout;
        }

        private void SetGeneralWebClientValues(DracoonWebClientExtension requestClient) {
            requestClient.Headers.Add(HttpRequestHeader.UserAgent, client.HttpConfig.UserAgent);
            requestClient.SetHttpConfigParams(client.HttpConfig);
        }

        private void AddFilters<T>(T filter, RestRequest requestForFilterAdding) where T : DracoonFilter {
            if (filter == null)
                return;
            string filterString = filter.ToString();
            if (String.IsNullOrWhiteSpace(filterString))
                return;
            requestForFilterAdding.AddQueryParameter("filter", filterString);
        }

        private void AddSort<T>(T sort, RestRequest requestForSortAdding) where T : DracoonSort {
            if (sort == null)
                return;
            string sortString = sort.ToString();
            if (String.IsNullOrWhiteSpace(sortString))
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

        internal RestRequest GetServerVersion() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetServerVersion, Method.GET);
            SetGeneralRestValues(request, false);
            return request;
        }

        internal RestRequest GetServerTime() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetServerTime, Method.GET);
            SetGeneralRestValues(request, false);
            return request;
        }

        #endregion

        #endregion

        #region User-Endpoint

        #region GET

        internal RestRequest GetUserAccount() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetUserAccount, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        internal RestRequest GetCustomerAccount() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetCustomerAccount, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        internal RestRequest GetUserKeyPair() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetUserKeyPair, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        internal RestRequest GetAuthenticatedPing() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetAuthenticatedPing, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddHeader("Accept", "*/*");
            return request;
        }

        #endregion
        #region POST

        internal RestRequest SetUserKeyPair(ApiUserKeyPair apiUserKeyPair) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostUserKeyPair, Method.POST);
            SetGeneralRestValues(request, true, apiUserKeyPair);
            return request;
        }

        #endregion
        #region DELETE

        internal RestRequest DeleteUserKeyPair() {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteUserKeyPair, Method.DELETE);
            SetGeneralRestValues(request, true);
            return request;
        }

        #endregion

        #endregion

        #region Nodes-Endpoint

        #region GET

        internal RestRequest GetNodes(long parentNodeId, long? offset = null, long? limit = null, GetNodesFilter filter = null) {
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

        internal RestRequest GetNode(long nodeId) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetNode, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("nodeId", nodeId.ToString());
            return request;
        }

        internal RestRequest GetFileKey(long nodeId) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetFileKey, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("fileId", nodeId.ToString());
            return request;
        }

        internal RestRequest GetSearchNodes(long parentNodeId, string searchString, long offset, long limit, int depthLevel = -1, SearchNodesFilter filter = null, SearchNodesSort sort = null) {
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

        internal RestRequest GetMissingFileKeys(long? fileId, int limit = 10, int offset = 0) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetMissingFileKeys, Method.GET);
            SetGeneralRestValues(request, true);
            if (fileId.HasValue) {
                request.AddQueryParameter("fileId", fileId.ToString());
            }
            request.AddQueryParameter("offset", offset.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        internal RestRequest GetRecycleBin(long parentRoomId, long? offset = null, long? limit = null) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetRecycleBin, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("roomId", parentRoomId);
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        internal RestRequest GetPreviousVersions(long nodeId, string type, string nodeName, long? offset = null, long? limit = null) {
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

        internal RestRequest GetPreviousVersion(long previoudNodeId) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetPreviousVersion, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("previoudNodeId", previoudNodeId);
            return request;
        }

        internal RestRequest GetRoomEvents(long roomId, DateTime? dateStart = null, DateTime? dateEnd = null, EventStatus? status = null, int? type = null, long? userId = null, long? offset = null, long? limit = null, EventLogsSort sort = null) {
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

        internal RestRequest GetRoomGroups(long roomId, long? offset = null, long? limit = null, GetRoomGroupsFilter filter = null) {
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

        internal RestRequest GetRoomUsers(long roomId, long? offset = null, long? limit = null, GetRoomUsersFilter filter = null) {
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

        internal RestRequest GetRoomPending(long roomId, long? offset = null, long? limit = null, GetRoomPendingFilter filter = null, PendingAssignmentsSort sort = null) {
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

        internal RestRequest PostRoom(ApiCreateRoomRequest roomParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostRoom, Method.POST);
            SetGeneralRestValues(request, true, roomParams);
            return request;
        }

        internal RestRequest PostFolder(ApiCreateFolderRequest folderParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostFolder, Method.POST);
            SetGeneralRestValues(request, true, folderParams);
            return request;
        }

        internal RestRequest PostFileDownload(long fileId) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostCreateFileDownload, Method.POST);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("fileId", fileId);
            return request;
        }

        internal RestRequest PostCreateFileUpload(ApiCreateFileUpload uploadParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostCreateFileUpload, Method.POST);
            SetGeneralRestValues(request, true, uploadParams);
            return request;
        }

        internal RestRequest PostCopyNodes(long targetNodeId, ApiCopyNodesRequest copyParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostCopyNodes, Method.POST);
            SetGeneralRestValues(request, true, copyParams);
            request.AddUrlSegment("nodeId", targetNodeId);
            return request;
        }

        internal RestRequest PostMoveNodes(long targetNodeId, ApiMoveNodesRequest moveParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostMoveNodes, Method.POST);
            SetGeneralRestValues(request, true, moveParams);
            request.AddUrlSegment("nodeId", targetNodeId);
            return request;
        }

        internal RestRequest PostMissingFileKeys(ApiSetUserFileKeysRequest fileKeyParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostMissingFileKeys, Method.POST);
            SetGeneralRestValues(request, true, fileKeyParams);
            return request;
        }

        internal RestRequest PostFavorite(long nodeId) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostFavorite, Method.POST);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("nodeId", nodeId);
            return request;
        }

        internal RestRequest PostRestoreNodeVersion(ApiRestorePreviousVersionsRequest restoreParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostRestoreNodeVersion, Method.POST);
            SetGeneralRestValues(request, true, restoreParams);
            return request;
        }

        #endregion
        #region PUT

        internal RestRequest PutRoom(long roomId, ApiUpdateRoomRequest roomParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutRoom, Method.PUT);
            SetGeneralRestValues(request, true, roomParams);
            request.AddUrlSegment("roomId", roomId);
            return request;
        }

        internal RestRequest PutRoomConfig(long roomId, ApiConfigRoomRequest roomParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutRoomConfig, Method.PUT);
            SetGeneralRestValues(request, true, roomParams);
            request.AddUrlSegment("roomId", roomId);
            return request;
        }

        internal RestRequest PutRoomGroups(long roomId, ApiRoomGroupsAddBatchRequest roomGroupParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutRoomGroups, Method.PUT);
            SetGeneralRestValues(request, true, roomGroupParams);
            request.AddUrlSegment("roomId", roomId);
            return request;
        }

        internal RestRequest PutRoomUsers(long roomId, ApiRoomUsersAddBatchRequest roomUserParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutRoomUsers, Method.PUT);
            SetGeneralRestValues(request, true, roomUserParams);
            request.AddUrlSegment("roomId", roomId);
            return request;
        }

        internal RestRequest PutEnableRoomEncryption(long roomId, ApiEnableRoomEncryptionRequest encryptionParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutEnableRoomEncryption, Method.PUT);
            SetGeneralRestValues(request, true, encryptionParams);
            request.AddUrlSegment("roomId", roomId);
            return request;
        }

        internal RestRequest PutFolder(long folderId, ApiUpdateFolderRequest folderParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutFolder, Method.PUT);
            SetGeneralRestValues(request, true, folderParams);
            request.AddUrlSegment("folderId", folderId);
            return request;
        }

        internal RestRequest PutFile(long fileId, ApiUpdateFileRequest fileParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutFileUpdate, Method.PUT);
            SetGeneralRestValues(request, true, fileParams);
            request.AddUrlSegment("fileId", fileId);
            return request;
        }

        internal RestRequest PutCompleteFileUpload(string uploadPath, ApiCompleteFileUpload completeParams) {
            RestRequest request = new RestRequest(uploadPath, Method.PUT);
            SetGeneralRestValues(request, true, completeParams);
            return request;
        }

        #endregion
        #region DELETE

        internal RestRequest DeleteNodes(ApiDeleteNodesRequest deleteParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteNodes, Method.DELETE);
            SetGeneralRestValues(request, true, deleteParams);
            return request;
        }

        internal RestRequest DeleteFavorite(long nodeId) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteFavorite, Method.DELETE);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("nodeId", nodeId);
            return request;
        }

        internal RestRequest DeleteRecycleBin(long parentRoomId) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteRecycleBin, Method.DELETE);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("roomId", parentRoomId);
            return request;
        }

        internal RestRequest DeletePreviousVersion(ApiDeletePreviousVersionsRequest deleteParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeletePreviousVersions, Method.DELETE);
            SetGeneralRestValues(request, true, deleteParams);
            return request;
        }

        internal RestRequest DeleteRoomGroups(long roomId, ApiRoomGroupsDeleteBatchRequest deleteParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteRoomGroups, Method.DELETE);
            SetGeneralRestValues(request, true, deleteParams);
            request.AddUrlSegment("roomId", roomId);
            return request;
        }

        internal RestRequest DeleteRoomUsers(long roomId, ApiRoomUsersDeleteBatchRequest deleteParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteRoomUsers, Method.DELETE);
            SetGeneralRestValues(request, true, deleteParams);
            request.AddUrlSegment("roomId", roomId);
            return request;
        }

        #endregion
        #region HTTP-Request

        internal WebClient ProvideChunkDownloadWebClient(long offset, long count) {
            DracoonWebClientExtension requestClient = new DracoonWebClientExtension(rangeFrom: offset, rangeTo: (offset + count) - 1);
            SetGeneralWebClientValues(requestClient);
            return requestClient;
        }

        internal WebClient ProvideChunkUploadWebClient(int chunkLength, long offset, string formDataBoundary, string totalFileSize) {
            DracoonWebClientExtension requestClient = new DracoonWebClientExtension();
            requestClient.Headers.Add(HttpRequestHeader.ContentRange, "bytes " + offset + "-" + (offset + chunkLength) + "/" + totalFileSize);
            requestClient.Headers.Add(HttpRequestHeader.ContentType, "multipart/form-data; boundary=" + formDataBoundary);
            SetGeneralWebClientValues(requestClient);
            return requestClient;
        }

        #endregion

        #endregion

        #region Share-Endpoint

        #region GET

        internal RestRequest GetDownloadShares(long? offset, long? limit, GetDownloadSharesFilter filter = null, SharesSort sort = null) {
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

        internal RestRequest GetUploadShares(long? offset, long? limit, GetUploadSharesFilter filter = null, SharesSort sort = null) {
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

        internal RestRequest PostCreateDownloadShare(ApiCreateDownloadShareRequest downloadShareParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostCreateDownloadShare, Method.POST);
            SetGeneralRestValues(request, true, downloadShareParams);
            return request;
        }

        internal RestRequest PostCreateUploadShare(ApiCreateUploadShareRequest uploadShareParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostCreateUploadShare, Method.POST);
            SetGeneralRestValues(request, true, uploadShareParams);
            return request;
        }

        #endregion
        #region DELETE

        internal RestRequest DeleteDownloadShare(long shareId) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteDownloadShare, Method.DELETE);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("shareId", shareId.ToString());
            return request;
        }

        internal RestRequest DeleteUploadShare(long shareId) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteUploadShare, Method.DELETE);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("shareId", shareId.ToString());
            return request;
        }

        #endregion

        #endregion

        #region OAuth-Endpoint

        #region POST

        internal RestRequest PostOAuthToken(string clientId, string clientSecret, string grantType, string code) {
            RestRequest request = new RestRequest(OAuthConfig.OAuthPostAuthToken, Method.POST);
            SetGeneralRestValues(request, false);
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(clientId + ":" + clientSecret)));
            request.AddParameter("grant_type", grantType, ParameterType.GetOrPost);
            request.AddParameter("code", code, ParameterType.GetOrPost);
            return request;
        }

        internal RestRequest PostOAuthRefresh(string clientId, string clientSecret, string grantType, string refreshToken) {
            RestRequest request = new RestRequest(OAuthConfig.OAuthPostRefreshToken, Method.POST);
            SetGeneralRestValues(request, false);
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(clientId + ":" + clientSecret)));
            request.AddParameter("grant_type", grantType, ParameterType.GetOrPost);
            request.AddParameter("refresh_token", refreshToken, ParameterType.GetOrPost);
            return request;
        }

        #endregion

        #endregion

        #region Config-Endpoint

        #region GET

        internal RestRequest GetGeneralSettings() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetGeneralConfig, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        internal RestRequest GetInfrastructureSettings() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetInfrastructureConfig, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        internal RestRequest GetDefaultsSettings() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetDefaultsConfig, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        #endregion

        #endregion

        #region System-Settings-Endpoint

        #region GET

        internal RestRequest GetAuthenticationSettings() {
            RestRequest request = new RestRequest(ApiConfig.ApiGetAuthenticationConfig, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        #endregion

        #endregion

        #region Groups-Endpoint

        #region GET

        internal RestRequest GetGroups(long? offset = null, long? limit = null, GetGroupsFilter filter = null, GroupsSort sort = null) {
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

        internal RestRequest GetGroup(long groupId) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetGroup, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("groupId", groupId.ToString());
            return request;
        }

        internal RestRequest GetGroupLastAdminRooms(long groupId) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetGroupLastAdminRooms, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("groupId", groupId.ToString());
            return request;
        }

        internal RestRequest GetGroupRoles(long groupId) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetGroupRoles, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("groupId", groupId.ToString());
            return request;
        }

        internal RestRequest GetGroupUsers(long groupId, long? offset = null, long? limit = null, GetGroupUsersFilter filter = null) {
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

        internal RestRequest PostGroup(ApiCreateGroupRequest groupParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostGroup, Method.POST);
            SetGeneralRestValues(request, true, groupParams);
            return request;
        }

        internal RestRequest PostGroupUser(long groupId, ApiChangeGroupMembersRequest groupUsersParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostGroupUser, Method.POST);
            SetGeneralRestValues(request, true, groupUsersParams);
            request.AddUrlSegment("groupId", groupId.ToString());
            return request;
        }

        #endregion
        #region PUT

        internal RestRequest PutGroup(long groupId, ApiUpdateGroupRequest groupParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutGroup, Method.PUT);
            SetGeneralRestValues(request, true, groupParams);
            request.AddUrlSegment("groupId", groupId.ToString());
            return request;
        }

        #endregion
        #region DELETE


        internal RestRequest DeleteGroup(long groupId) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteGroup, Method.DELETE);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("groupId", groupId.ToString());
            return request;
        }

        internal RestRequest DeleteGroupUsers(long groupId, ApiChangeGroupMembersRequest deleteUsersParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteGroupUsers, Method.DELETE);
            SetGeneralRestValues(request, true, deleteUsersParams);
            request.AddUrlSegment("groupId", groupId.ToString());
            return request;
        }

        #endregion

        #endregion

        #region Users-Endpoint

        #region GET

        internal RestRequest GetUsers(bool? includeAttributes = null, long? offset = null, long? limit = null, GetUsersFilter filter = null, UsersSort sort = null) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetUsers, Method.GET);
            SetGeneralRestValues(request, true);
            AddFilters(filter, request);
            AddSort(sort, request);
            AddFlag(request, "include_attributes", includeAttributes);
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        internal RestRequest GetUser(long userId, bool? effectiveRoles = null) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetUser, Method.GET);
            SetGeneralRestValues(request, true);
            AddFlag(request, "effective_roles", effectiveRoles);
            request.AddUrlSegment("userId", userId.ToString());
            return request;
        }

        internal RestRequest GetUserGroups(long userId, long? offset = null, long? limit = null, GetUserGroupsFilter filter = null) {
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

        internal RestRequest GetUserLastAdminRooms(long userId) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetUserLastAdminRooms, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("userId", userId.ToString());
            return request;
        }

        internal RestRequest GetUserRoles(long userId) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetUserRoles, Method.GET);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("userId", userId.ToString());
            return request;
        }

        internal RestRequest GetUserUserAttributes(long userId, long? offset = null, long? limit = null, GetUserAttributesFilter filter = null, UserAttributesSort sort = null) {
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

        internal RestRequest PostUser(ApiCreateUserRequest userParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostUser, Method.POST);
            SetGeneralRestValues(request, true, userParams);
            return request;
        }

        internal RestRequest PostUserUserAttributes(long userId, ApiUserAttributes userAttributeParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPostUserAttributes, Method.POST);
            SetGeneralRestValues(request, true, userAttributeParams);
            request.AddUrlSegment("userId", userId.ToString());
            return request;
        }

        #endregion
        #region PUT

        internal RestRequest PutUser(long userId, ApiUpdateUserRequest userParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutUser, Method.PUT);
            SetGeneralRestValues(request, true, userParams);
            request.AddUrlSegment("userId", userId.ToString());
            return request;
        }

        internal RestRequest PutUserUserAttributes(long userId, ApiUserAttributes userAttributeParams) {
            RestRequest request = new RestRequest(ApiConfig.ApiPutUserUserAttributes, Method.PUT);
            SetGeneralRestValues(request, true, userAttributeParams);
            request.AddUrlSegment("userId", userId.ToString());
            return request;
        }

        #endregion
        #region DELETE

        internal RestRequest DeleteUser(long userId) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteUser, Method.DELETE);
            SetGeneralRestValues(request, true);
            request.AddUrlSegment("userId", userId.ToString());
            return request;
        }

        internal RestRequest DeleteUserUserAttribute(long userId, string userAttributeKey) {
            RestRequest request = new RestRequest(ApiConfig.ApiDeleteUserUserAttribute, Method.DELETE);
            request.AddUrlSegment("userId", userId.ToString());
            request.AddUrlSegment("key", userAttributeKey);
            return request;
        }

        #endregion

        #endregion

        #region EventLog-Endpoint

        #region GET

        internal RestRequest GetAuditNodes(long? offset = null, long? limit = null, GetAuditNodesFilter filter = null, AuditNodesSort sort = null) {
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

        internal RestRequest GetEvents(DateTime? dateStart = null, DateTime? dateEnd = null, EventStatus? status = null, int? type = null, long? userId = null, string userClient = null, long? offset = null, long? limit = null, EventLogsSort sort = null) {
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

        internal RestRequest GetOperations(bool? isDeprecated = null) {
            RestRequest request = new RestRequest(ApiConfig.ApiGetOperations, Method.GET);
            SetGeneralRestValues(request, true);
            AddFlag(request, "is_deprecated", isDeprecated);
            return request;
        }

        #endregion

        #endregion

        #region Branding-Endpoint (Branding API)

        internal RestRequest GetBranding() {
            RestRequest request = new RestRequest(ApiConfig.BrandingApiGetBranding, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        internal RestRequest GetBrandingServerVersion() {
            RestRequest request = new RestRequest(ApiConfig.BrandingApiGetBrandingServerVersion, Method.GET);
            SetGeneralRestValues(request, true);
            return request;
        }

        #endregion
    }
}
