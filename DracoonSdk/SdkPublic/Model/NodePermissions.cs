namespace Dracoon.Sdk.Model {
    /// <include file = "ModelDoc.xml" path='docs/members[@name="nodePermissions"]/NodePermissions/*'/>
    public class NodePermissions {
        /// <include file = "ModelDoc.xml" path='docs/members[@name="nodePermissions"]/Manage/*'/>
        public bool Manage { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="nodePermissions"]/Read/*'/>
        public bool Read { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="nodePermissions"]/Create/*'/>
        public bool Create { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="nodePermissions"]/Change/*'/>
        public bool Change { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="nodePermissions"]/Delete/*'/>
        public bool Delete { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="nodePermissions"]/ManageDownloadShare/*'/>
        public bool ManageDownloadShare { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="nodePermissions"]/ManageUploadShare/*'/>
        public bool ManageUploadShare { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="nodePermissions"]/CanReadRecycleBin/*'/>
        public bool CanReadRecycleBin { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="nodePermissions"]/CanRestoreRecycleBin/*'/>
        public bool CanRestoreRecycleBin { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="nodePermissions"]/CanDeleteRecycleBin/*'/>
        public bool CanDeleteRecycleBin { get; internal set; }

        internal NodePermissions() {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public NodePermissions(bool manage, bool read, bool create, bool change, bool delete,
            bool manageDownloadShare, bool manageUploadShare,
            bool readRecycleBin, bool restoreRecycleBin, bool deleteRecycleBin) {
            Manage = manage;
            Read = read;
            Create = create;
            Change = change;
            Delete = delete;
            ManageDownloadShare = manageDownloadShare;
            ManageUploadShare = manageUploadShare;
            CanReadRecycleBin = readRecycleBin;
            CanRestoreRecycleBin = restoreRecycleBin;
            CanDeleteRecycleBin = deleteRecycleBin;
        }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}