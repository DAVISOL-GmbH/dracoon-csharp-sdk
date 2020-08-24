using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiFailoverServer {
        [JsonProperty("failoverEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool FailoverEnabled { get; set; }

        [JsonProperty("failoverIpAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string FailoverIpAddress { get; set; }

        [JsonProperty("failoverPort", NullValueHandling = NullValueHandling.Ignore)]
        public int FailoverPort { get; set; }
    }
}
