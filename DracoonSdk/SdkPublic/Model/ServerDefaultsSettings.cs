using System.Globalization;

namespace Dracoon.Sdk.Model {
    /// <include file = "ModelDoc.xml" path='docs/members[@name="serverDefaultSettings"]/ServerDefaultSettings/*'/>
    public class ServerDefaultSettings {
        /// <include file = "ModelDoc.xml" path='docs/members[@name="serverDefaultSettings"]/LanguageDefault/*'/>
        public CultureInfo LanguageDefault { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="serverDefaultSettings"]/DownloadShareDefaultExpirationPeriodInDays/*'/>
        public int DownloadShareDefaultExpirationPeriodInDays { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="serverDefaultSettings"]/UploadShareDefaultExpirationPeriodInDays/*'/>
        public int UploadShareDefaultExpirationPeriodInDays { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="serverDefaultSettings"]/FileUploadDefaultExpirationPeriodInDays/*'/>
        public int FileUploadDefaultExpirationPeriodInDays { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="serverDefaultSettings"]/NonmemberViewerDefault/*'/>
        public bool NonmemberViewerDefault { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="serverDefaultSettings"]/HideLoginInputFields/*'/>
        public bool HideLoginInputFields { get; internal set; }
    }
}
