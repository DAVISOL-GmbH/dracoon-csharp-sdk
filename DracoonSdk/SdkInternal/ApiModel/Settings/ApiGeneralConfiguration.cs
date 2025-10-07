using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiGeneralConfiguration {
        [JsonProperty("sharePasswordSmsEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool SharePasswordSmsEnabled { get; set; }

        [JsonProperty("cryptoEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool CryptoEnabled { get; set; }

        [JsonProperty("emailNotificationButtonEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool EmailNotificationButtonEnabled { get; set; }

        [JsonProperty("eulaEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool EulaEnabled { get; set; }

        [JsonProperty("mediaServerEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool MediaServerEnabled { get; set; }

        [JsonProperty("useS3Storage", NullValueHandling = NullValueHandling.Ignore)]
        public bool UseS3Storage { get; set; }

        [JsonProperty("s3TagsEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool S3TagsEnabled { get; set; }

        [JsonProperty("hideLoginInputFields", NullValueHandling = NullValueHandling.Ignore)]
        public bool HideLoginInputFields { get; set; }

        [JsonProperty("authTokenRestrictions", NullValueHandling = NullValueHandling.Ignore)]
        public ApiAuthTokenRestrictions AuthTokenRestrictions { get; set; }
    }
}
