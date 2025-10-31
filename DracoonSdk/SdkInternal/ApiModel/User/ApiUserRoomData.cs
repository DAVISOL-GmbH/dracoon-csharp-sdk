using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiUserRoomData {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("isGranted", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsGranted { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("isEncrypted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsEncrypted { get; set; }

        //[JsonProperty("recycleBinRetentionPeriod", NullValueHandling = NullValueHandling.Ignore)]
        //public int? RecycleBinRetentionPeriod { get; set; }

        [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
        public long? ParentId { get; set; }

        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public long? Size { get; set; }

        [JsonProperty("permissions", NullValueHandling = NullValueHandling.Ignore)]
        public ApiNodePermissions Permissions { get; set; }

        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("createdBy", NullValueHandling = NullValueHandling.Ignore)]
        public ApiUserInfo CreatedBy { get; set; }

        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("updatedBy", NullValueHandling = NullValueHandling.Ignore)]
        public ApiUserInfo UpdatedBy { get; set; }

        [JsonProperty("quota", NullValueHandling = NullValueHandling.Ignore)]
        public long? Quota { get; set; }

        [JsonProperty("cntDownloadShares", NullValueHandling = NullValueHandling.Ignore)]
        public int? CountDownloadShares { get; set; }

        [JsonProperty("cntUploadShares", NullValueHandling = NullValueHandling.Ignore)]
        public int? CountUploadShares { get; set; }

        [JsonProperty("isFavorite", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsFavorite { get; set; }

        [JsonProperty("children", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<ApiUserRoomData> Children { get; set; }
    }
}
