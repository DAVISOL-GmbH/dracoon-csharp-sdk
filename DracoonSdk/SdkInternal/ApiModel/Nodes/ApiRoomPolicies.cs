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
        // Only in the GET /api/v4/nodes/rooms/{roomId}/policies route, the virusProtectionEnabled property is named isVirusProtectionEnabled in the API response
        // See also: https://files.davisol.com/api/swagger-ui/index.html#/nodes/requestRoomPolicies
        [JsonProperty("isVirusProtectionEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool VirusProtectionEnabled {
            get; internal set;
        }
    }
}
