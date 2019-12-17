using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiAuthenticationSettings {
        [JsonProperty("authMethods", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiAuthenticationMethod> AuthMethods {
            get; set;
        }
    }
}
