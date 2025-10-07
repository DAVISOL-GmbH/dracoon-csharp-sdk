using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiRoomGroup : ApiGroupInfo {
        [JsonProperty("isGranted", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsGranted {
            get; set;
        }
        [JsonProperty("newGroupMemberAcceptance", NullValueHandling = NullValueHandling.Ignore)]
        public string NewGroupMemberAcceptance {
            get; set;
        }
        [JsonProperty("permissions", NullValueHandling = NullValueHandling.Ignore)]
        public ApiNodePermissions Permissions {
            get; set;
        }
    }
}
