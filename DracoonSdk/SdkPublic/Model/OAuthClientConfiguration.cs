using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    /// <summary>
    /// OAuth client information
    /// </summary>
    public class OAuthClientConfiguration {

        /// <summary>
        /// ID of the OAuth client
        /// </summary>
        public string ClientId { get; internal set; }

        /// <summary>
        /// Secret, which client uses at authentication.
        /// </summary>
        public string ClientSecret { get; internal set; }

        /// <summary>
        /// Name, which is shown at the client configuration and authorization.
        /// </summary>
        public string ClientName { get; internal set; }

        /// <summary>
        /// Determines whether client is a confidential or public client.
        /// </summary>
        /// <see cref="OAuthClientType"/>
        public OAuthClientType ClientType { get; internal set; }

        /// <summary>
        /// Determines whether client is a standard client.
        /// </summary>
        public bool IsStandard { get; internal set; }

        /// <summary>
        /// Determines whether client is an external client.
        /// </summary>
        public bool IsExternal { get; internal set; }

        /// <summary>
        /// Determines whether client is enabled.
        /// </summary>
        public bool IsEnabled { get; internal set; }

        /// <summary>
        /// Authorized grant types
        /// </summary>
        public AuthorizedGrantTypes GrantTypes { get; internal set; }

        /// <summary>
        /// URIs, to which a user is redirected after authorization.
        /// </summary>
        public IEnumerable<string> RedirectUris { get; internal set; }

        /// <summary>
        /// Validity of the access token in seconds.
        /// </summary>
        public int AccessTokenValidity { get; internal set; }

        /// <summary>
        /// Validity of the refresh token in seconds.
        /// </summary>
        public int RefreshTokenValidity { get; internal set; }

        /// <summary>
        /// Validity of the approval interval in seconds.
        /// </summary>
        public int ApprovalValidity { get; internal set; }
    }
}
