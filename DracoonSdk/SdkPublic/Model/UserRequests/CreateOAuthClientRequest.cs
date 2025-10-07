using Dracoon.Sdk.SdkInternal;
using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    /// <summary>
    /// Request model for creating an OAuth client
    /// </summary>
    public class CreateOAuthClientRequest {

        /// <summary>
        /// Name, which is shown at the client configuration and authorization.
        /// </summary>
        public string ClientName {
            get;
        }

        /// <summary>
        /// Authorized grant types
        /// </summary>
        public AuthorizedGrantTypes GrantTypes {
            get;
        }

        /// <summary>
        /// ID of the OAuth client
        /// </summary>
        public string ClientId { get; }

        /// <summary>
        /// Secret, which client uses at authentication.
        /// </summary>
        public string ClientSecret { get; }

        /// <summary>
        /// Determines whether client is a confidential or public client.
        /// </summary>
        public OAuthClientType ClientType { get; }

        /// <summary>
        /// URIs, to which a user is redirected after authorization.
        /// </summary>
        public ICollection<string> RedirectUris { get; } = new List<string>();

        /// <summary>
        /// Validity of the access token in seconds.
        /// </summary>
        public int AccessTokenValidity { get; set; }

        /// <summary>
        /// Validity of the refresh token in seconds.
        /// </summary>
        public int RefreshTokenValidity { get; set; }

        /// <summary>
        /// Validity of the approval interval in seconds.
        /// </summary>
        public int ApprovalValidity { get; set; }

        public CreateOAuthClientRequest(string clientName, AuthorizedGrantTypes grantTypes, string clientId, string clientSecret, OAuthClientType clientType = OAuthClientType.Confidential, params string[] redirectionUris) {
            ClientName = clientName;
            GrantTypes = grantTypes;
            ClientId = clientId;
            ClientSecret = clientSecret;
            ClientType = clientType;
            AccessTokenValidity = InternalOAuthClientDefaults.AccessTokenValidity;
            RefreshTokenValidity = InternalOAuthClientDefaults.RefreshTokenValidity;
            ApprovalValidity = InternalOAuthClientDefaults.ApprovalValidity;
            if (redirectionUris != null && redirectionUris.Length > 0) {
                foreach (var redirectUri in redirectionUris) {
                    RedirectUris.Add(redirectUri);
                }
            }
        }
    }
}
