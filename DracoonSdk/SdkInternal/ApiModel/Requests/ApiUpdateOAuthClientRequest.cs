using Newtonsoft.Json;
using System.Collections.Generic;

namespace Dracoon.Sdk.SdkInternal.ApiModel.Requests {
    internal class ApiUpdateOAuthClientRequest {

        [JsonProperty("clientName", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientName { get; internal set; }

        [JsonProperty("grantTypes", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> GrantTypes { get; internal set; }

        [JsonProperty("clientSecret", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientSecret { get; internal set; }

        [JsonProperty("clientType", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientType { get; internal set; }

        [JsonProperty("isEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsEnabled { get; internal set; }

        [JsonProperty("redirectUris", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> RedirectUris { get; internal set; }

        [JsonProperty("accessTokenValidity", NullValueHandling = NullValueHandling.Ignore)]
        public int? AccessTokenValidity { get; internal set; }

        [JsonProperty("refreshTokenValidity", NullValueHandling = NullValueHandling.Ignore)]
        public int? RefreshTokenValidity { get; internal set; }

        [JsonProperty("approvalValidity", NullValueHandling = NullValueHandling.Ignore)]
        public int? ApprovalValidity { get; internal set; }
    }
}
