using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiLanguage {
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content {
            get; internal set;
        }
        [JsonProperty("languageTag", NullValueHandling = NullValueHandling.Ignore)]
        public string LanguageTag {
            get; internal set;
        }
    }
}
