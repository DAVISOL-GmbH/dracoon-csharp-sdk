using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiSoftwareVersionData {
        [JsonProperty("buildTimestamp", NullValueHandling = NullValueHandling.Ignore)]
        public string BuildTimestamp {
            get; internal set;
        }
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public string Version {
            get; internal set;
        }
    }
}
