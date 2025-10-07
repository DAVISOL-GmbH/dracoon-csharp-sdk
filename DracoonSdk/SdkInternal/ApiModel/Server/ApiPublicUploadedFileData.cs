using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiPublicUploadedFileData {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public long Size { get; set; }

        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }
}
