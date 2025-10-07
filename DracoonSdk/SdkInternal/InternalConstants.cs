namespace Dracoon.Sdk.SdkInternal {

    #region Constants for authentication methods

    internal static class InternalAuthMethodConstants {
        public const string Basic = "basic";
        public const string Sql = "sql";
        public const string ActiveDirectory = "active_directory";
        public const string Radius = "radius";
        public const string OpenId = "openid";
        public const string Unknown = "unknown";
    }

    #endregion

    #region Constants for user types

    internal static class InternalUserTypeConstants {
        public const string Internal = "internal";
        public const string External = "external";
        public const string System = "system";
        public const string Deleted = "deleted";

    }

    #endregion

    #region Constants for OAuth clients

    internal static class InternalOAuthGrantTypeConstants {
        public const string AuthorizationCode = "authorization_code";
        public const string Implicit = "implicit";
        public const string Password = "password";
        public const string ClientCredentials = "client_credentials";
        public const string RefreshToken = "refresh_token";
    }

    internal static class InternalOAuthClientTypeConstants {
        public const string Confidential = "confidential";
        public const string Public = "public";
    }

    internal static class InternalOAuthClientDefaults {
        /// <summary>
        /// Defaults to 8 hours (value in seconds)
        /// </summary>
        public const int AccessTokenValidity = 8 * 3600;

        /// <summary>
        /// Defaults to 30 days (value in seconds)
        /// </summary>
        public const int RefreshTokenValidity = 30 * 24 * 3600;

        /// <summary>
        /// Defaults to a half year (182 days, value in seconds)
        /// </summary>
        public const int ApprovalValidity = 182 * 24 * 3600;
    }

    #endregion

    internal static class InternalConstants {

        /// <summary>
        /// The default wait time in milliseconds after the first attempt of a single HTTP request failed
        /// <para>
        /// Constant value is <c>300</c>
        /// </para>
        /// </summary>
        internal const int FirstClientRetryWaitTimeMs = 300;

        /// <summary>
        /// The default wait time in milliseconds after the second attempt of a single HTTP request failed
        /// <para>
        /// Constant value is <c>500</c>
        /// </para>
        /// </summary>
        internal const int SecondClientRetryWaitTimeMs = 500;

    }
}
