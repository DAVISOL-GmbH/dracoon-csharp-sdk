using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiRole {
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
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiRight> Rights {
            get; set;
        }
    }
}
