using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiPublicUploadShare {
        [JsonProperty("isProtected", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsProtected { get; set; }

        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("isEncrypted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsEncrypted { get; set; }

        [JsonProperty("expireAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ExpireAt { get; set; }

        [JsonProperty("notes", NullValueHandling = NullValueHandling.Ignore)]
        public string Notes { get; set; }

        [JsonProperty("ShowUploadedFiles", NullValueHandling = NullValueHandling.Ignore)]
        public bool ShowUploadedFiles { get; set; }

        [JsonProperty("remainingSize", NullValueHandling = NullValueHandling.Ignore)]
        public long? RemainingSize { get; set; }

        [JsonProperty("remainingSlots", NullValueHandling = NullValueHandling.Ignore)]
        public int? RemainingSlots { get; set; }

        [JsonProperty("creatorName", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatorName { get; set; }

        [JsonProperty("creatorUsername", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatorUsername { get; set; }

        [JsonProperty("uploadedFiles", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiPublicUploadedFileData> UploadedFiles { get; set; }
    }
}
