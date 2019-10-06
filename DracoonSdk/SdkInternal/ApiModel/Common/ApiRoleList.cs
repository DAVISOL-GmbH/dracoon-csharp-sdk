using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiRoleList {
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiRole> Items {
            get; set;
        }
    }
}
