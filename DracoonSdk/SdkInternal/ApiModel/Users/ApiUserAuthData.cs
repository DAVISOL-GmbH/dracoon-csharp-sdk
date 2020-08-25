using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiUserAuthData {
        [JsonProperty("method", NullValueHandling = NullValueHandling.Ignore)]
        public string Method {
            get; internal set;
        }
        [JsonProperty("login", NullValueHandling = NullValueHandling.Ignore)]
        public string Login {
            get; internal set;
        }
        [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password {
            get; internal set;
        }
        [JsonProperty("mustChangePassword", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MustChangePassword {
            get; internal set;
        }
        [JsonProperty("adConfigId", NullValueHandling = NullValueHandling.Ignore)]
        public int? AdConfigId {
            get; internal set;
        }
        [JsonProperty("oidConfigId", NullValueHandling = NullValueHandling.Ignore)]
        public int? OidConfigId {
            get; internal set;
        }
    }
}
