using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel.Requests {
    internal class ApiUserAuthDataUpdateRequest {
        [JsonProperty("method", NullValueHandling = NullValueHandling.Ignore)]
        public string Method {
            get; internal set;
        }
        [JsonProperty("login", NullValueHandling = NullValueHandling.Ignore)]
        public string Login {
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
