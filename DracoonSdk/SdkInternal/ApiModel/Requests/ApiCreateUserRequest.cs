using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel.Requests {
    internal class ApiCreateUserRequest {
        [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName {
            get; internal set;
        }
        [JsonProperty("lastName", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName {
            get; internal set;
        }
        [JsonProperty("userName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName {
            get; internal set;
        }
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title {
            get; internal set;
        }
        [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)]
        public string Gender {
            get; internal set;
        }
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone {
            get; internal set;
        }
        [JsonProperty("expiration", NullValueHandling = NullValueHandling.Ignore)]
        public ApiExpiration ExpireAt {
            get; internal set;
        }
        [JsonProperty("receiverLanguage", NullValueHandling = NullValueHandling.Ignore)]
        public string ReceiverLanguage {
            get; internal set;
        }
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email {
            get; internal set;
        }
        [JsonProperty("notifyUser", NullValueHandling = NullValueHandling.Ignore)]
        public bool NotifyUser {
            get; internal set;
        }
        [JsonProperty("authData", NullValueHandling = NullValueHandling.Ignore)]
        public ApiUserAuthData AuthData {
            get; internal set;
        }
        [JsonProperty("isNonmemberViewer", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsNonmemberViewer {
            get; internal set;
        }
    }
}
