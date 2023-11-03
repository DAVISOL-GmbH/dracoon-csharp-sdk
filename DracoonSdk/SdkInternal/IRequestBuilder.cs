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

        RestRequest GetServerVersion();

        RestRequest GetServerTime();

        RestRequest GetPublicDownloadShare(string accessKey);

        RestRequest GetPublicUploadShare(string accessKey);

        RestRequest GetPublicSystemInfo();

        RestRequest GetPublicSystemActiveDirectoryAuth();

        RestRequest GetPublicSystemOpenIdAuth();

        #endregion

        #region User

        RestRequest GetUserAccount();

        RestRequest GetCustomerAccount();

        RestRequest GetUserKeyPair(string algorithm);

        RestRequest GetUserKeyPairs();

        RestRequest GetAuthenticatedPing();

        RestRequest GetAvatar();

        RestRequest SetUserKeyPair(ApiUserKeyPair apiUserKeyPair);

        RestRequest DeleteUserKeyPair(string algorithm);

        RestRequest GetUserProfileAttributes();

        RestRequest GetUserProfileAttribute(string attributeKey);

        RestRequest PutUserProfileAttributes(ApiAddOrUpdateAttributeRequest addOrUpdateParam);

        RestRequest DeleteUserProfileAttributes(string attributeKey);

        RestRequest DeleteAvatar();

        WebClient ProvideAvatarDownloadWebClient();

        WebClient ProvideAvatarUploadWebClient(string formDataBoundary);

        RestRequest GetDownloadShareSubscriptions(long? offset, long? limit);

        RestRequest RemoveDownloadShareSubscription(long shareId);

        RestRequest AddDownloadShareSubscription(long shareId);

        RestRequest GetUploadShareSubscriptions(long? offset, long? limit);

        RestRequest RemoveUploadShareSubscription(long shareId);

        RestRequest AddUploadShareSubscription(long shareId);

        #endregion

        #region Nodes

        RestRequest GetNodes(long parentNodeId, long? offset = null, long? limit = null, GetNodesFilter filter = null, GetNodesSort sort = null);

        RestRequest GetNode(long nodeId);

        RestRequest GetFileKey(long nodeId);

        RestRequest GetSearchNodes(long parentNodeId, string searchString, long offset, long limit, int depthLevel = -1,
            SearchNodesFilter filter = null, SearchNodesSort sort = null);

        RestRequest GetMissingFileKeys(long? fileId, int limit = 10, int offset = 0);

        RestRequest GetRecycleBin(long parentRoomId, long? offset, long? limit);

        RestRequest GetPreviousVersions(long nodeId, string type, string nodeName, long? offset, long? limit);

        RestRequest GetPreviousVersion(long previousNodeId);

        RestRequest GetS3Status(string uploadId);

        RestRequest GetRoomEvents(long roomId, DateTime? dateStart, DateTime? dateEnd, EventStatus? status, int? type, long? userId, long? offset, long? limit, EventLogsSort sort);

        RestRequest GetRoomGroups(long roomId, long? offset, long? limit, GetRoomGroupsFilter filter);

        RestRequest GetRoomUsers(long roomId, long? offset, long? limit, GetRoomUsersFilter filter);

        RestRequest GetRoomPending(long roomId, long? offset, long? limit, GetRoomPendingFilter filter, PendingAssignmentsSort sort);

        RestRequest PostRoom(ApiCreateRoomRequest roomParams);

        RestRequest PostFolder(ApiCreateFolderRequest folderParams);

        RestRequest PostFileDownload(long fileId);

        RestRequest PostCreateFileUpload(ApiCreateFileUpload uploadParams);

        RestRequest PostGetS3Urls(string uploadId, ApiGetS3Urls s3UrlParams);

        RestRequest PostCopyNodes(long targetNodeId, ApiCopyNodesRequest copyParams);

        RestRequest PostMoveNodes(long targetNodeId, ApiMoveNodesRequest moveParams);

        RestRequest PostMissingFileKeys(ApiSetUserFileKeysRequest fileKeyParams);

        RestRequest PostFavorite(long nodeId);

        RestRequest PostRestoreNodeVersion(ApiRestorePreviousVersionsRequest restoreParams);

        RestRequest PutRoom(long roomId, ApiUpdateRoomRequest roomParams);

        RestRequest PutRoomConfig(long roomId, ApiConfigRoomRequest roomParams);

        RestRequest PutRoomGroups(long roomId, ApiRoomGroupsAddBatchRequest roomGroupParams);

        RestRequest PutRoomUsers(long roomId, ApiRoomUsersAddBatchRequest roomUserParams);

        RestRequest PutEnableRoomEncryption(long roomId, ApiEnableRoomEncryptionRequest encryptionParams);

        RestRequest PutFolder(long folderId, ApiUpdateFolderRequest folderParams);

        RestRequest PutFile(long fileId, ApiUpdateFileRequest fileParams);

        RestRequest PutCompleteFileUpload(string uploadPath, ApiCompleteFileUpload completeParams);

        RestRequest PutCompleteS3FileUpload(string uploadId, ApiCompleteFileUpload completeParams);

        RestRequest DeleteNodes(ApiDeleteNodesRequest deleteParams);

        RestRequest DeleteFavorite(long nodeId);

        RestRequest DeleteRecycleBin(long parentRoomId);

        RestRequest DeletePreviousVersion(ApiDeletePreviousVersionsRequest deleteParams);

        RestRequest DeleteRoomGroups(long roomId, ApiRoomGroupsDeleteBatchRequest deleteParams);

        RestRequest DeleteRoomUsers(long roomId, ApiRoomUsersDeleteBatchRequest deleteParams);

        WebClient ProvideChunkDownloadWebClient(long offset, long count);

        WebClient ProvideChunkUploadWebClient(int chunkLength, long offset, string formDataBoundary, string totalFileSize);

        WebClient ProvideS3ChunkUploadWebClient();

        RestRequest GenerateVirusProtectionInfo(ApiGenerateVirusProtectionInfoRequest generateParams);

        RestRequest DeleteMaliciousFile(long fileId);

        #endregion

        #region Share

        RestRequest GetDownloadShares(long? offset, long? limit, GetDownloadSharesFilter filter, SharesSort sort);

        RestRequest GetUploadShares(long? offset, long? limit, GetUploadSharesFilter filter, SharesSort sort);

        RestRequest PostCreateDownloadShare(ApiCreateDownloadShareRequest downloadShareParams);

        RestRequest PostCreateUploadShare(ApiCreateUploadShareRequest uploadShareParams);

        RestRequest PostMailDownloadShare(long shareId, ApiMailShareInfoRequest mailParams);

        RestRequest PostMailUploadShare(long shareId, ApiMailShareInfoRequest mailParams);

        RestRequest DeleteDownloadShare(long shareId);

        RestRequest DeleteUploadShare(long shareId);

        #endregion

        #region OAuth

        RestRequest PostOAuthToken(string clientId, string clientSecret, string grantType, string code);

        RestRequest PostOAuthRefresh(string clientId, string clientSecret, string grantType, string refreshToken);

        #endregion

        #region Config

        RestRequest GetGeneralSettings();

        RestRequest GetInfrastructureSettings();

        RestRequest GetDefaultsSettings();

        RestRequest GetPasswordPolicies();

        RestRequest GetAlgorithms();

        RestRequest GetClassificationPolicies();

        #endregion

        #region Resources

        RestRequest GetUserAvatar(long userId, string avatarUuid);

        #endregion

        #region System Settings

        RestRequest GetGeneralConfiguration();

        RestRequest UpdateGeneralConfiguration(ApiUpdateSystemGeneralConfigRequest updateRequest);

        RestRequest GetAuthenticationConfiguration();

        RestRequest GetAuthActiveDirectoryConfigurations();

        RestRequest GetAuthOpenIdIdpConfigurations();

        RestRequest GetAuthRadiusConfiguration();

        RestRequest GetOAuthClientConfigurations(GetOAuthClientsFilter filter);

        RestRequest GetOAuthClientConfiguration(string clientId);

        RestRequest CreateOAuthClientConfiguration(ApiCreateOAuthClientRequest createRequest);

        RestRequest UpdateOAuthClientConfiguration(string clientId, ApiUpdateOAuthClientRequest updateRequest);

        RestRequest DeleteOAuthClientConfiguration(string clientId);

        #endregion

        #region Groups

        RestRequest GetGroups(long? offset, long? limit, GetGroupsFilter filter, GroupsSort sort);

        RestRequest GetGroup(long groupId);

        RestRequest GetGroupLastAdminRooms(long groupId);

        RestRequest GetGroupRoles(long groupId);

        RestRequest GetGroupUsers(long groupId, long? offset, long? limit, GetGroupUsersFilter filter);

        RestRequest PostGroup(ApiCreateGroupRequest groupParams);

        RestRequest PostGroupUser(long groupId, ApiChangeMembersRequest groupUsersParams);

        RestRequest PutGroup(long groupId, ApiUpdateGroupRequest groupParams);

        RestRequest DeleteGroup(long groupId);

        RestRequest DeleteGroupUsers(long groupId, ApiChangeMembersRequest deleteUsersParams);

        #endregion

        #region Users

        RestRequest GetUsers(bool? includeAttributes, bool? includeRoles, bool? includeHasManageableRooms, long? offset, long? limit, GetUsersFilter filter, UsersSort sort);

        RestRequest GetUser(long userId, bool? effectiveRoles = null);

        RestRequest GetUserGroups(long userId, long? offset, long? limit, GetUserGroupsFilter filter);

        RestRequest GetUserLastAdminRooms(long userId);

        RestRequest GetUserRoles(long userId);

        RestRequest GetUserUserAttributes(long userId, long? offset, long? limit, GetUserAttributesFilter filter, UserAttributesSort sort);

        RestRequest PostUser(ApiCreateUserRequest userParams);

        RestRequest PostUserUserAttributes(long userId, ApiUserAttributes userAttributeParams);

        RestRequest PutUser(long userId, ApiUpdateUserRequest userParams);

        RestRequest PutUserUserAttributes(long userId, ApiUserAttributes userAttributeParams);

        RestRequest DeleteUser(long userId);

        RestRequest DeleteUserUserAttribute(long userId, string userAttributeKey);

        #endregion

        #region Roles

        RestRequest GetRoles();

        RestRequest GetRoleGroups(long roleId, long? offset, long? limit, GetUserGroupsFilter filter);

        RestRequest GetRoleUsers(long roleId, long? offset, long? limit, GetGroupUsersFilter filter);

        RestRequest PostRoleGroups(long roleId, ApiChangeMembersRequest addGroupsParams);

        RestRequest PostRoleUsers(long roleId, ApiChangeMembersRequest addUsersParams);

        RestRequest DeleteRoleGroups(long roleId, ApiChangeMembersRequest deleteGroupsParams);

        RestRequest DeleteRoleUsers(long roleId, ApiChangeMembersRequest deleteUsersParams);

        #endregion

        #region Event Log

        RestRequest GetAuditNodes(long? offset, long? limit, GetAuditNodesFilter filter, AuditNodesSort sort);

        RestRequest GetEvents(DateTime? dateStart, DateTime? dateEnd, EventStatus? status, int? type, long? userId, string userClient, long? offset, long? limit, EventLogsSort sort);

        RestRequest GetOperations(bool? isDeprecated);

        #endregion

        #region Branding (Branding API)

        RestRequest GetBranding();

        RestRequest GetBrandingServerVersion();

        #endregion
    }
}
