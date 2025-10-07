using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiPendingAssignmentData {
        [JsonProperty("roomId", NullValueHandling = NullValueHandling.Ignore)]
        public long RoomId {
            get; set;
        }
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State {
            get; set;
        }
        [JsonProperty("userInfo", NullValueHandling = NullValueHandling.Ignore)]
        public ApiUserInfo UserInfo {
            get; set;
        }
        [JsonProperty("groupInfo", NullValueHandling = NullValueHandling.Ignore)]
        public ApiGroupInfo GroupInfo {
            get; set;
        }
    }
}
