using Dracoon.Sdk.Filter;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.ApiModel.Requests;
using Dracoon.Sdk.Sort;
using RestSharp;
using System;
using System.Net;

namespace Dracoon.Sdk.SdkInternal {
    internal interface IRequestBuilder {
        #region Public

        IRestRequest GetServerVersion();

        IRestRequest GetServerTime();

        IRestRequest GetPublicDownloadShare(string accessKey);

        IRestRequest GetPublicUploadShare(string accessKey);

        IRestRequest GetPublicSystemInfo();

        IRestRequest GetPublicSystemActiveDirectoryAuth();

        IRestRequest GetPublicSystemOpenIdAuth();

        #endregion

        #region User

        IRestRequest GetUserAccount();

        IRestRequest GetCustomerAccount();

        IRestRequest GetUserKeyPair(string algorithm);

        IRestRequest GetUserKeyPairs();

        IRestRequest GetAuthenticatedPing();

        IRestRequest GetAvatar();

        IRestRequest SetUserKeyPair(ApiUserKeyPair apiUserKeyPair);

        IRestRequest DeleteUserKeyPair(string algorithm);

        IRestRequest GetUserProfileAttributes();

        IRestRequest GetUserProfileAttribute(string attributeKey);

        IRestRequest PutUserProfileAttributes(ApiAddOrUpdateAttributeRequest addOrUpdateParam);

        IRestRequest DeleteUserProfileAttributes(string attributeKey);

        IRestRequest DeleteAvatar();

        WebClient ProvideAvatarDownloadWebClient();

        WebClient ProvideAvatarUploadWebClient(string formDataBoundary);

        IRestRequest GetDownloadShareSubscriptions(long? offset, long? limit);

        IRestRequest RemoveDownloadShareSubscription(long shareId);

        IRestRequest AddDownloadShareSubscription(long shareId);

        IRestRequest GetUploadShareSubscriptions(long? offset, long? limit);

        IRestRequest RemoveUploadShareSubscription(long shareId);

        IRestRequest AddUploadShareSubscription(long shareId);

        #endregion

        #region Nodes

        IRestRequest GetNodes(long parentNodeId, long? offset = null, long? limit = null, GetNodesFilter filter = null, GetNodesSort sort = null);

        IRestRequest GetNode(long nodeId);

        IRestRequest GetFileKey(long nodeId);

        IRestRequest GetSearchNodes(long parentNodeId, string searchString, long offset, long limit, int depthLevel = -1,
            SearchNodesFilter filter = null, SearchNodesSort sort = null);

        IRestRequest GetMissingFileKeys(long? fileId, int limit = 10, int offset = 0);

        IRestRequest GetRecycleBin(long parentRoomId, long? offset, long? limit);

        IRestRequest GetPreviousVersions(long nodeId, string type, string nodeName, long? offset, long? limit);

        IRestRequest GetPreviousVersion(long previousNodeId);

        IRestRequest GetS3Status(string uploadId);

        IRestRequest GetRoomEvents(long roomId, DateTime? dateStart, DateTime? dateEnd, EventStatus? status, int? type, long? userId, long? offset, long? limit, EventLogsSort sort);

        IRestRequest GetRoomGroups(long roomId, long? offset, long? limit, GetRoomGroupsFilter filter);

        IRestRequest GetRoomUsers(long roomId, long? offset, long? limit, GetRoomUsersFilter filter);

        IRestRequest GetRoomPending(long roomId, long? offset, long? limit, GetRoomPendingFilter filter, PendingAssignmentsSort sort);

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

        IRestRequest GenerateVirusProtectionInfo(ApiGenerateVirusProtectionInfoRequest generateParams);

        IRestRequest DeleteMaliciousFile(long fileId);

        #endregion

        #region Share

        IRestRequest GetDownloadShares(long? offset, long? limit, GetDownloadSharesFilter filter, SharesSort sort);

        IRestRequest GetUploadShares(long? offset, long? limit, GetUploadSharesFilter filter, SharesSort sort);

        IRestRequest PostCreateDownloadShare(ApiCreateDownloadShareRequest downloadShareParams);

        IRestRequest PostCreateUploadShare(ApiCreateUploadShareRequest uploadShareParams);

        IRestRequest PostMailDownloadShare(long shareId, ApiMailShareInfoRequest mailParams);

        IRestRequest PostMailUploadShare(long shareId, ApiMailShareInfoRequest mailParams);

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

        IRestRequest GetAlgorithms();

