using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal abstract class ApiSimpleListBase<T> {
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<T> Items {
            get; set;
        }
    }
}
