using Dracoon.Sdk.Model;
using System;

namespace Dracoon.Sdk {
    /// <summary>
    ///     Handler to query server informations.
    /// </summary>
    public interface IServer {
        /// <summary>
        ///     Retrieves the server's version.
        /// </summary>
        /// <returns>The server version.</returns>
        /// <exception cref="Dracoon.Sdk.Error.DracoonApiException"></exception>
        /// <exception cref="Dracoon.Sdk.Error.DracoonNetIOException"></exception>
        string GetVersion();

        /// <summary>
        ///     Retrieves the server's time.
        /// </summary>
        /// <returns>The server time.</returns>
        /// <exception cref="Dracoon.Sdk.Error.DracoonApiException"></exception>
        /// <exception cref="Dracoon.Sdk.Error.DracoonNetIOException"></exception>
        DateTime? GetTime();

        /// <summary>
        ///     Handler to query server configuration informations.
        ///     <para>
        ///         See also <seealso cref="Dracoon.Sdk.IServerSettings"/>
        ///     </para>
        /// </summary>
        IServerSettings ServerSettings { get; }

        /// <summary>
        ///         Handler to query server policy informations.
        ///     <para>
        ///         See also <seealso cref="Dracoon.Sdk.IServerPolicies"/>
        ///     </para>
        /// </summary>
        IServerPolicies ServerPolicies { get; }

        ISystemConfig SystemConfig { get; }

        PublicDownloadShare GetPublicDownloadShare(string accessKey);

        PublicUploadShare GetPublicUploadShare(string accessKey);

        /// <summary>
        /// Provides information about system.
        /// </summary>
        /// <returns><see cref="SystemInfo"/> System information is returned.</returns>
        /// <remarks>
        /// API reference: <b><c>GET /v4/public/system/info</c></b>
        /// <br/>
        /// For more information, see <see href="https://dracoon.team/api/swagger-ui/index.html?configUrl=/api/spec_v4/swagger-config#/public/requestSystemInfo"/>
        /// </remarks>
        SystemInfo GetPublicSystemInfo();

        /// <summary>
        /// Provides information about Active Directory authentication options.
        /// </summary>
        /// <returns><see cref="ActiveDirectoryAuthInfo"/> Active Directory authentication options information is returned.</returns>
        /// <remarks>
        /// API reference: <b><c>GET /v4/public/system/info/auth/ad</c></b>
        /// <br/>
        /// For more information, see <see href="https://dracoon.team/api/swagger-ui/index.html?configUrl=/api/spec_v4/swagger-config#/public/requestActiveDirectoryAuthInfo"/>
        /// </remarks>
        ActiveDirectoryAuthInfo GetPublicSystemActiveDirectoryAuth();

        /// <summary>
        /// Provides information about OpenID Connect authentication options.
        /// </summary>
        /// <returns><see cref="OpenIdAuthInfo"/> OpenID Connect authentication options information is returned.</returns>
        /// <remarks>
        /// API reference: <b><c>GET /v4/public/system/info/auth/openid</c></b>
        /// <br/>
        /// For more information, see <see href="https://dracoon.team/api/swagger-ui/index.html?configUrl=/api/spec_v4/swagger-config#/public/requestOpenIdAuthInfo"/>
        /// </remarks>
        OpenIdAuthInfo GetPublicSystemOpenIdAuth();
    }
}
