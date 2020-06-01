using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiPublicDownloadShare {
        [JsonProperty("isProtected", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsProtected { get; set; }

        [JsonProperty("fileName", NullValueHandling = NullValueHandling.Ignore)]
        public string FileName { get; set; }

        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public long Size { get; set; }

        [JsonProperty("limitReached", NullValueHandling = NullValueHandling.Ignore)]
        public bool LimitReached { get; set; }

        [JsonProperty("creatorName", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatorName { get; set; }

        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("hasDownloadLimit", NullValueHandling = NullValueHandling.Ignore)]
        public bool HasDownloadLimit { get; set; }

        [JsonProperty("mediaType", NullValueHandling = NullValueHandling.Ignore)]
        public string MediaType { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("creatorUsername", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatorUsername { get; set; }

        [JsonProperty("expireAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ExpireAt { get; set; }

        [JsonProperty("notes", NullValueHandling = NullValueHandling.Ignore)]
        public string Notes { get; set; }

        [JsonProperty("isEncrypted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsEncrypted { get; set; }

    }
}
