using Dracoon.Crypto.Sdk.Model;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using System;
using System.Collections.Generic;
using Dracoon.Sdk.SdkInternal.ApiModel.Requests;
using Dracoon.Sdk.SdkInternal.Util;
using Attribute = Dracoon.Sdk.Model.Attribute;

namespace Dracoon.Sdk.SdkInternal.Mapper {
    internal static class UserMapper {
        internal static UserInfo FromApiUserInfo(ApiUserInfo apiUserInfo) {
            if (apiUserInfo == null) {
                return null;
            }

            UserInfo userInfo = new UserInfo {
                Id = apiUserInfo.Id,
                DisplayName = apiUserInfo.DisplayName,
                AvatarUUID = apiUserInfo.AvatarUuid,
                UserName = apiUserInfo.UserName,
                Email = apiUserInfo.Email,
                FirstName = apiUserInfo.FirstName,
                LastName = apiUserInfo.LastName,
                Title = apiUserInfo.Title,
                UserType = EnumConverter.ConvertValueToUserTypeEnum(apiUserInfo.UserType)
            };
            return userInfo;
        }

        internal static UserAccount FromApiUserAccount(ApiUserAccount apiUserAccount) {
            if (apiUserAccount == null) {
                return null;
            }

            UserAccount userAccount = new UserAccount {
                Id = apiUserAccount.Id,
                LoginName = apiUserAccount.LoginName,
                UserName = apiUserAccount.UserName ?? apiUserAccount.LoginName,
                Title = apiUserAccount.Title,
                FirstName = apiUserAccount.FirstName,
                LastName = apiUserAccount.LastName,
                Email = apiUserAccount.Email,
                HasEncryptionEnabled = apiUserAccount.IsEncryptionEnabled,
                HasManageableRooms = apiUserAccount.HasManageableRooms,
                ExpireAt = apiUserAccount.ExpireAt,
                LastLoginSuccessAt = apiUserAccount.LastLoginSuccessAt,
                LastLoginFailAt = apiUserAccount.LastLoginFailAt,
                UserRoles = ConvertApiUserRoles(apiUserAccount.UserRoles),
                HomeRoomId = apiUserAccount.HomeRoomId
            };
            return userAccount;
        }

        private static List<UserRole> ConvertApiUserRoles(ApiUserRoleList apiUserRoles) {
            List<UserRole> returnValue = new List<UserRole>();
            if (apiUserRoles == null) {
                return returnValue;
            }

            foreach (ApiUserRole currentRole in apiUserRoles.Items) {
                returnValue.Add((UserRole) Enum.ToObject(typeof(UserRole), currentRole.Id));
            }

            return returnValue;
        }

        internal static ApiUserKeyPair ToApiUserKeyPair(UserKeyPair userKeyPair) {
            if (userKeyPair == null)
                return null;
            ApiUserKeyPair apiUserKeyPair = new ApiUserKeyPair {
                PublicKeyContainer = ToApiUserPublicKey(userKeyPair.UserPublicKey),
                PrivateKeyContainer = ToApiUserPrivateKey(userKeyPair.UserPrivateKey)
            };
            return apiUserKeyPair;
        }

        private static ApiUserPublicKey ToApiUserPublicKey(UserPublicKey userPublicKey) {
            if (userPublicKey == null)
                return null;
            ApiUserPublicKey apiUserPublicKey = new ApiUserPublicKey {
                Version = userPublicKey.Version,
                PublicKey = userPublicKey.PublicKey
            };
            return apiUserPublicKey;
        }

        private static ApiUserPrivateKey ToApiUserPrivateKey(UserPrivateKey userPrivateKey) {
            if (userPrivateKey == null)
                return null;
            ApiUserPrivateKey apiUserPrivateKey = new ApiUserPrivateKey {
                Version = userPrivateKey.Version,
                PrivateKey = userPrivateKey.PrivateKey
            };
            return apiUserPrivateKey;
        }

        internal static UserKeyPair FromApiUserKeyPair(ApiUserKeyPair apiUserKeyPair) {
            if (apiUserKeyPair == null)
                return null;
            UserKeyPair userKeyPair = new UserKeyPair() {
                UserPublicKey = FromApiUserPublicKey(apiUserKeyPair.PublicKeyContainer),
                UserPrivateKey = FromApiUserPrivateKey(apiUserKeyPair.PrivateKeyContainer)
            };
            return userKeyPair;
        }