        IRestRequest GetClassificationPolicies();

        #endregion

        #region Resources

        IRestRequest GetUserAvatar(long userId, string avatarUuid);

        #endregion

        #region System Settings

        IRestRequest GetGeneralConfiguration();

        IRestRequest UpdateGeneralConfiguration(ApiUpdateSystemGeneralConfigRequest updateRequest);

        IRestRequest GetAuthenticationConfiguration();

        IRestRequest GetAuthActiveDirectoryConfigurations();

        IRestRequest GetAuthOpenIdIdpConfigurations();

        IRestRequest GetAuthRadiusConfiguration();

        IRestRequest GetOAuthClientConfigurations(GetOAuthClientsFilter filter);

        IRestRequest GetOAuthClientConfiguration(string clientId);

        IRestRequest CreateOAuthClientConfiguration(ApiCreateOAuthClientRequest createRequest);

        IRestRequest UpdateOAuthClientConfiguration(string clientId, ApiUpdateOAuthClientRequest updateRequest);

        IRestRequest DeleteOAuthClientConfiguration(string clientId);

        #endregion

        #region Groups

        IRestRequest GetGroups(long? offset, long? limit, GetGroupsFilter filter, GroupsSort sort);

        IRestRequest GetGroup(long groupId);

        IRestRequest GetGroupLastAdminRooms(long groupId);

        IRestRequest GetGroupRoles(long groupId);

        IRestRequest GetGroupUsers(long groupId, long? offset, long? limit, GetGroupUsersFilter filter);

        IRestRequest PostGroup(ApiCreateGroupRequest groupParams);

        IRestRequest PostGroupUser(long groupId, ApiChangeMembersRequest groupUsersParams);

        IRestRequest PutGroup(long groupId, ApiUpdateGroupRequest groupParams);

        IRestRequest DeleteGroup(long groupId);

        IRestRequest DeleteGroupUsers(long groupId, ApiChangeMembersRequest deleteUsersParams);

        #endregion

        #region Users

        IRestRequest GetUsers(bool? includeAttributes, bool? includeRoles, bool? includeHasManageableRooms, long? offset, long? limit, GetUsersFilter filter, UsersSort sort);

        IRestRequest GetUser(long userId, bool? effectiveRoles = null);

        IRestRequest GetUserGroups(long userId, long? offset, long? limit, GetUserGroupsFilter filter);

        IRestRequest GetUserLastAdminRooms(long userId);

        IRestRequest GetUserRoles(long userId);

        IRestRequest GetUserUserAttributes(long userId, long? offset, long? limit, GetUserAttributesFilter filter, UserAttributesSort sort);

        IRestRequest PostUser(ApiCreateUserRequest userParams);

        IRestRequest PostUserUserAttributes(long userId, ApiUserAttributes userAttributeParams);

        IRestRequest PutUser(long userId, ApiUpdateUserRequest userParams);

        IRestRequest PutUserUserAttributes(long userId, ApiUserAttributes userAttributeParams);

        IRestRequest DeleteUser(long userId);

        IRestRequest DeleteUserUserAttribute(long userId, string userAttributeKey);

        #endregion

        #region Roles

        IRestRequest GetRoles();

        IRestRequest GetRoleGroups(long roleId, long? offset, long? limit, GetUserGroupsFilter filter);

        IRestRequest GetRoleUsers(long roleId, long? offset, long? limit, GetGroupUsersFilter filter);

        IRestRequest PostRoleGroups(long roleId, ApiChangeMembersRequest addGroupsParams);

        IRestRequest PostRoleUsers(long roleId, ApiChangeMembersRequest addUsersParams);

        IRestRequest DeleteRoleGroups(long roleId, ApiChangeMembersRequest deleteGroupsParams);

        IRestRequest DeleteRoleUsers(long roleId, ApiChangeMembersRequest deleteUsersParams);

        #endregion

        #region Event Log

        IRestRequest GetAuditNodes(long? offset, long? limit, GetAuditNodesFilter filter, AuditNodesSort sort);

        IRestRequest GetEvents(DateTime? dateStart, DateTime? dateEnd, EventStatus? status, int? type, long? userId, string userClient, long? offset, long? limit, EventLogsSort sort);

        IRestRequest GetOperations(bool? isDeprecated);

        #endregion

        #region Branding (Branding API)

        IRestRequest GetBranding();

        IRestRequest GetBrandingServerVersion();

        #endregion
    }
}
