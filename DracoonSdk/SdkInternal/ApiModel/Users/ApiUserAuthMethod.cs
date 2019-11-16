using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiUserAuthMethod {
        [JsonProperty("authId", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthId {
            get; internal set;
        }
        [JsonProperty("isEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsEnabled {
            get; internal set;
        }
        [JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
        public List<KeyValuePair<string, string>> Options {
            get; internal set;
        }
    }
}
