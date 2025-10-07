using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal abstract class ApiIdListBase {
        [JsonProperty("ids", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<long> Ids {
            get; set;
        }
    }
}
