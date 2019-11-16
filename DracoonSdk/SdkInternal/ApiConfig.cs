using System;
using System.Text;

namespace Dracoon.Sdk.SdkInternal {
    internal class ApiConfig {

        internal const string MinimumApiVersion = "4.6.0";
        internal const string ApiPrefix = "api/v4";
        internal const string AuthorizationHeader = "Authorization";
        internal static readonly Encoding encoding = Encoding.UTF8;

        #region Public-Endpoint

        #region GET

        internal const string ApiGetServerVersion = ApiPrefix + "/public/software/version";
        internal const string ApiGetServerTime = ApiPrefix + "/public/time";

        #endregion

        #endregion

        #region User-Endpoint

        #region GET

        internal const string ApiGetUserAccount = ApiPrefix + "/user/account";
        internal const string ApiGetCustomerAccount = ApiPrefix + "/user/account/customer";
        internal const string ApiGetUserKeyPair = ApiPrefix + "/user/account/keypair";
        internal const string ApiGetAuthenticatedPing = ApiPrefix + "/user/ping";

        #endregion
        #region POST

        internal const string ApiPostUserKeyPair = ApiPrefix + "/user/account/keypair";

        #endregion
        #region DELETE

        internal const string ApiDeleteUserKeyPair = ApiPrefix + "/user/account/keypair";

        #endregion

        #endregion

        #region Nodes-Endpoint

        #region GET

        internal const string ApiGetChildNodes = ApiPrefix + "/nodes";
        internal const string ApiGetNode = ApiPrefix + "/nodes/{nodeId}";
        internal const string ApiGetFileKey = ApiPrefix + "/nodes/files/{fileId}/user_file_key";
        internal const string ApiGetFileDownload = ApiPrefix + "/downloads";
        internal const string ApiGetSearchNodes = ApiPrefix + "/nodes/search";
        internal const string ApiGetMissingFileKeys = ApiPrefix + "/nodes/missingFileKeys";
        internal const string ApiGetRecycleBin = ApiPrefix + "/nodes/{roomId}/deleted_nodes";
        internal const string ApiGetPreviousVersions = ApiPrefix + "/nodes/{nodeId}/deleted_nodes/versions";
        internal const string ApiGetPreviousVersion = ApiPrefix + "/nodes/deleted_nodes/{previoudNodeId}";
        internal const string ApiGetRoomEvents = ApiPrefix + "/nodes/rooms/{roomId}/events";
        internal const string ApiGetRoomGroups = ApiPrefix + "/nodes/rooms/{roomId}/groups";
        internal const string ApiGetRoomUsers = ApiPrefix + "/nodes/rooms/{roomId}/users";
        internal const string ApiGetRoomPending = ApiPrefix + "/nodes/rooms/{roomId}/pending";

        #endregion
        #region POST

        internal const string ApiPostRoom = ApiPrefix + "/nodes/rooms";
        internal const string ApiPostFolder = ApiPrefix + "/nodes/folders";
        internal const string ApiPostCreateFileDownload = ApiPrefix + "/nodes/files/{fileId}/downloads";
        internal const string ApiPostCreateFileUpload = ApiPrefix + "/nodes/files/uploads";
        internal const string ApiPostCopyNodes = ApiPrefix + "/nodes/{nodeId}/copy_to";
        internal const string ApiPostMoveNodes = ApiPrefix + "/nodes/{nodeId}/move_to";
        internal const string ApiPostMissingFileKeys = ApiPrefix + "/nodes/files/keys";
        internal const string ApiPostFavorite = ApiPrefix + "/nodes/{nodeId}/favorite";
        internal const string ApiPostRestoreNodeVersion = ApiPrefix + "/nodes/deleted_nodes/actions/restore";

        #region Minimum version requirements

        internal const string ApiUseHomeDefaultClassificationMinApiVersion = "4.9.0";

        #endregion

        #endregion
        #region PUT

        internal const string ApiPutRoom = ApiPrefix + "/nodes/rooms/{roomId}";
        internal const string ApiPutRoomConfig = ApiPrefix + "/nodes/rooms/{roomId}/config";
        internal const string ApiPutRoomGroups = ApiPrefix + "/nodes/rooms/{roomId}/groups";
        internal const string ApiPutRoomUsers = ApiPrefix + "/nodes/rooms/{roomId}/users";
        internal const string ApiPutFolder = ApiPrefix + "/nodes/folders/{folderId}";
        internal const string ApiPutFileUpdate = ApiPrefix + "/nodes/files/{fileId}";
        internal const string ApiPutEnableRoomEncryption = ApiPrefix + "/nodes/rooms/{roomId}/encrypt";

        #endregion
        #region DELETE

        internal const string ApiDeleteNodes = ApiPrefix + "/nodes";
        internal const string ApiDeleteFavorite = ApiPrefix + "/nodes/{nodeId}/favorite";
        internal const string ApiDeleteRecycleBin = ApiPrefix + "/nodes/{roomId}/deleted_nodes";
        internal const string ApiDeletePreviousVersions = ApiPrefix + "/nodes/deleted_nodes";
        internal const string ApiDeleteRoomGroups = ApiPrefix + "/nodes/rooms/{roomId}/groups";
        internal const string ApiDeleteRoomUsers = ApiPrefix + "/nodes/rooms/{roomId}/users";

