using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel.Requests {
    internal class ApiUpdateAuthTokenRestrictionsRequest {
        [JsonProperty("overwriteEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool OverwriteEnabled { get; internal set; }

        [JsonProperty("accessTokenValidity", NullValueHandling = NullValueHandling.Ignore)]
        public int? AccessTokenValidity { get; internal set; }

        [JsonProperty("refreshTokenValidity", NullValueHandling = NullValueHandling.Ignore)]
        public int? RefreshTokenValidity { get; internal set; }
    }
}
