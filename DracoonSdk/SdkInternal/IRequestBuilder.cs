using System;
using System.Net;
using Dracoon.Sdk.Filter;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.ApiModel.Requests;
using Dracoon.Sdk.Sort;
using RestSharp;

namespace Dracoon.Sdk.SdkInternal {
    internal interface IRequestBuilder {
        #region Public

        IRestRequest GetServerVersion();

        IRestRequest GetServerTime();

        #endregion

        #region User

        IRestRequest GetUserAccount();

        IRestRequest GetCustomerAccount();

        IRestRequest GetUserKeyPair();

        IRestRequest GetAuthenticatedPing();

        IRestRequest GetAvatar();

        IRestRequest SetUserKeyPair(ApiUserKeyPair apiUserKeyPair);

        IRestRequest DeleteUserKeyPair();

        IRestRequest GetUserProfileAttributes();

        IRestRequest GetUserProfileAttribute(string attributeKey);

        IRestRequest PutUserProfileAttributes(ApiAddOrUpdateAttributeRequest addOrUpdateParam);

        IRestRequest DeleteUserProfileAttributes(string attributeKey);

        IRestRequest DeleteAvatar();

        WebClient ProvideAvatarDownloadWebClient();

        WebClient ProvideAvatarUploadWebClient(string formDataBoundary);

        #endregion

        #region Nodes

        IRestRequest GetNodes(long parentNodeId, long? offset = null, long? limit = null, GetNodesFilter filter = null);

        IRestRequest GetNode(long nodeId);

        IRestRequest GetFileKey(long nodeId);

        IRestRequest GetSearchNodes(long parentNodeId, string searchString, long offset, long limit, int depthLevel = -1,
            SearchNodesFilter filter = null, SearchNodesSort sort = null);

        IRestRequest GetMissingFileKeys(long? fileId, int limit = 10, int offset = 0);

        IRestRequest GetRecycleBin(long parentRoomId, long? offset = null, long? limit = null);

        IRestRequest GetPreviousVersions(long nodeId, string type, string nodeName, long? offset = null, long? limit = null);

        IRestRequest GetPreviousVersion(long previousNodeId);

        IRestRequest GetS3Status(string uploadId);

        IRestRequest GetRoomEvents(long roomId, DateTime? dateStart = null, DateTime? dateEnd = null, EventStatus? status = null, int? type = null, long? userId = null, long? offset = null, long? limit = null, EventLogsSort sort = null);

        IRestRequest GetRoomGroups(long roomId, long? offset = null, long? limit = null, GetRoomGroupsFilter filter = null);

        IRestRequest GetRoomUsers(long roomId, long? offset = null, long? limit = null, GetRoomUsersFilter filter = null);

        IRestRequest GetRoomPending(long roomId, long? offset = null, long? limit = null, GetRoomPendingFilter filter = null, PendingAssignmentsSort sort = null);

        IRestRequest PostRoom(ApiCreateRoomRequest roomParams);

        IRestRequest PostFolder(ApiCreateFolderRequest folderParams);

        IRestRequest PostFileDownload(long fileId);

        IRestRequest PostCreateFileUpload(ApiCreateFileUpload uploadParams);

        IRestRequest PostGetS3Urls(string uploadId, ApiGetS3Urls s3UrlParams);

        IRestRequest PostCopyNodes(long targetNodeId, ApiCopyNodesRequest copyParams);

        IRestRequest PostMoveNodes(long targetNodeId, ApiMoveNodesRequest moveParams);

        IRestRequest PostMissingFileKeys(ApiSetUserFileKeysRequest fileKeyParams);

        IRestRequest PostFavorite(long nodeId);

        IRestRequest PostRestoreNodeVersion(ApiRestorePreviousVersionsRequest restoreParams);

        IRestRequest PutRoom(long roomId, ApiUpdateRoomRequest roomParams);

        IRestRequest PutRoomConfig(long roomId, ApiConfigRoomRequest roomParams);

        IRestRequest PutRoomGroups(long roomId, ApiRoomGroupsAddBatchRequest roomGroupParams);

        IRestRequest PutRoomUsers(long roomId, ApiRoomUsersAddBatchRequest roomUserParams);

        IRestRequest PutEnableRoomEncryption(long roomId, ApiEnableRoomEncryptionRequest encryptionParams);

        IRestRequest PutFolder(long folderId, ApiUpdateFolderRequest folderParams);

        IRestRequest PutFile(long fileId, ApiUpdateFileRequest fileParams);

        IRestRequest PutCompleteFileUpload(string uploadPath, ApiCompleteFileUpload completeParams);

        IRestRequest PutCompleteS3FileUpload(string uploadId, ApiCompleteFileUpload completeParams);

        IRestRequest DeleteNodes(ApiDeleteNodesRequest deleteParams);

