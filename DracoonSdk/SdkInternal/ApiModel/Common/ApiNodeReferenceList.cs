using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiNodeReferenceList {
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiNodeReference> Items {
            get; set;
        }
    }
}
