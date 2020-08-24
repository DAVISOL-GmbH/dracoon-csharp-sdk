using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public class OpenIdIdpConfig {

        public int Id {
            get; internal set;
        }

        public string Name {
            get; internal set;
        }

        public string Issuer {
            get; internal set;
        }

        public string AuthorizationEndPointUrl {
            get; internal set;
        }

        public string TokenEndPointUrl {
            get; internal set;
        }

        public string UserInfoEndPointUrl {
            get; internal set;
        }

        public string JwksEndPointUrl {
            get; internal set;
        }

        public string ClientId {
            get; internal set;
        }

        public string ClientSecret {
            get; internal set;
        }

        public AuthFlowType Flow {
            get; internal set;
        }

        public IEnumerable<string> Scopes {
            get; internal set;
        }

        public IEnumerable<string> RedirectUris {
            get; internal set;
        }

        public bool PkceEnabled {
            get; internal set;
        }

        public string PkceChallengeMethod {
            get; internal set;
        }

        public string MappingClaim {
            get; internal set;
        }

        public string FallbackMappingClaim {
            get; internal set;
        }

        public bool UserImportEnabled {
            get; internal set;
        }

        public long UserImportGroupId {
            get; internal set;
        }

        public bool UserUpdateEnabled {
            get; internal set;
        }

        public string UserManagementUrl {
            get; internal set;
        }
    }
}
