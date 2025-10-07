using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel.Requests {
    internal class ApiCreateRoomRequest : ApiCreateNodeRequestBase {
        [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
        public long? ParentId { get; set; }

        [JsonProperty("quota", NullValueHandling = NullValueHandling.Ignore)]
        public long? Quota { get; set; }

        [JsonProperty("recycleBinRetentionPeriod", NullValueHandling = NullValueHandling.Ignore)]
        public int? RecycleBinRetentionPeriod { get; set; }

        [JsonProperty("inheritPermissions", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InheritPermissions { get; set; }

        [JsonProperty("adminIds", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> AdminIds { get; set; }

        [JsonProperty("adminGroupIds", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> AdminGroupIds { get; set; }

        [JsonProperty("newGroupMemberAcceptance", NullValueHandling = NullValueHandling.Ignore)]
        public string NewGroupMemberAcceptance { get; set; }

        [JsonProperty("hasActivitiesLog", NullValueHandling = NullValueHandling.Ignore)]
        public bool HasActivitiesLog { get; set; }
    }
}