        #endregion

        #endregion

        #region Shares-Endpoint

        #region GET

        internal const string ApiGetDownloadShares = ApiPrefix + "/shares/downloads";
        internal const string ApiGetUploadShares = ApiPrefix + "/shares/uploads";

        #endregion
        #region POST

        internal const string ApiPostCreateDownloadShare = ApiPrefix + "/shares/downloads";
        internal const string ApiPostCreateUploadShare = ApiPrefix + "/shares/uploads";

        #endregion
        #region DELETE

        internal const string ApiDeleteDownloadShare = ApiPrefix + "/shares/downloads/{shareId}";
        internal const string ApiDeleteUploadShare = ApiPrefix + "/shares/uploads/{shareId}";

        #endregion

        #endregion

        #region Config-Endpoint

        #region GET

        internal const string ApiGetGeneralConfig = ApiPrefix + "/config/info/general";
        internal const string ApiGetInfrastructureConfig = ApiPrefix + "/config/info/infrastructure";
        internal const string ApiGetDefaultsConfig = ApiPrefix + "/config/info/defaults";

        #endregion

        #endregion

        #region Uploads-Endpoint

        #region POST

        internal const string ApiPostFileUpload = ApiPrefix + "/uploads";

        #endregion
        #region PUT

        #endregion

        #endregion

        #region Groups-Endpoint

        private const string ApiGroupsPrefix = ApiPrefix + "/groups";

        #region GET

        internal const string ApiGetGroups = ApiGroupsPrefix;
        internal const string ApiGetGroup = ApiGroupsPrefix + "/{groupId}";
        internal const string ApiGetGroupLastAdminRooms = ApiGroupsPrefix + "/{groupId}/last_admin_rooms";
        internal const string ApiGetGroupRoles = ApiGroupsPrefix + "/{groupId}/roles";
        internal const string ApiGetGroupUsers = ApiGroupsPrefix + "/{groupId}/users";

        #endregion
        #region POST

        internal const string ApiPostGroup = ApiGroupsPrefix;
        internal const string ApiPostGroupUser = ApiGroupsPrefix + "/{groupId}/users";

        #endregion
        #region PUT

        internal const string ApiPutGroup = ApiGroupsPrefix + "/{groupId}";

        #endregion
        #region DELETE

        internal const string ApiDeleteGroup = ApiGroupsPrefix + "/{groupId}";
        internal const string ApiDeleteGroupUsers = ApiGroupsPrefix + "/{groupId}/users";

        #endregion

        #endregion

        #region Users-Endpoint

        private const string ApiUsersPrefix = ApiPrefix + "/users";
        private const string ApiUsersUserIdPrefix = ApiPrefix + "/users/{userId}";

        #region GET

        internal const string ApiGetUsers = ApiUsersPrefix;
        internal const string ApiGetUser = ApiUsersUserIdPrefix;
        internal const string ApiGetUserGroups = ApiUsersUserIdPrefix + "/users";
        internal const string ApiGetUserLastAdminRooms = ApiUsersUserIdPrefix + "/last_admin_rooms";
        internal const string ApiGetUserRoles = ApiUsersUserIdPrefix + "/roles";
        internal const string ApiGetUserUserAttributes = ApiUsersUserIdPrefix + "/userAttributes";

        #endregion
        #region POST

        internal const string ApiPostUser = ApiUsersPrefix;
        internal const string ApiPostUserAttributes = ApiUsersUserIdPrefix + "/userAttributes";

        #endregion
        #region PUT

        internal const string ApiPutUser = ApiUsersUserIdPrefix;
        internal const string ApiPutUserUserAttributes = ApiUsersUserIdPrefix + "/userAttributes";

        #endregion
        #region DELETE

        internal const string ApiDeleteUser = ApiUsersUserIdPrefix;
        internal const string ApiDeleteUserUserAttribute = ApiUsersUserIdPrefix + "/userAttributes/{key}";

        #endregion

        #endregion

        #region EventLog-Endpoint

        private const string ApiEventLogPrefix = ApiPrefix + "/eventlog";

        #region GET

        internal const string ApiGetAuditNodes = ApiEventLogPrefix + "/audits/nodes";
        internal const string ApiGetEvents = ApiEventLogPrefix + "/events";
        internal const string ApiGetOperations = ApiEventLogPrefix + "/operations";

        #endregion

        #endregion

        internal static Uri BuildApiUrl(Uri baseUrl, params string[] pathSegments) {
            UriBuilder uriBuilder = new UriBuilder(baseUrl);
            for (int i = 0; i < pathSegments.Length; i++) {
                uriBuilder.Path += i != 0 ? "/" + pathSegments[i] : pathSegments[i];
            }
            return uriBuilder.Uri;
        }
    }
}
