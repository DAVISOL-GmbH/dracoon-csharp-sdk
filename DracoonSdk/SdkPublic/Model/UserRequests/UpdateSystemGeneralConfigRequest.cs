namespace Dracoon.Sdk.Model {
    /// <summary>
    /// Request model for updating general settings
    /// </summary>
    public class UpdateSystemGeneralConfigRequest {

        /// <summary>
        /// Determines whether sending of share passwords via SMS is allowed.
        /// </summary>
        public bool? SharePasswordSmsEnabled { get; set; }

        /// <summary>
        /// Determines whether client-side encryption is enabled.
        /// Can only be enabled once; disabling is <b>NOT</b> possible.
        /// </summary>
        public bool? CryptoEnabled { get; set; }

        /// <summary>
        /// Determines whether email notification button is enabled.
        /// </summary>
        public bool? EmailNotificationButtonEnabled { get; set; }

        /// <summary>
        /// Determines whether EULA is enabled.
        /// Each user has to confirm the EULA at first login.
        /// </summary>
        public bool? EulaEnabled { get; set; }

        /// <summary>
        /// Defines if S3 tags are enabled
        /// </summary>
        public bool? S3TagsEnabled { get; set; }

        /// <summary>
        /// Determines whether input fields for login should be enabled
        /// </summary>
        public bool? HideLoginInputFields { get; set; }

        /// <summary>
        /// Determines auth token restrictions. (e.g. restricted access token validity)
        /// </summary>
        public UpdateAuthTokenRestrictionsRequest AuthTokenRestrictions { get; set; }
    }
}
