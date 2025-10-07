using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    /// <summary>
    /// Request model for updating an OAuth client
    /// </summary>
    public class UpdateOAuthClientRequest {

        /// <summary>
        /// Name, which is shown at the client configuration and authorization.
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Authorized grant types
        /// </summary>
        public AuthorizedGrantTypes? GrantTypes { get; set; }

        /// <summary>
        /// Secret, which client uses at authentication.
        /// </summary>
        public string ClientSecret { get; }

        /// <summary>
        /// Determines whether client is a confidential or public client.
        /// </summary>
        public OAuthClientType? ClientType { get; set; }

        /// <summary>
        /// Determines whether client is enabled.
        /// </summary>
        public bool? IsEnabled { get; set; }

        /// <summary>
        /// URIs, to which a user is redirected after authorization.
        /// </summary>
        public IEnumerable<string> RedirectUris { get; set; }

        /// <summary>
        /// Validity of the access token in seconds.
        /// </summary>
        public int? AccessTokenValidity { get; set; }

        /// <summary>
        /// Validity of the refresh token in seconds.
        /// </summary>
        public int? RefreshTokenValidity { get; set; }

        /// <summary>
        /// Validity of the approval interval in seconds.
        /// </summary>
        public int? ApprovalValidity { get; set; }
    }
}
