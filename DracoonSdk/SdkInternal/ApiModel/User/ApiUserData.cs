using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiUserData : ApiUserItem {
        [JsonProperty("authData", NullValueHandling = NullValueHandling.Ignore)]
        public ApiAuthData AuthData {
            get; internal set;
        }
        [JsonProperty("authMethods", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiUserAuthMethod> AuthMethods {
            get; internal set;
        }
        [JsonProperty("publicKeyContainer", NullValueHandling = NullValueHandling.Ignore)]
        public ApiUserPublicKey PublicKeyContainer {
            get; internal set;
        }
    }
}
