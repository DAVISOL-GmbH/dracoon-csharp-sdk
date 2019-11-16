using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiUserGroup {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id {
            get; internal set;
        }
        [JsonProperty("isMember", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsMember {
            get; internal set;
        }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name {
            get; internal set;
        }
    }
}
