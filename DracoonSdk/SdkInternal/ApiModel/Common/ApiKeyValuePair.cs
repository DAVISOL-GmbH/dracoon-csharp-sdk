using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel.Common {
    internal class ApiKeyValuePair {
        [JsonConstructor]
        internal ApiKeyValuePair() { }

        internal ApiKeyValuePair(KeyValuePair<string, string> keyValuePair) {
            Key = keyValuePair.Key;
            Value = keyValuePair.Value;
        }

        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key {
            get; set;
        }
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value {
            get; set;
        }
    }
}
