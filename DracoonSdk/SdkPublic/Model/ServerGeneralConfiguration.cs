namespace Dracoon.Sdk.Model {
    /// <summary>
    /// This model stores informations about the general configuration of the server
    /// </summary>
    public class ServerGeneralConfiguration {

        /// <summary>
        /// Is <c>true</c> if share passwords can be send via SMS. Otherwise <c>false</c>.
        /// </summary>
        public bool SharePasswordSmsEnabled { get; internal set; }

        /// <summary>
        /// Is <c>true</c> if cliend-side cryptography is available for rooms. Otherwise <c>false</c>.
        /// </summary>
        public bool CryptoEnabled { get; internal set; }

        /// <summary>
        /// Is <c>true</c> if the email notification button is enabled. Otherwise <c>false</c>.
        /// </summary>
        public bool EmailNotificationButtonEnabled { get; internal set; }

        /// <summary>
        /// Is <c>true</c> if each user has to confirm the EULA at first login. Otherwise <c>false</c>.
        /// </summary>
        public bool EulaEnabled { get; internal set; }

        /// <summary>
        /// Is <c>true</c> if S3 is used as storage backend. Otherwise <c>false</c>.
        /// </summary>
        public bool UseS3Storage { get; internal set; }

        /// <summary>
        /// Is <c>true</c> if S3 tags are enabled. Otherwise <c>false</c>.
        /// </summary>
        public bool S3TagsEnabled { get; internal set; }

        /// <summary> 
        /// Is<c>true</c> if the input fields should be hidden. Otherwise<c>false</c>.
        /// </summary>
        public bool HideLoginInputFields { get; internal set; }

        /// <summary>
        /// This model stores the restrictions for OAuth tokens.
        /// </summary>
        public AuthTokenRestrictions AuthTokenRestrictions { get; internal set; }
    }
}
