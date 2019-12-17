using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiAuthenticationMethod {

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        internal string Name { get; set; }

        [JsonProperty("isEnabled", NullValueHandling = NullValueHandling.Ignore)]
        internal bool IsEnabled { get; set; }

        [JsonProperty("priority", NullValueHandling = NullValueHandling.Ignore)]
        internal int Priority { get; set; }
    }
}
