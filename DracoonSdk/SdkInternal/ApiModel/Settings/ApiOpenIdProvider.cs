using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiOpenIdProvider {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("alias", NullValueHandling = NullValueHandling.Ignore)]
        public string Alias { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("isGlobalAvailable", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsGlobalAvailable { get; set; }

        [JsonProperty("issuer", NullValueHandling = NullValueHandling.Ignore)]
        public string Issuer { get; set; }

        [JsonProperty("mappingClaim", NullValueHandling = NullValueHandling.Ignore)]
        public string MappingClaim { get; set; }

        [JsonProperty("userManagementUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string UserManagementUrl { get; set; }

    }
}
