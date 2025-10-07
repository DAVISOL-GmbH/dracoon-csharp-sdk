using Newtonsoft.Json;
using System.Collections.Generic;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiAlgorithms {
        [JsonProperty("fileKeyAlgorithms", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiAlgorithm> FileKeyAlgorithms { get; set; }
        [JsonProperty("keyPairAlgorithms", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiAlgorithm> KeyPairAlgorithms { get; set; }
    }
}
