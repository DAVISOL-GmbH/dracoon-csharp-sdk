namespace Dracoon.Sdk.Model {
    /// <summary>
    /// Request model for updating auth token settings
    /// </summary>
    public class UpdateAuthTokenRestrictionsRequest {

        /// <summary>
        /// Defines if OAuth token restrictions are enabled
        /// </summary>
        public bool OverwriteEnabled { get; }

        /// <summary>
        /// Restricted OAuth access token validity (in seconds)
        /// </summary>
        public int? AccessTokenValidity { get; set; }

        /// <summary>
        /// Restricted OAuth refresh token validity (in seconds)
        /// </summary>
        public int? RefreshTokenValidity { get; set; }


        public UpdateAuthTokenRestrictionsRequest(bool overwriteEnabled) {
            OverwriteEnabled = overwriteEnabled;
        }
    }
}
