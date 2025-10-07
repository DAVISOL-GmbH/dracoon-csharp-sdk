using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiText {
        [JsonProperty("languages", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiLanguage> Languages {
            get; internal set;
        }
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type {
            get; internal set;
        }
    }
}
