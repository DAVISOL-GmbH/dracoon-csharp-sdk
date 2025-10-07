using System.ComponentModel;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiAuthTokenRestrictions {
        [DefaultValue(false)]
        [JsonProperty("restrictionEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool RestrictionEnabled { get; set; }

        [JsonProperty("accessTokenValidity", NullValueHandling = NullValueHandling.Ignore)]
        public int AccessTokenValidity { get; set; }

        [JsonProperty("refreshTokenValidity", NullValueHandling = NullValueHandling.Ignore)]
        public int RefreshTokenValidity { get; set; }
    }
}
