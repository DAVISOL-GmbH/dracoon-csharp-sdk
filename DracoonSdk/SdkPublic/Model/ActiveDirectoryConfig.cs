namespace Dracoon.Sdk.Model {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ActiveDirectoryConfig {

        public int Id {
            get; internal set;
        }

        public string Name {
            get; internal set;
        }

        public string ServerIp {
            get; internal set;
        }

        public int ServerPort {
            get; internal set;
        }

        public string ServerAdminName {
            get; internal set;
        }

        public string LdapUsersDomain {
            get; internal set;
        }

        public string UserFilter {
            get; internal set;
        }

        public bool UserImport {
            get; internal set;
        }

        public string AdExportGroup {
            get; internal set;
        }

        public bool UseLdaps {
            get; internal set;
        }

        public long UserImportGroupId {
            get; internal set;
        }

        public string SslFingerprint {
            get; internal set;
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