        internal static UserPublicKey FromApiUserPublicKey(ApiUserPublicKey apiUserPublicKey) {
            if (apiUserPublicKey == null)
                return null;
            UserPublicKey userPublicKey = new UserPublicKey() {
                Version = apiUserPublicKey.Version,
                PublicKey = apiUserPublicKey.PublicKey
            };
            return userPublicKey;
        }

        private static UserPrivateKey FromApiUserPrivateKey(ApiUserPrivateKey apiUserPrivateKey) {
            if (apiUserPrivateKey == null)
                return null;
            UserPrivateKey userPrivateKey = new UserPrivateKey() {
                Version = apiUserPrivateKey.Version,
                PrivateKey = apiUserPrivateKey.PrivateKey
            };
            return userPrivateKey;
        }

        internal static Dictionary<long, UserPublicKey> ConvertApiUserIdPublicKeys(List<ApiUserIdPublicKey> userIdPublicKeys) {
            Dictionary<long, UserPublicKey> userPublicKeys = new Dictionary<long, UserPublicKey>(userIdPublicKeys.Count);
            if (userIdPublicKeys != null) {
                foreach (ApiUserIdPublicKey currentPublicKey in userIdPublicKeys) {
                    userPublicKeys.Add(currentPublicKey.UserId, FromApiUserPublicKey(currentPublicKey.PublicKeyContainer));
                }
            }
            return userPublicKeys;
        }



        internal static UserList FromApiUserList(ApiUserList apiUserList) {
            UserList userList = new UserList();
            CommonMapper.FromApiRangeList<ApiUserItem, UserItem>(apiUserList, userList, FromApiUserItem);
            return userList;
        }

        private static UserItem FromApiUserItem(ApiUserItem apiUserItem) {
            UserItem userItem = new UserItem() {
                Id = apiUserItem.Id,
                UserName = apiUserItem.UserName,
                FirstName = apiUserItem.FirstName,
                LastName = apiUserItem.LastName,
                IsLocked = apiUserItem.IsLocked,
                HasManagableRooms = apiUserItem.HasManagableRooms,
                AvatarUuid = apiUserItem.AvatarUuid,
                LockStatus = apiUserItem.LockStatus,
                Login = apiUserItem.Login,
                Title = apiUserItem.Title,
                CreatedAt = apiUserItem.CreatedAt,
                LastLoginSuccessAt = apiUserItem.LastLoginSuccessAt,
                ExpireAt = apiUserItem.ExpireAt,
                IsEncryptionEnabled = apiUserItem.IsEncryptionEnabled,
                Email = apiUserItem.Email,
                Phone = apiUserItem.Phone,
                HomeRoomId = apiUserItem.HomeRoomId,
                UserRoles = CommonMapper.FromApiRoleList(apiUserItem.UserRoles),
                UserAttributes = FromApiUserAttributes(apiUserItem.UserAttributes)
            };
            return userItem;
        }

        internal static UserData FromApiUserData(ApiUserData apiUserData) {
            UserData userData = new UserData() {
                Id = apiUserData.Id,
                UserName = apiUserData.UserName,
                FirstName = apiUserData.FirstName,
                LastName = apiUserData.LastName,
                IsLocked = apiUserData.IsLocked,
                HasManagableRooms = apiUserData.HasManagableRooms,
                AvatarUuid = apiUserData.AvatarUuid,
                LockStatus = apiUserData.LockStatus,
                Login = apiUserData.Login,
                Title = apiUserData.Title,
                CreatedAt = apiUserData.CreatedAt,
                LastLoginSuccessAt = apiUserData.LastLoginSuccessAt,
                ExpireAt = apiUserData.ExpireAt,
                IsEncryptionEnabled = apiUserData.IsEncryptionEnabled,
                Email = apiUserData.Email,
                Phone = apiUserData.Phone,
                HomeRoomId = apiUserData.HomeRoomId,
                UserRoles = CommonMapper.FromApiRoleList(apiUserData.UserRoles),
                UserAttributes = FromApiUserAttributes(apiUserData.UserAttributes),

                AuthData = FromApiUserAuthData(apiUserData.AuthData),
                AuthMethods = new List<UserAuthMethod>(),
                PublicKeyContainer = FromApiUserPublicKey(apiUserData.PublicKeyContainer)
            };
            foreach (ApiUserAuthMethod apiUserAuthMethod in apiUserData.AuthMethods) {
                userData.AuthMethods.Add(FromApiUserAuthMethod(apiUserAuthMethod));
            }
            return userData;
        }

