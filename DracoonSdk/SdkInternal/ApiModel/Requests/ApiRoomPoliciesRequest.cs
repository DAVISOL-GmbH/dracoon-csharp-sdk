using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dracoon.Sdk.SdkInternal.ApiModel.Requests {
    internal class ApiRoomPoliciesRequest {
        [JsonProperty("defaultExpirationPeriod", NullValueHandling = NullValueHandling.Ignore)]
        public int? DefaultExpirationPeriod {
            get; set;
        }
        [JsonProperty("virusProtectionEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VirusProtectionEnabled {
            get; set;
        }
    }
}
