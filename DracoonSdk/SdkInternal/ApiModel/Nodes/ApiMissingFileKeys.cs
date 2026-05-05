using Newtonsoft.Json;
using System.Collections.Generic;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiMissingFileKeys : ApiRangeListBase<ApiUserIdFileId> {

        [JsonProperty("users", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiUserIdPublicKey> UserPublicKey { get; set; }

        [JsonProperty("files", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiFileIdFileKey> FileKeys { get; set; }
    }
}