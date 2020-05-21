using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiSimpleImageResponse {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type {
            get; internal set;
        }
        [JsonProperty("files", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiImageFileResponse> Files {
            get; internal set;
        }
    }
}
