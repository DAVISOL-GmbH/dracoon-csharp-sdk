using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    /// <summary>
    /// OpenID Connect IDP configuration
    /// </summary>
    public class OpenIdIdpConfig {

        /// <summary>
        /// ID
        /// </summary>
        public int Id {
            get; internal set;
        }

        /// <summary>
        /// Name of the IDP
        /// </summary>
        public string Name {
            get; internal set;
        }

        /// <summary>
        /// Issuer identifier of the IDP
        /// The value is a case sensitive URL.
        /// </summary>
        public string Issuer {
            get; internal set;
        }

        /// <summary>
        /// URL of the authorization endpoint
        /// </summary>
        public string AuthorizationEndPointUrl {
            get; internal set;
        }

        /// <summary>
        /// URL of the token endpoint
        /// </summary>
        public string TokenEndPointUrl {
            get; internal set;
        }

        /// <summary>
        /// URL of the user info endpoint
        /// </summary>
        public string UserInfoEndPointUrl {
            get; internal set;
        }

        /// <summary>
        /// URL of the JWKS endpoint
        /// </summary>
        public string JwksEndPointUrl {
            get; internal set;
        }

        /// <summary>
        /// ID of the OpenID client
        /// </summary>
        public string ClientId {
            get; internal set;
        }

        /// <summary>
        /// Secret, which client uses at authentication.
        /// </summary>
        public string ClientSecret {
            get; internal set;
        }

        /// <summary>
        /// Flow, which is used at authentication
        /// <see cref="AuthFlowType"/>
        /// </summary>
        public AuthFlowType Flow {
            get; internal set;
        }

        /// <summary>
        /// List of requested scopes
        /// Usually openid and the names of the requested claims.
        /// </summary>
        public IEnumerable<string> Scopes {
            get; internal set;
        }

        /// <summary>
        /// URIs, to which a user is redirected after authorization.
        /// </summary>
        public IEnumerable<string> RedirectUris {
            get; internal set;
        }

        /// <summary>
        /// Determines whether PKCE is enabled. 
        /// Defaults to <c>false</c>.
        /// </summary>
        public bool PkceEnabled {
            get; internal set;
        }

        /// <summary>
        /// PKCE code challenge method.
        /// </summary>
        public string PkceChallengeMethod {
            get; internal set;
        }

        /// <summary>
        /// Name of the claim which is used for the user mapping.
        /// </summary>
        public string MappingClaim {
            get; internal set;
        }

        /// <summary>
        /// Name of the claim which is used for the user mapping fallback.
        /// </summary>
        public string FallbackMappingClaim {
            get; internal set;
        }

        /// <summary>
        /// Determines if a DRACOON account is automatically created for a new user who successfully logs on with his / her AD / IDP account. 
        /// Defaults to <c>false</c>.
        /// </summary>
        public bool UserImportEnabled {
            get; internal set;
        }

        /// <summary>
        /// User group that is assigned to users who are created by automatic import.
        /// Reset with <c>0</c>
        /// </summary>
        public long UserImportGroupId {
            get; internal set;
        }

        /// <summary>
        /// Determines if the DRACOON account is updated with data from AD / IDP.
        /// For OpenID Connect, the scopes <b>email</b> and <b>profile</b> are needed.
        /// </summary>
        public bool UserUpdateEnabled {
            get; internal set;
        }

        /// <summary>
        /// URL of the user management UI.
        /// Use empty string to remove.
        /// </summary>
        public string UserManagementUrl {
            get; internal set;
        }
    }
}
