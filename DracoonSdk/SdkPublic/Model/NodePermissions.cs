namespace Dracoon.Sdk.Model {
    /// <summary>
    ///     This model stores information about the permission a user has on a node.
    /// </summary>
    public class NodePermissions {

        /// <summary>
        ///     Is <c>true</c> if the user has the permission on the data room. Otherwise <c>false</c>.
        /// </summary>
        public bool Manage { get; internal set; }

        /// <summary>
        ///     Is <c>true</c> if the user has the permission on the data room. Otherwise <c>false</c>.
        /// </summary>
        public bool Read { get; internal set; }

        /// <summary>
        ///     Is <c>true</c> if the user has the permission on the data room. Otherwise <c>false</c>.
        /// </summary>
        public bool Create { get; internal set; }

        /// <summary>
        ///     Is <c>true</c> if the user has the permission on the data room. Otherwise <c>false</c>.
        /// </summary>
        public bool Change { get; internal set; }

        /// <summary>
        ///     Is <c>true</c> if the user has the permission on the data room. Otherwise <c>false</c>.
        /// </summary>
        public bool Delete { get; internal set; }

        /// <summary>
        ///     Is <c>true</c> if the user has the permission on the data room. Otherwise <c>false</c>.
        /// </summary>
        public bool ManageDownloadShare { get; internal set; }

        /// <summary>
        ///     Is <c>true</c> if the user has the permission on the data room. Otherwise <c>false</c>.
        /// </summary>
        public bool ManageUploadShare { get; internal set; }

        /// <summary>
        ///     Is <c>true</c> if the user has the permission on the data room. Otherwise <c>false</c>.
        /// </summary>
        public bool CanReadRecycleBin { get; internal set; }

        /// <summary>
        ///     Is <c>true</c> if the user has the permission on the data room. Otherwise <c>false</c>.
        /// </summary>
        public bool CanRestoreRecycleBin { get; internal set; }

        /// <summary>
        ///     Is <c>true</c> if the user has the permission on the data room. Otherwise <c>false</c>.
        /// </summary>
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