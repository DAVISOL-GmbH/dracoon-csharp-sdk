using System;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiUserItem {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id {
            get; internal set;
        }
        [JsonProperty("userName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName {
            get; internal set;
        }
        [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName {
            get; internal set;
        }
        [JsonProperty("lastName", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName {
            get; internal set;
        }
        [JsonProperty("isLocked", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsLocked {
            get; internal set;
        }
        [JsonProperty("hasManageableRooms", NullValueHandling = NullValueHandling.Ignore)]
        public bool HasManagableRooms {
            get; internal set;
        }
        [JsonProperty("avatarUuid", NullValueHandling = NullValueHandling.Ignore)]
        public string AvatarUuid {
            get; internal set;
        }
        [JsonProperty("lockStatus", NullValueHandling = NullValueHandling.Ignore)]
        [Obsolete("[Deprecated since version 4.7.0, use IsLocked instead")]
        public int LockStatus {
            get; internal set;
        }
        [JsonProperty("login", NullValueHandling = NullValueHandling.Ignore)]
        [Obsolete("[Deprecated since version 4.13.0")]
        public string Login {
            get; internal set;
        }
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title {
            get; internal set;
        }
        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedAt {
            get; internal set;
        }
        [JsonProperty("lastLoginSuccessAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? LastLoginSuccessAt {
            get; internal set;
        }
        [JsonProperty("expireAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ExpireAt {
            get; internal set;
        }
        [JsonProperty("isEncryptionEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsEncryptionEnabled {
            get; internal set;
        }
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email {
            get; internal set;
        }
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone {
            get; internal set;
        }
        [JsonProperty("homeRoomId", NullValueHandling = NullValueHandling.Ignore)]
        public long HomeRoomId {
            get; internal set;
        }
        [JsonProperty("userRoles", NullValueHandling = NullValueHandling.Ignore)]
        public ApiRoleList UserRoles {
            get; internal set;
        }
        [JsonProperty("userAttributes", NullValueHandling = NullValueHandling.Ignore)]
        public ApiUserAttributes UserAttributes {
            get; internal set;
        }
    }
}
