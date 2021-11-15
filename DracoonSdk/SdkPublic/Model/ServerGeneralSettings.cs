namespace Dracoon.Sdk.Model {
    /// <include file = "ModelDoc.xml" path='docs/members[@name="serverGeneralSettings"]/ServerGeneralSettings/*'/>
    public class ServerGeneralSettings {
        /// <include file = "ModelDoc.xml" path='docs/members[@name="serverGeneralSettings"]/SharePasswordSmsEnabled/*'/>
        public bool SharePasswordSmsEnabled { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="serverGeneralSettings"]/CryptoEnabled/*'/>
        public bool CryptoEnabled { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="serverGeneralSettings"]/EmailNotificationButtonEnabled/*'/>
        public bool EmailNotificationButtonEnabled { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="serverGeneralSettings"]/EulaEnabled/*'/>
        public bool EulaEnabled { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="serverGeneralSettings"]/UseS3Storage/*'/>
        public bool UseS3Storage { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="serverGeneralSettings"]/S3TagsEnabled/*'/>
        public bool S3TagsEnabled { get; internal set; }

        public bool HomeRoomsActive { get; internal set; }

        public long? HomeRoomParentId { get; internal set; }

        public DracoonSubscriptionPlan SubscriptionPlan { get; internal set; }
    }
}
