using System;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiUserInfo {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id {
            get; set;
        }
        [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
        [Obsolete("Deprecated since version 4.11.0, use other fields from UserInfo instead to combine a display name")]
        public string DisplayName {
            get; set;
        }
        [JsonProperty("avatarUuid", NullValueHandling = NullValueHandling.Ignore)]
        public string AvatarUuid {
            get; set;
        }
        [JsonProperty("userName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName {
            get; set;
        }
        [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName {
            get; set;
        }
        [JsonProperty("lastName", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName {
            get; set;
        }
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email {
            get; set;
        }
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title {
            get; set;
        }
    }
}
