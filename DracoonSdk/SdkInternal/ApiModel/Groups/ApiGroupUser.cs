using System;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiGroupUser {
        [JsonProperty("userInfo", NullValueHandling = NullValueHandling.Ignore)]
        public ApiUserInfo UserInfo {
            get; internal set;
        }
        [JsonProperty("isMember", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsMember {
            get; internal set;
        }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [Obsolete("Deprecated since version 4.11.0")]
        public long Id {
            get; internal set;
        }
        [JsonProperty("login", NullValueHandling = NullValueHandling.Ignore)]
        [Obsolete("Deprecated since version 4.11.0")]
        public string Login {
            get; internal set;
        }
        [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
        [Obsolete("Deprecated since version 4.11.0")]
        public string DisplayName {
            get; internal set;
        }
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        [Obsolete("Deprecated since version 4.11.0")]
        public string Email {
            get; internal set;
        }
    }
}