        internal static UserGroupList FromApiUserGroupList(ApiUserGroupList apiUserGroupList) {
            UserGroupList userGroupList = new UserGroupList();
            CommonMapper.FromApiRangeList(apiUserGroupList, userGroupList, FromApiUserGroup);
            return userGroupList;
        }

        private static UserGroup FromApiUserGroup(ApiUserGroup apiUserGroup) {
            UserGroup userGroup = new UserGroup() {
                Id = apiUserGroup.Id,
                IsMember = apiUserGroup.IsMember,
                Name = apiUserGroup.Name
            };
            return userGroup;
        }

        internal static LastAdminUserRoomList FromApiLastAdminUserRoomList(ApiLastAdminUserRoomList apiLastAdminUserRoomList) {
            LastAdminUserRoomList lastAdminUserRoomList = new LastAdminUserRoomList();
            CommonMapper.FromApiSimpleList(apiLastAdminUserRoomList, lastAdminUserRoomList, FromApiLastAdminUserRoom);
            return lastAdminUserRoomList;
        }

        private static LastAdminUserRoom FromApiLastAdminUserRoom(ApiLastAdminUserRoom apiLastAdminUserRoom) {
            LastAdminUserRoom lastAdminUserRoom = new LastAdminUserRoom() {
                Id = apiLastAdminUserRoom.Id,
                Name = apiLastAdminUserRoom.Name,
                ParentPath = apiLastAdminUserRoom.ParentPath,
                LastAdminInGroup = apiLastAdminUserRoom.LastAdminInGroup,
                ParentId = apiLastAdminUserRoom.ParentId,
                LastAdminInGroupId = apiLastAdminUserRoom.LastAdminInGroupId
            };
            return lastAdminUserRoom;
        }

        internal static UserAttributes FromApiUserAttributes(ApiUserAttributes apiUserAttributes) {
            UserAttributes userAttributes = new UserAttributes();
            CommonMapper.FromApiSimpleList(apiUserAttributes, userAttributes, x => x);
            return userAttributes;
        }

        private static UserAuthData FromApiUserAuthData(ApiUserAuthData apiUserAuthData) {
            if (apiUserAuthData == null) {
                return null;
            }
            UserAuthData userAuthData = new UserAuthData() {
                Method = FromAuthMethodTypeString(apiUserAuthData.Method),
                Login = apiUserAuthData.Login,
                Password = apiUserAuthData.Password,
                MustChangePassword = apiUserAuthData.MustChangePassword,
                AdConfigId = apiUserAuthData.AdConfigId,
                OidConfigId = apiUserAuthData.OidConfigId
            };
            return userAuthData;
        }

        private static UserAuthMethod FromApiUserAuthMethod(ApiUserAuthMethod apiUserAuthMethod) {
            UserAuthMethod userAuthMethod = new UserAuthMethod() {
                AuthId = FromAuthMethodTypeString(apiUserAuthMethod.AuthId),
                IsEnabled = apiUserAuthMethod.IsEnabled,
                Options = new List<KeyValuePair<string, string>>()
            };
            foreach (KeyValuePair<string, string> option in apiUserAuthMethod.Options) {
                userAuthMethod.Options.Add(option);
            }
            return userAuthMethod;
        }

        internal static AttributesResponse FromApiAttributesResponse(ApiAttributesResponse apiAttributesResponse) {
            AttributesResponse attributesResponse = new AttributesResponse();
            CommonMapper.FromApiRangeList(apiAttributesResponse, attributesResponse, x => x);
            return attributesResponse;
        }

        internal static ApiCreateUserRequest ToApiCreateUserRequest(CreateUserRequest createUserRequest) {
            ApiCreateUserRequest apiCreateUserRequest = new ApiCreateUserRequest() {
                FirstName = createUserRequest.FirstName,
                LastName = createUserRequest.LastName,
                UserName = createUserRequest.UserName,
                Title = createUserRequest.Title,
                Phone = createUserRequest.Phone,
                ExpireAt = CommonMapper.ToApiExpiration(createUserRequest.ExpireAt),
                ReceiverLanguage = createUserRequest.ReceiverLanguage?.Name,
                Email = createUserRequest.Email,
                NotifyUser = createUserRequest.NotifyUser,
                AuthData = ToApiUserAuthData(createUserRequest.AuthData),
                IsNonmemberViewer = createUserRequest.IsNonmemberViewer

            };
            return apiCreateUserRequest;
        }

