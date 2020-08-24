using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiActiveDirectoryConfig {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("alias", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("serverIp", NullValueHandling = NullValueHandling.Ignore)]
        public string ServerIp { get; set; }

        [JsonProperty("serverPort", NullValueHandling = NullValueHandling.Ignore)]
        public int ServerPort { get; set; }

        [JsonProperty("serverAdminName", NullValueHandling = NullValueHandling.Ignore)]
        public string ServerAdminName { get; set; }

        [JsonProperty("ldapUsersDomain", NullValueHandling = NullValueHandling.Ignore)]
        public string LdapUsersDomain { get; set; }

        [JsonProperty("userFilter", NullValueHandling = NullValueHandling.Ignore)]
        public string UserFilter { get; set; }

        [JsonProperty("userImport", NullValueHandling = NullValueHandling.Ignore)]
        public bool UserImport { get; set; }

        [JsonProperty("adExportGroup", NullValueHandling = NullValueHandling.Ignore)]
        public string AdExportGroup { get; set; }

        [JsonProperty("useLdaps", NullValueHandling = NullValueHandling.Ignore)]
        public bool UseLdaps { get; set; }

        [JsonProperty("sdsImportGroup", NullValueHandling = NullValueHandling.Ignore)]
        public long UserImportGroupId { get; set; }

        [JsonProperty("sslFingerprint", NullValueHandling = NullValueHandling.Ignore)]
        public string SslFingerprint { get; set; }
    }
}
