using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiLogOperation {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id {
            get; internal set;
        }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name {
            get; internal set;
        }
        [JsonProperty("isDeprecated", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsDeprecated {
            get; internal set;
        }
    }
}
