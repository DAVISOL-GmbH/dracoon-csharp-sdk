using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiColor {
        [JsonProperty("colorDetails", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiColorDetails> ColorDetails {
            get; internal set;
        }
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type {
            get; internal set;
        }
    }
}
