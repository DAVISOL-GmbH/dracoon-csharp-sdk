using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiAuditUserPermission {
        [JsonProperty("userId", NullValueHandling = NullValueHandling.Ignore)]
        public long UserId {
            get; internal set;
        }
        [JsonProperty("userLogin", NullValueHandling = NullValueHandling.Ignore)]
        public string UserLogin {
            get; internal set;
        }
        [JsonProperty("userFirstName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserFirstName {
            get; internal set;
        }
        [JsonProperty("userLastName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserLastName {
            get; internal set;
        }
        [JsonProperty("permissions", NullValueHandling = NullValueHandling.Ignore)]
        public ApiNodePermissions Permissions {
            get; internal set;
        }
    }
}
