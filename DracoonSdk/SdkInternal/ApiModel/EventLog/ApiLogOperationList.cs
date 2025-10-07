using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiLogOperationList {
        [JsonProperty("operationList", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiLogOperation> Items {
            get; set;
        }
    }
}
