using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiNodeReference {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id {
            get; set;
        }
        [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
        public long? ParentId {
            get; set;
        }
        [JsonProperty("parentPath", NullValueHandling = NullValueHandling.Ignore)]
        public string ParentPath {
            get; set;
        }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name {
            get; set;
        }
    }
}
