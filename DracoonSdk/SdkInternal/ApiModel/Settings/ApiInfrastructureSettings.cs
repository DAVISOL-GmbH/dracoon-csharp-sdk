using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiInfrastructureSettings {
        [JsonProperty("smsConfigEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool SmsConfigEnabled {
            get; set;
        }
        [JsonProperty("mediaServerConfigEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool MediaServerConfigEnabled {
            get; set;
        }
        [JsonProperty("s3DefaultRegion", NullValueHandling = NullValueHandling.Ignore)]
        public string S3DefaultRegion {
            get; set;
        }
        [DefaultValue(false)]
        [JsonProperty("s3EnforceDirectUpload", DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool S3EnforceDirectUpload {
            get; set;
        }

        [JsonProperty("dracoonCloud", DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool DracoonCloud {
            get; set;
        }

        [JsonProperty("tenantUuid", DefaultValueHandling = DefaultValueHandling.Populate)]
        public Guid TenantUuid {
            get; set;
        }
    }
}
