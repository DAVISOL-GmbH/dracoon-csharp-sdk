using System;
using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    /// <summary>
    /// System information (default language and authentication methods).
    /// </summary>
    /// <remarks>
    /// API reference: <b><c>GET /v4/public/system/info</c></b>
    /// <br/>
    /// For more information, see <see href="https://dracoon.team/api/swagger-ui/index.html?configUrl=/api/spec_v4/swagger-config#/public/requestSystemInfo"/>
    /// </remarks>
    public class SystemInfo {
        /// <summary>
        /// System default language
        /// </summary>
        /// <remarks>
        /// cf. <see href="https://tools.ietf.org/html/rfc5646">RFC 5646</see>
        /// </remarks>
        public string LanguageDefault { get; internal set; }

        /// <summary>
        /// Defines if login fields should be hidden
        /// </summary>
        /// <remarks>
        /// Since v4.13.0
        /// </remarks>
        public bool HideLoginInputFields { get; internal set; }


        /// <summary>
        /// List of S3 Hosts for CSP header
        /// </summary>
        /// <remarks>
        /// Since v4.14.0
        /// </remarks>
        public IEnumerable<string> S3Hosts { get; internal set; }

        /// <summary>
        /// Determines whether S3 direct upload is enforced or not
        /// </summary>
        /// <remarks>
        /// Since v4.15.0
        /// </remarks>
        public bool S3EnforceDirectUpload { get; internal set; }

        /// <summary>
        /// Defines if S3 is used as storage backend
        /// </summary>
        /// <remarks>
        /// Since v4.21.0
        /// </remarks>
        public bool UseS3Storage { get; internal set; }

        /// <summary>
        /// Authentication methods
        /// </summary>
        /// <remarks>
        /// <b>WARNING</b> Deprecated since v4.13.0
        /// </remarks>
        [Obsolete("Deprecated since v4.13.0")]
        public IEnumerable<ServerAuthenticationMethod> AuthMethods { get; internal set; }
    }
}
