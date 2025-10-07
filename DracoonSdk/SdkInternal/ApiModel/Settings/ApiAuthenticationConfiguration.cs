using Newtonsoft.Json;
using System.Collections.Generic;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiAuthenticationConfiguration {
        [JsonProperty("authMethods", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiAuthenticationMethod> AuthMethods {
            get; set;
        }
    }
}
