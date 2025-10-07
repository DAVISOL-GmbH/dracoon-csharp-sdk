using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiRoomPolicies {
        [JsonProperty("defaultExpirationPeriod", NullValueHandling = NullValueHandling.Ignore)]
        public int DefaultExpirationPeriod {
            get; internal set;
        }
        [JsonProperty("virusProtectionEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool VirusProtectionEnabled {
            get; internal set;
        }
    }
}
