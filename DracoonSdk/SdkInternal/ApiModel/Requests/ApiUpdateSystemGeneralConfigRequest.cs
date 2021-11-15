using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel.Requests {
    internal class ApiUpdateSystemGeneralConfigRequest {
        [JsonProperty("sharePasswordSmsEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SharePasswordSmsEnabled { get; internal set; }

        [JsonProperty("cryptoEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CryptoEnabled { get; internal set; }

        [JsonProperty("emailNotificationButtonEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EmailNotificationButtonEnabled { get; internal set; }

        [JsonProperty("eulaEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EulaEnabled { get; internal set; }

        [JsonProperty("s3TagsEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? S3TagsEnabled { get; internal set; }

        [JsonProperty("hideLoginInputFields", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HideLoginInputFields { get; internal set; }

        [JsonProperty("authTokenRestrictions", NullValueHandling = NullValueHandling.Ignore)]
        public ApiUpdateAuthTokenRestrictionsRequest AuthTokenRestrictions { get; internal set; }
    }
}
