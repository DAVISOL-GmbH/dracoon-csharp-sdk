using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiGroupInfo {

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id {
            get; internal set;
        }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name {
            get; internal set;
        }
    }
}
