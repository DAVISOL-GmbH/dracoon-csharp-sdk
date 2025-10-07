using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiRoomUser {
        [JsonProperty("userInfo", NullValueHandling = NullValueHandling.Ignore)]
        public ApiUserInfo UserInfo {
            get; internal set;
        }
        [JsonProperty("isGranted", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsGranted {
            get; internal set;
        }
        [JsonProperty("permissions", NullValueHandling = NullValueHandling.Ignore)]
        public ApiNodePermissions Permissions {
            get; internal set;
        }
        [JsonProperty("publicKeyContainer", NullValueHandling = NullValueHandling.Ignore)]
        public ApiUserPublicKey PublicKeyContainer {
            get; internal set;
        }
    }
}
