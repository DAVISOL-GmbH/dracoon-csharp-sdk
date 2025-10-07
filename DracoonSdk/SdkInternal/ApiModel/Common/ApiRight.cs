using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiRight {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id {
            get; set;
        }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name {
            get; set;
        }
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description {
            get; set;
        }
    }
}
