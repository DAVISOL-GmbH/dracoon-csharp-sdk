using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiRoomGroupsAddBatchRequestItem {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id {
            get; set;
        }
        [JsonProperty("permissions", NullValueHandling = NullValueHandling.Ignore)]
        public ApiNodePermissions Permissions {
            get; set;
        }
        [JsonProperty("newGroupMemberAcceptance", NullValueHandling = NullValueHandling.Ignore)]
        public string NewGroupMemberAcceptance {
            get; set;
        }
    }
}