        internal static ApiUpdateUserRequest ToApiUpdateUserRequest(UpdateUserRequest updateUserRequest) {
            ApiUpdateUserRequest apiUpdateUserRequest = new ApiUpdateUserRequest() {
                Title = updateUserRequest.Title,
                FirstName = updateUserRequest.FirstName,
                LastName = updateUserRequest.LastName,
                UserName = updateUserRequest.UserName,
                Email = updateUserRequest.Email,
                IsLocked = updateUserRequest.IsLocked,
                Phone = updateUserRequest.Phone,
                ReceiverLanguage = updateUserRequest.ReceiverLanguage?.Name,
                ExpireAt = CommonMapper.ToApiExpiration(updateUserRequest.ExpireAt),
                AuthData = ToApiUserAuthDataUpdateRequest(updateUserRequest.AuthData)
            };
            return apiUpdateUserRequest;
        }

        internal static ApiUserAttributes ToApiUserAttributes(UserAttributes userAttributes) {
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
            foreach (var userAttribute in userAttributes.Items) {
                items.Add(userAttribute);
            }
            ApiUserAttributes apiUserAttributes = new ApiUserAttributes() {
                Items = items
            };
            return apiUserAttributes;
        }

        private static ApiUserAuthData ToApiUserAuthData(UserAuthData userAuthData) {
            if (userAuthData == null) {
                return null;
            }

            ApiUserAuthData apiUserAuthData = new ApiUserAuthData() {
                Method = ToAuthMethodTypeString(userAuthData.Method),
                Login = userAuthData.Login,
                Password = userAuthData.Password,
                MustChangePassword = userAuthData.MustChangePassword,
                AdConfigId = userAuthData.AdConfigId,
                OidConfigId = userAuthData.OidConfigId
            };
            return apiUserAuthData;
        }

        private static ApiUserAuthDataUpdateRequest ToApiUserAuthDataUpdateRequest(UserAuthDataUpdateRequest userAuthDataUpdateRequest) {
            if (userAuthDataUpdateRequest == null) {
                return null;
            }

            ApiUserAuthDataUpdateRequest apiUserAuthDataUpdateRequest = new ApiUserAuthDataUpdateRequest() {
                Method = ToAuthMethodTypeString(userAuthDataUpdateRequest.Method),
                Login = userAuthDataUpdateRequest.Login,
                AdConfigId = userAuthDataUpdateRequest.AdConfigId,
                OidConfigId = userAuthDataUpdateRequest.OidConfigId
            };
            return apiUserAuthDataUpdateRequest;
        }


        private const string AuthMethodTypeBasic = "basic";
        private const string AuthMethodTypeSql = "sql";
        private const string AuthMethodTypeAD = "active_directory";
        private const string AuthMethodTypeRadius = "radius";
        private const string AuthMethodTypeOpenId = "openid";

        private static AuthMethodType FromAuthMethodTypeString(string authMethodTypeString) {
            if (authMethodTypeString.Equals(AuthMethodTypeBasic, StringComparison.OrdinalIgnoreCase) || authMethodTypeString.Equals(AuthMethodTypeSql, StringComparison.OrdinalIgnoreCase)) {
                return AuthMethodType.BasicOrSql;
            }
            if (authMethodTypeString.Equals(AuthMethodTypeAD, StringComparison.OrdinalIgnoreCase)) {
                return AuthMethodType.ActiveDirectory;
            }
            if (authMethodTypeString.Equals(AuthMethodTypeRadius, StringComparison.OrdinalIgnoreCase)) {
                return AuthMethodType.Radius;
            }
            if (authMethodTypeString.Equals(AuthMethodTypeOpenId, StringComparison.OrdinalIgnoreCase)) {
                return AuthMethodType.OpenId;
            }
            return AuthMethodType.BasicOrSql;
        }

        private static string ToAuthMethodTypeString(AuthMethodType authMethodType) {
            switch (authMethodType) {
                case AuthMethodType.BasicOrSql:
                    return AuthMethodTypeBasic;
                case AuthMethodType.ActiveDirectory:
                    return AuthMethodTypeAD;
                case AuthMethodType.Radius:
                    return AuthMethodTypeRadius;
                case AuthMethodType.OpenId:
                    return AuthMethodTypeOpenId;
                default:
                    return null;
            }
        }

        internal static AvatarInfo FromApiAvatarInfo(ApiAvatarInfo apiInfo) {
            AvatarInfo info = new AvatarInfo {
                AvatarUUID = apiInfo.AvatarUuid,
                IsCustomAvatar = apiInfo.IsCustomAvatar
            };
            return info;
        }
    }
}
