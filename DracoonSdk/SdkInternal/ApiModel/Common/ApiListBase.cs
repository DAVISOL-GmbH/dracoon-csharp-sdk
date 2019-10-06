using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal abstract class ApiListBase<T> {
        [JsonProperty("range", NullValueHandling = NullValueHandling.Ignore)]
        public ApiRange Range {
            get; set;
        }
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public List<T> Items {
            get; set;
        }
    }
}