        IRestRequest DeleteFavorite(long nodeId);

        IRestRequest DeleteRecycleBin(long parentRoomId);

        IRestRequest DeletePreviousVersion(ApiDeletePreviousVersionsRequest deleteParams);

        IRestRequest DeleteRoomGroups(long roomId, ApiRoomGroupsDeleteBatchRequest deleteParams);

        IRestRequest DeleteRoomUsers(long roomId, ApiRoomUsersDeleteBatchRequest deleteParams);

        WebClient ProvideChunkDownloadWebClient(long offset, long count);

        WebClient ProvideChunkUploadWebClient(int chunkLength, long offset, string formDataBoundary, string totalFileSize);

        WebClient ProvideS3ChunkUploadWebClient();

        #endregion

        #region Share

        IRestRequest GetDownloadShares(long? offset, long? limit, GetDownloadSharesFilter filter = null, SharesSort sort = null);

        IRestRequest GetUploadShares(long? offset, long? limit, GetUploadSharesFilter filter = null, SharesSort sort = null);

        IRestRequest PostCreateDownloadShare(ApiCreateDownloadShareRequest downloadShareParams);

        IRestRequest PostCreateUploadShare(ApiCreateUploadShareRequest uploadShareParams);

        IRestRequest DeleteDownloadShare(long shareId);

        IRestRequest DeleteUploadShare(long shareId);

        #endregion

        #region OAuth

        IRestRequest PostOAuthToken(string clientId, string clientSecret, string grantType, string code);

        IRestRequest PostOAuthRefresh(string clientId, string clientSecret, string grantType, string refreshToken);

        #endregion

        #region Config

        IRestRequest GetGeneralSettings();

        IRestRequest GetInfrastructureSettings();

        IRestRequest GetDefaultsSettings();

        IRestRequest GetPasswordPolicies();

        #endregion

        #region Resources

        IRestRequest GetUserAvatar(long userId, string avatarUuid);

        #endregion

        #region System Settings

        IRestRequest GetAuthenticationSettings();

        #endregion

        #region Groups

        IRestRequest GetGroups(long? offset = null, long? limit = null, GetGroupsFilter filter = null, GroupsSort sort = null);

        IRestRequest GetGroup(long groupId);

        IRestRequest GetGroupLastAdminRooms(long groupId);

        IRestRequest GetGroupRoles(long groupId);

        IRestRequest GetGroupUsers(long groupId, long? offset = null, long? limit = null, GetGroupUsersFilter filter = null);

        IRestRequest PostGroup(ApiCreateGroupRequest groupParams);

        IRestRequest PostGroupUser(long groupId, ApiChangeGroupMembersRequest groupUsersParams);

        IRestRequest PutGroup(long groupId, ApiUpdateGroupRequest groupParams);

        IRestRequest DeleteGroup(long groupId);

        IRestRequest DeleteGroupUsers(long groupId, ApiChangeGroupMembersRequest deleteUsersParams);

        #endregion

        #region Users

        IRestRequest GetUsers(bool? includeAttributes = null, long? offset = null, long? limit = null, GetUsersFilter filter = null, UsersSort sort = null);

        IRestRequest GetUser(long userId, bool? effectiveRoles = null);

        IRestRequest GetUserGroups(long userId, long? offset = null, long? limit = null, GetUserGroupsFilter filter = null);

        IRestRequest GetUserLastAdminRooms(long userId);

        IRestRequest GetUserRoles(long userId);

        IRestRequest GetUserUserAttributes(long userId, long? offset = null, long? limit = null, GetUserAttributesFilter filter = null, UserAttributesSort sort = null);

        IRestRequest PostUser(ApiCreateUserRequest userParams);

        IRestRequest PostUserUserAttributes(long userId, ApiUserAttributes userAttributeParams);

        IRestRequest PutUser(long userId, ApiUpdateUserRequest userParams);

        IRestRequest PutUserUserAttributes(long userId, ApiUserAttributes userAttributeParams);

        IRestRequest DeleteUser(long userId);

        IRestRequest DeleteUserUserAttribute(long userId, string userAttributeKey);

        #endregion

        #region Event Log

        IRestRequest GetAuditNodes(long? offset = null, long? limit = null, GetAuditNodesFilter filter = null, AuditNodesSort sort = null);

        IRestRequest GetEvents(DateTime? dateStart = null, DateTime? dateEnd = null, EventStatus? status = null, int? type = null, long? userId = null, string userClient = null, long? offset = null, long? limit = null, EventLogsSort sort = null);

        IRestRequest GetOperations(bool? isDeprecated = null);

        #endregion

        #region Branding (Branding API)

        IRestRequest GetBranding();

        IRestRequest GetBrandingServerVersion();

        #endregion
    }
}
