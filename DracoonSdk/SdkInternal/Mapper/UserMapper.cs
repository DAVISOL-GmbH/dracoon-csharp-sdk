using Dracoon.Crypto.Sdk;
using Dracoon.Crypto.Sdk.Model;
using Dracoon.Sdk.Error;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.ApiModel.Requests;
using Dracoon.Sdk.SdkInternal.User;
using Dracoon.Sdk.SdkInternal.Util;
using System;
using System.Collections.Generic;

namespace Dracoon.Sdk.SdkInternal.Mapper {
    internal static class UserMapper {
        internal static UserInfo FromApiUserInfo(ApiUserInfo apiUserInfo) {
            if (apiUserInfo == null) {
                return null;
            }

            UserInfo userInfo = new UserInfo {
                Id = apiUserInfo.Id,
                UserName = apiUserInfo.UserName,
                AvatarUUID = apiUserInfo.AvatarUuid,
                Email = apiUserInfo.Email,
                FirstName = apiUserInfo.FirstName,
                LastName = apiUserInfo.LastName,
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
                AuthData = FromApiUserAuthData(apiUserAccount.AuthData),
                UserName = apiUserAccount.UserName,
                FirstName = apiUserAccount.FirstName,
                LastName = apiUserAccount.LastName,
                Email = apiUserAccount.Email,
                HasEncryptionEnabled = apiUserAccount.IsEncryptionEnabled,
                HasManageableRooms = apiUserAccount.HasManageableRooms,
                ExpireAt = apiUserAccount.ExpireAt,
                LastLoginSuccessAt = apiUserAccount.LastLoginSuccessAt,
                LastLoginFailAt = apiUserAccount.LastLoginFailAt,
                UserRoles = ConvertApiUserRoles(apiUserAccount.UserRoles),
                HomeRoomId = apiUserAccount.HomeRoomId,
                IsLocked = apiUserAccount.IsLocked,
                Language = apiUserAccount.Language,
                MustSetEmail = apiUserAccount.MustSetEmail,
                NeedsToAcceptEULA = apiUserAccount.NeedsToAcceptEULA,
                Phone = apiUserAccount.Phone,
                UserGroups = new List<UserGroup>()
            };
            if (apiUserAccount.UserGroups != null) {
                foreach (ApiUserGroup currentGroup in apiUserAccount.UserGroups) {
                    userAccount.UserGroups.Add(FromApiUserGroup(currentGroup));
                }
            }
            return userAccount;
        }

        internal static UserAuthData FromApiUserAuthData(ApiAuthData apiUserAuthData) {
            if (apiUserAuthData == null) {
                return null;
            }

            UserAuthData userAuthData = new UserAuthData {
                Method = EnumConverter.ConvertValueToUserAuthMethodEnum(apiUserAuthData.Method),
                Login = apiUserAuthData.Login,
                Password = apiUserAuthData.Password,
                MustChangePassword = apiUserAuthData.MustChangePassword,
                ADConfigId = apiUserAuthData.ADConfigId,
                OIDConfigId = apiUserAuthData.OIDConfigId
            };
            return userAuthData;
        }

        internal static UserGroup FromApiUserGroup(ApiUserGroup apiUserGroup) {
            if (apiUserGroup == null) {
                return null;
            }

            UserGroup userGroup = new UserGroup {
                Id = apiUserGroup.Id,
                IsMember = apiUserGroup.IsMember,
                Name = apiUserGroup.Name
            };
            return userGroup;
        }

        private static List<UserRole> ConvertApiUserRoles(ApiUserRoleList apiUserRoles) {
            List<UserRole> returnValue = new List<UserRole>();
            if (apiUserRoles == null) {
                return returnValue;
            }

            foreach (ApiUserRole currentRole in apiUserRoles.Items) {
                returnValue.Add((UserRole)Enum.ToObject(typeof(UserRole), currentRole.Id));
                returnValue.Add((UserRole)Enum.ToObject(typeof(UserRole), currentRole.Id));
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
                Version = ToApiUserKeyPairVersion(userPublicKey.Version),
                PublicKey = userPublicKey.PublicKey
            };
            return apiUserPublicKey;
        }

        private static ApiUserPrivateKey ToApiUserPrivateKey(UserPrivateKey userPrivateKey) {
            if (userPrivateKey == null)
                return null;
            ApiUserPrivateKey apiUserPrivateKey = new ApiUserPrivateKey {
                Version = ToApiUserKeyPairVersion(userPrivateKey.Version),
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
                Version = FromApiUserKeyPairVersion(apiUserPublicKey.Version),
                PublicKey = apiUserPublicKey.PublicKey
            };
            return userPublicKey;
        }

