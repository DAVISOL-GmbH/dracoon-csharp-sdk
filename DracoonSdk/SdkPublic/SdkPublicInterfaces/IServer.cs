using Dracoon.Sdk.Model;
using System;

namespace Dracoon.Sdk {
    /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iServer"]/IServer/*'/>
    public interface IServer {
        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iServer"]/GetVersion/*'/>
        string GetVersion();

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iServer"]/GetTime/*'/>
        DateTime? GetTime();

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iServer"]/ServerSettings/*'/>
        IServerSettings ServerSettings { get; }

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iServer"]/ServerPolicies/*'/>
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
