using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiSimpleImageResponse {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id {
            get; internal set;
        }
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type {
            get; internal set;
        }
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url {
            get; internal set;
        }
    }
}
