using System;
using System.Text;

namespace Dracoon.Sdk.SdkInternal {
    internal static class ApiConfig {
        internal const string MinimumApiVersion = "4.23.0";
        internal const string ApiPrefix = "api/v4";
        internal const string BrandingApiPrefix = "branding/api/v1";
        internal const string AuthorizationHeader = "Authorization";
        // token template: mediaserver/image/{mediaToken}/{width}x{height}
        internal const string MediaTokenTemplate = "mediaserver/image/{0}/{1}x{2}";


        // Character set based on https://wiki.dracoon.com/display/DevOrga/Password+Policies
        internal static readonly char[] UPPERCASE_SET = {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        internal static readonly char[] LOWERCASE_SET = {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
        };

        internal static readonly char[] NUMERIC_SET = {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        internal static readonly char[] SPECIAL_SET = {
            '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '=', '?', '@', '[', '\\', ']', '^', '_', '{', '|',
            '}', '~'
        };

        internal static readonly Encoding ENCODING = Encoding.UTF8;

        #region Crypto-Algorithm

        internal const string ApiVersionMin_Algorithm_UserKeyPair_RSA4096 = "4.24.0";

        #endregion

        #region Public-Endpoint

        #region GET

        internal const string ApiGetServerVersion = ApiPrefix + "/public/software/version";
        internal const string ApiGetServerTime = ApiPrefix + "/public/time";

        internal const string ApiGetPublicDownloadShare = ApiPrefix + "/public/shares/downloads/{accessKey}";
        internal const string ApiGetPublicUploadShare = ApiPrefix + "/public/shares/uploads/{accessKey}";

        #endregion

        #endregion

        #region User-Endpoint

        #region GET

        internal const string ApiGetUserAccount = ApiPrefix + "/user/account";
        internal const string ApiGetCustomerAccount = ApiPrefix + "/user/account/customer";
        internal const string ApiGetUserKeyPair = ApiPrefix + "/user/account/keypair";
        internal const string ApiGetUserKeyPairs = ApiPrefix + "/user/account/keypairs";
        internal const string ApiGetAuthenticatedPing = ApiPrefix + "/user/ping";
        internal const string ApiGetAvatar = ApiPrefix + "/user/account/avatar";
        internal const string ApiGetUserProfileAttributes = ApiPrefix + "/user/profileAttributes";

        #endregion

        #region POST

        internal const string ApiPostUserKeyPair = ApiPrefix + "/user/account/keypair";
        internal const string ApiPostAvatar = ApiPrefix + "/user/account/avatar";

        #endregion

        #region PUT

        internal const string ApiPutUserProfileAttributes = ApiPrefix + "/user/profileAttributes";

        #endregion

        #region DELETE

        internal const string ApiDeleteUserKeyPair = ApiPrefix + "/user/account/keypair";
        internal const string ApiDeleteUserProfileAttributes = ApiPrefix + "/user/profileAttributes/{key}";
        internal const string ApiDeleteAvatar = ApiPrefix + "/user/account/avatar";

        #endregion

        #region Minimum version requirements

        internal const string ApiGetUserKeyPairsMinimumVersion = "4.24.0";

        #endregion

        #endregion

        #region Nodes-Endpoint

        #region GET

        internal const string ApiGetChildNodes = ApiPrefix + "/nodes";
        internal const string ApiGetNode = ApiPrefix + "/nodes/{nodeId}";
        internal const string ApiGetFileKey = ApiPrefix + "/nodes/files/{fileId}/user_file_key";
        internal const string ApiGetSearchNodes = ApiPrefix + "/nodes/search";
        internal const string ApiGetMissingFileKeys = ApiPrefix + "/nodes/missingFileKeys";
        internal const string ApiGetRecycleBin = ApiPrefix + "/nodes/{roomId}/deleted_nodes";
        internal const string ApiGetPreviousVersions = ApiPrefix + "/nodes/{nodeId}/deleted_nodes/versions";
        internal const string ApiGetPreviousVersion = ApiPrefix + "/nodes/deleted_nodes/{previoudNodeId}";
        internal const string ApiGetRoomEvents = ApiPrefix + "/nodes/rooms/{roomId}/events";
        internal const string ApiGetRoomGroups = ApiPrefix + "/nodes/rooms/{roomId}/groups";
        internal const string ApiGetRoomUsers = ApiPrefix + "/nodes/rooms/{roomId}/users";
        internal const string ApiGetRoomPending = ApiPrefix + "/nodes/rooms/{roomId}/pending";
        internal const string ApiGetS3Status = ApiPrefix + "/nodes/files/uploads/{uploadId}";

        #endregion

        #region POST

        internal const string ApiPostRoom = ApiPrefix + "/nodes/rooms";
        internal const string ApiPostFolder = ApiPrefix + "/nodes/folders";
        internal const string ApiPostCreateFileDownload = ApiPrefix + "/nodes/files/{fileId}/downloads";
        internal const string ApiPostCreateFileUpload = ApiPrefix + "/nodes/files/uploads";
        internal const string ApiPostGetS3Urls = ApiPrefix + "/nodes/files/uploads/{uploadId}/s3_urls";
        internal const string ApiPostCopyNodes = ApiPrefix + "/nodes/{nodeId}/copy_to";
        internal const string ApiPostMoveNodes = ApiPrefix + "/nodes/{nodeId}/move_to";
        internal const string ApiPostMissingFileKeys = ApiPrefix + "/nodes/files/keys";
        internal const string ApiPostFavorite = ApiPrefix + "/nodes/{nodeId}/favorite";
        internal const string ApiPostRestoreNodeVersion = ApiPrefix + "/nodes/deleted_nodes/actions/restore";

        #region Minimum version requirements

        internal const string ApiS3DirectUploadPossible = "4.15.0";

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
        internal const string ApiPutCompleteS3Upload = ApiPrefix + "/nodes/files/uploads/{uploadId}/s3";

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

        internal const string ApiConfigInfoPrefix = ApiPrefix + "/config/info";

        #region GET

        internal const string ApiGetGeneralConfig = ApiConfigInfoPrefix + "/general";
        internal const string ApiGetInfrastructureConfig = ApiConfigInfoPrefix + "/infrastructure";
        internal const string ApiGetDefaultsConfig = ApiConfigInfoPrefix + "/defaults";
        internal const string ApiGetPasswordPolicies = ApiConfigInfoPrefix + "/policies/passwords";
        internal const string ApiGetAlgorithms = ApiConfigInfoPrefix + "/policies/algorithms";
        internal const string ApiGetClassificationPolicies = ApiConfigInfoPrefix + "/policies/classifications";

        #endregion

        #region Minimum version requirements

        internal const string ApiGetAlgorithmsMinimumVersion = "4.24.0";
        internal const string ApiGetClassificationPoliciesMinimumVersion = "4.30.0";

        #endregion

        #endregion

        #region Resources-Endpoint

        #region GET

        internal const string ApiResourcesGetAvatar = ApiPrefix + "/resources/users/{userId}/avatar/{uuid}";

        #endregion

        #endregion

        #region System-Settings-Config-Endpoint

        internal const string ApiSystemConfigPrefix = ApiPrefix + "/system/config";
        internal const string ApiConfigSettingsPrefix = ApiSystemConfigPrefix + "/settings";
        internal const string ApiPoliciesSettingsPrefix = ApiSystemConfigPrefix + "/policies";

        #region GET

        internal const string ApiGetSystemSettingsAuthenticationConfig = ApiConfigSettingsPrefix + "/auth";

        internal const string ApiGetSystemSettingsGeneralConfig = ApiConfigSettingsPrefix + "/general";
        internal const string ApiGetSystemSettingsInfrastructureConfig = ApiConfigSettingsPrefix + "/infrastructure";
        internal const string ApiGetSystemSettingsDefaultsConfig = ApiConfigSettingsPrefix + "/defaults";
        internal const string ApiGetSystemSettingsEventlogConfig = ApiConfigSettingsPrefix + "/eventlog";
        internal const string ApiGetSystemSettingsAuthConfig = ApiConfigSettingsPrefix + "/auth";

        internal const string ApiGetSystemSettingsClassificationPolicies = ApiPoliciesSettingsPrefix + "/classifications";
        internal const string ApiGetSystemSettingsPasswordPolicies = ApiPoliciesSettingsPrefix + "/passwords";

        #endregion

        #endregion

        #region System-Auth-Config-Endpoint

        private const string ApiSystemAuthConfigPrefix = ApiSystemConfigPrefix + "/auth";
        private const string ApiSystemOAuthConfigPrefix = ApiSystemConfigPrefix + "/oauth";

        #region GET

        internal const string ApiGetAuthActiveDirectoryConfigurations = ApiSystemAuthConfigPrefix + "/ads";
        internal const string ApiGetAuthOpenIdIdpConfigurations = ApiSystemAuthConfigPrefix + "/openid/idps";
        internal const string ApiGetAuthRadiusConfiguration = ApiSystemAuthConfigPrefix + "/radius";
        internal const string ApiGetAuthClientConfigurations = ApiSystemOAuthConfigPrefix + "/clients";
        internal const string ApiGetAuthClientConfigurationClientId = ApiGetAuthClientConfigurations + "/{clientId}";

        #endregion
        #region POST

        internal const string ApiPostAuthClientConfiguration = ApiGetAuthClientConfigurations;

        #endregion
        #region PUT

        internal const string ApiPutAuthClientConfiguration = ApiGetAuthClientConfigurationClientId;

        #endregion
        #region DELETE

        internal const string ApiDeleteAuthClientConfiguration = ApiGetAuthClientConfigurationClientId;

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
        internal const string ApiGetUserGroups = ApiUsersUserIdPrefix + "/groups";
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

        #region Roles-Endpoint

        private const string ApiRolesPrefix = ApiPrefix + "/roles";

        #region GET

        internal const string ApiGetRoles = ApiRolesPrefix;
        internal const string ApiGetRoleGroups = ApiRolesPrefix + "/{roleId}/groups";
        internal const string ApiGetRoleUsers = ApiRolesPrefix + "/{roleId}/users";

        #endregion
        #region POST

        internal const string ApiPostRoleGroups = ApiRolesPrefix + "/{roleId}/groups";
        internal const string ApiPostRoleUsers = ApiRolesPrefix + "/{roleId}/users";

        #endregion
        #region DELETE

        internal const string ApiDeleteRoleGroups = ApiGroupsPrefix + "/{roleId}/groups";
        internal const string ApiDeleteRoleUsers = ApiGroupsPrefix + "/{roleId}/users";

        #endregion

        #endregion

        #region Branding-Endpoint (Branding API)

        #region GET

        internal const string BrandingApiGetBranding = BrandingApiPrefix + "/public/branding";

        internal const string BrandingApiGetBrandingServerVersion = BrandingApiPrefix + "/public/software/version";

        #endregion

        #endregion

        internal static Uri BuildApiUrl(Uri baseUrl, params string[] pathSegments) {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < pathSegments.Length; i++) {
                sb.Append(i != 0 ? "/" + pathSegments[i] : pathSegments[i]);
            }

            UriBuilder uriBuilder = new UriBuilder(baseUrl);
            uriBuilder.Path = sb.ToString();
            return uriBuilder.Uri;
        }
    }
}
