using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiOpenIdIdpConfig {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("issuer", NullValueHandling = NullValueHandling.Ignore)]
        public string Issuer { get; set; }

        [JsonProperty("authorizationEndPointUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorizationEndPointUrl { get; set; }

        [JsonProperty("tokenEndPointUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string TokenEndPointUrl { get; set; }

        [JsonProperty("userInfoEndPointUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string UserInfoEndPointUrl { get; set; }

        [JsonProperty("jwksEndPointUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string JwksEndPointUrl { get; set; }

        [JsonProperty("clientId", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientId { get; set; }

        [JsonProperty("clientSecret", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientSecret { get; set; }

        [JsonProperty("flow", NullValueHandling = NullValueHandling.Ignore)]
        public string Flow { get; set; }

        [JsonProperty("scopes", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Scopes { get; set; }

        [JsonProperty("redirectUris", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> RedirectUris { get; set; }

        [JsonProperty("pkceEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool PkceEnabled { get; set; }

        [JsonProperty("pkceChallengeMethod", NullValueHandling = NullValueHandling.Ignore)]
        public string PkceChallengeMethod { get; set; }

        [JsonProperty("mappingClaim", NullValueHandling = NullValueHandling.Ignore)]
        public string MappingClaim { get; set; }

        [JsonProperty("fallbackMappingClaim", NullValueHandling = NullValueHandling.Ignore)]
        public string FallbackMappingClaim { get; set; }

        [JsonProperty("userImportEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool UserImportEnabled { get; set; }

        [JsonProperty("userImportGroup", NullValueHandling = NullValueHandling.Ignore)]
        public long UserImportGroupId { get; set; }

        [JsonProperty("userUpdateEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool UserUpdateEnabled { get; set; }

        [JsonProperty("userManagementUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string UserManagementUrl { get; set; }
    }
}
