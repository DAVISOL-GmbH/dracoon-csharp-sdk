using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiRoleUser {
        [JsonProperty("userInfo", NullValueHandling = NullValueHandling.Ignore)]
        public ApiUserInfo UserInfo {
            get; internal set;
        }
        [JsonProperty("isMember", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsMember {
            get; internal set;
        }
    }
}
