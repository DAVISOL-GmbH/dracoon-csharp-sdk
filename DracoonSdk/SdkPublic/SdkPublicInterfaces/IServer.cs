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
    }
}
