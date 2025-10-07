using Newtonsoft.Json;
using System.Collections.Generic;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiOAuthClientConfiguration {

        [JsonProperty("clientId", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientId { get; set; }

        [JsonProperty("clientSecret", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientSecret { get; set; }

        [JsonProperty("clientName", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientName { get; set; }

        [JsonProperty("clientType", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientType { get; set; }

        [JsonProperty("isStandard", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsStandard { get; set; }

        [JsonProperty("isExternal", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsExternal { get; set; }

        [JsonProperty("isEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsEnabled { get; set; }

        [JsonProperty("grantTypes", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> GrantTypes { get; set; }

        [JsonProperty("redirectUris", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> RedirectUris { get; set; }

        [JsonProperty("accessTokenValidity", NullValueHandling = NullValueHandling.Ignore)]
        public int AccessTokenValidity { get; set; }

        [JsonProperty("refreshTokenValidity", NullValueHandling = NullValueHandling.Ignore)]
        public int RefreshTokenValidity { get; set; }

        [JsonProperty("approvalValidity", NullValueHandling = NullValueHandling.Ignore)]
        public int ApprovalValidity { get; set; }
    }
}
