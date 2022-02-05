using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiSystemInfo {
        [JsonProperty("languageDefault", NullValueHandling = NullValueHandling.Ignore)]
        public string LanguageDefault { get; set; }

        [JsonProperty("hideLoginInputFields", NullValueHandling = NullValueHandling.Ignore)]
        public bool HideLoginInputFields { get; set; }


        [JsonProperty("s3Hosts", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> S3Hosts { get; set; }

        [JsonProperty("s3EnforceDirectUpload", NullValueHandling = NullValueHandling.Ignore)]
        public bool S3EnforceDirectUpload { get; set; }

        [JsonProperty("useS3Storage", NullValueHandling = NullValueHandling.Ignore)]
        public bool UseS3Storage { get; set; }

        [JsonProperty("authMethods", NullValueHandling = NullValueHandling.Ignore)]
        [Obsolete("Deprecated since v4.13.0")]
        public IEnumerable<ApiAuthenticationMethod> AuthMethods { get; set; }
    }
}
