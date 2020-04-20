using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiColorDetails {
        [JsonProperty("rgba", NullValueHandling = NullValueHandling.Ignore)]
        public string Rgba {
            get; internal set;
        }
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type {
            get; internal set;
        }
    }
}
