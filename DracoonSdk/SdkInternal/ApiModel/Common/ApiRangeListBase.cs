using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal abstract class ApiRangeListBase<T> : ApiSimpleListBase<T> {
        [JsonProperty("range", NullValueHandling = NullValueHandling.Ignore)]
        public ApiRange Range {
            get; set;
        }
    }
}
