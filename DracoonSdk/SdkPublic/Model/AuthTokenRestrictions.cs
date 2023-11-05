namespace Dracoon.Sdk.Model {
    /// <summary>
    /// This model stores the restrictions for OAuth tokens.
    /// </summary>
    public class AuthTokenRestrictions {

        /// <summary>
        /// Is <c>true</c> if OAuth token restrictions are enabled. Otherwise <c>false</c>.
        /// </summary>
        public bool RestrictionEnabled {
            get; internal set;
        }

        /// <summary>
        /// The restricted OAuth access token validity (in seconds).
        /// </summary>
        public int AccessTokenValidity {
            get; internal set;
        }

        /// <summary>
        /// The restricted OAuth refresh token validity (in seconds).
        /// </summary>
        public int RefreshTokenValidity {
            get; internal set;
        }
    }
}
