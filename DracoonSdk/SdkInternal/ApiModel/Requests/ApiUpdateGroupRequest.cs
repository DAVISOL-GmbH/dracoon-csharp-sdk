using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel.Requests {
    internal class ApiUpdateGroupRequest {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name {
            get; set;
        }
        [JsonProperty("expiration", NullValueHandling = NullValueHandling.Ignore)]
        public ApiExpiration Expiration {
            get; set;
        }
    }
}
