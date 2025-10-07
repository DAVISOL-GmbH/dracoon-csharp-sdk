using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiRadiusConfig {
        [JsonProperty("ipAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string IpAddress { get; set; }

        [JsonProperty("port", NullValueHandling = NullValueHandling.Ignore)]
        public int Port { get; set; }

        [JsonProperty("sharedSecret", NullValueHandling = NullValueHandling.Ignore)]
        public string SharedSecret { get; set; }

        [JsonProperty("otpPinFirst", NullValueHandling = NullValueHandling.Ignore)]
        public bool OtpPinFirst { get; set; }

        [JsonProperty("failoverServer", NullValueHandling = NullValueHandling.Ignore)]
        public ApiFailoverServer FailoverServer { get; set; }
    }
}