        private static UserPrivateKey FromApiUserPrivateKey(ApiUserPrivateKey apiUserPrivateKey) {
            if (apiUserPrivateKey == null)
                return null;
            UserPrivateKey userPrivateKey = new UserPrivateKey() {
                Version = FromApiUserKeyPairVersion(apiUserPrivateKey.Version),
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
            CommonMapper.FromApiRangeList(apiUserList, userList, FromApiUserItem);
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
                PublicKeyContainer = FromApiUserPublicKey(apiUserData.PublicKeyContainer)
            };
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
            CommonMapper.FromApiSimpleList(apiUserAttributes, userAttributes, x => CommonMapper.FromApiKeyValuePair(x));
            return userAttributes;
        }

        private static UserAuthData FromApiUserAuthData(ApiUserAuthData apiUserAuthData) {
            if (apiUserAuthData == null) {
                return null;
            }
            UserAuthData userAuthData = new UserAuthData() {
                Method = EnumConverter.ConvertValueToUserAuthMethodEnum(apiUserAuthData.Method),
                Login = apiUserAuthData.Login,
                Password = apiUserAuthData.Password,
                MustChangePassword = apiUserAuthData.MustChangePassword,
                ADConfigId = apiUserAuthData.AdConfigId,
                OIDConfigId = apiUserAuthData.OidConfigId
            };
            return userAuthData;
        }

        internal static AttributesResponse FromApiAttributesResponse(ApiAttributesResponse apiAttributesResponse) {
            AttributesResponse attributesResponse = new AttributesResponse();
            CommonMapper.FromApiRangeList(apiAttributesResponse, attributesResponse, x => CommonMapper.FromApiKeyValuePair(x));
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
            ApiUserAttributes apiUserAttributes = new ApiUserAttributes();
            CommonMapper.ToApiSimpleList(userAttributes, apiUserAttributes, x => CommonMapper.ToApiKeyValuePair(x));
            return apiUserAttributes;
        }

        private static ApiUserAuthData ToApiUserAuthData(UserAuthData userAuthData) {
            if (userAuthData == null) {
                return null;
            }

            ApiUserAuthData apiUserAuthData = new ApiUserAuthData() {
                Method = EnumConverter.ConvertUserAuthMethodEnumToValue(userAuthData.Method),
                Login = userAuthData.Login,
                Password = userAuthData.Password,
                MustChangePassword = userAuthData.MustChangePassword,
                AdConfigId = userAuthData.ADConfigId,
                OidConfigId = userAuthData.OIDConfigId
            };
            return apiUserAuthData;
        }

        private static ApiUserAuthDataUpdateRequest ToApiUserAuthDataUpdateRequest(UserAuthDataUpdateRequest userAuthDataUpdateRequest) {
            if (userAuthDataUpdateRequest == null) {
                return null;
            }

            ApiUserAuthDataUpdateRequest apiUserAuthDataUpdateRequest = new ApiUserAuthDataUpdateRequest() {
                Method = EnumConverter.ConvertUserAuthMethodEnumToValue(userAuthDataUpdateRequest.Method),
                Login = userAuthDataUpdateRequest.Login,
                AdConfigId = userAuthDataUpdateRequest.ADConfigId,
                OidConfigId = userAuthDataUpdateRequest.OIDConfigId
            };
            return apiUserAuthDataUpdateRequest;
        }

        internal static AvatarInfo FromApiAvatarInfo(ApiAvatarInfo apiInfo) {
            AvatarInfo info = new AvatarInfo {
                AvatarUUID = apiInfo.AvatarUuid,
                IsCustomAvatar = apiInfo.IsCustomAvatar
            };
            return info;
        }

        internal static UserKeyPairAlgorithm FromApiUserKeyPairVersion(string version) {
            switch (version) {
                case "RSA-4096":
                    return UserKeyPairAlgorithm.RSA4096;
                case "A":
                    return UserKeyPairAlgorithm.RSA2048;
                default:
                    throw new DracoonCryptoException(new DracoonCryptoCode(DracoonCryptoCode.UNKNOWN_ALGORITHM_ERROR.Code, "Unknown user key pair algorithm: " + version + "."));
            }
        }

        internal static string ToApiUserKeyPairVersion(UserKeyPairAlgorithm algorithm) {
            switch (algorithm) {
                case UserKeyPairAlgorithm.RSA4096:
                    return "RSA-4096";
                case UserKeyPairAlgorithm.RSA2048:
                    return "A";
                default:
                    throw new DracoonCryptoException(new DracoonCryptoCode(DracoonCryptoCode.UNKNOWN_ALGORITHM_ERROR.Code, "Unknown user key pair algorithm: " + algorithm.GetStringValue() + "."));
            }
        }

    }
}
