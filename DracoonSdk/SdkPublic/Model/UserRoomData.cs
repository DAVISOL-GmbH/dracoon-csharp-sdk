using System;
using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    /// <summary>
    ///     Hierarchical room information.
    /// </summary>
    public class UserRoomData  {

        /// <summary>
        ///     The id of the node.
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        ///     The type of the node. See also <seealso cref="NodeType"/>. Only valid value is <c>Room</c>.
        /// </summary>
        public NodeType Type { get; internal set; }

        /// <summary>
        ///     Checks if user is granted any room permission.
        /// </summary>
        public bool IsGranted { get; internal set; }

        /// <summary>
        ///     The name of the node.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        ///     Indicates of this node is encrypted.
        /// </summary>
        public bool? IsEncrypted { get; internal set; }

        /// <summary>
        ///     The parent id of the node.
        /// </summary>
        public long? ParentId { get; internal set; }

        /// <summary>
        ///     The total byte size of the underlying files.
        /// </summary>
        public long? Size { get; internal set; }

        /// <summary>
        ///     The permissions for the node. See also <seealso cref="NodePermissions"/>
        /// </summary>
        public NodePermissions Permissions { get; internal set; }

        /// <summary>
        ///     The creation date of the node.
        /// </summary>
        public DateTime? CreatedAt { get; internal set; }

        /// <summary>
        ///     The user which created the node. See also <seealso cref="UserInfo"/>
        /// </summary>
        public UserInfo CreatedBy { get; internal set; }

        /// <summary>
        ///     The update date of the node. Note: This date is also updated on meta data changes like node name or others.
        /// </summary>
        public DateTime? UpdatedAt { get; internal set; }

        /// <summary>
        ///     The user which updated the node. See also <seealso cref="UserInfo"/>
        /// </summary>
        public UserInfo UpdatedBy { get; internal set; }

        /// <summary>
        ///     The quota in bytes. (Only if it is a <see cref="NodeType.Room"/>).
        /// </summary>
        public long? Quota { get; internal set; }

        /// <summary>
        ///     The number of download shares which referencing this node.
        /// </summary>
        public int? CountDownloadShares { get; internal set; }

        /// <summary>
        ///     The number of upload shares which referencing this node.
        /// </summary>
        public int? CountUploadShares { get; internal set; }

        /// <summary>
        ///     Is set to <c>true</c> if you have ever set this node as favorite.
        /// </summary>
        public bool? IsFavorite { get; internal set; }

        /// <summary>
        ///     List of rooms, where this room is a parent (if exist).
        /// </summary>
        public IEnumerable<UserRoomData> Children {
            get; internal set;
        }
    }
}
