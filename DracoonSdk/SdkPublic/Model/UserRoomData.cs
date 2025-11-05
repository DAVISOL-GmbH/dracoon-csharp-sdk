using System;
using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    /// <summary>
    ///     Hierarchical room information.
    ///     <seealso cref="INodeBase">Implements the INodeBase interface.</seealso>
    /// </summary>
    public class UserRoomData : INodeBase {

        #region INodeBase implementation

        /// <summary>
        ///     The id of the node.
        ///     <para>Implements <see cref="INodeBase.Id"/></para>
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        ///     The type of the node. See also <seealso cref="NodeType"/>. Only valid value is <c>Room</c>.
        ///     <para>Implements <see cref="INodeBase.Type"/></para>
        /// </summary>
        public NodeType Type { get; internal set; }

        /// <summary>
        ///     The name of the node.
        ///     <para>Implements <see cref="INodeBase.Name"/></para>
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        ///     The parent id of the node.
        ///     <para>Implements <see cref="INodeBase.ParentId"/></para>
        /// </summary>
        public long? ParentId { get; internal set; }

        /// <summary>
        ///     Is set to <c>true</c> if the user have ever set this node as favorite.
        ///     <para>Implements <see cref="INodeBase.IsFavorite"/></para>
        /// </summary>
        public bool? IsFavorite { get; internal set; }

        /// <summary>
        ///     Indicates of this node is encrypted.
        ///     <para>Implements <see cref="INodeBase.IsEncrypted"/></para>
        /// </summary>
        public bool? IsEncrypted { get; internal set; }

        /// <summary>
        ///     The total byte size of the underlying files.
        ///     <para>Implements <see cref="INodeBase.Size"/></para>
        /// </summary>
        public long? Size { get; internal set; }

        /// <summary>
        ///     The quota in bytes. (Only if it is a <see cref="NodeType.Room"/>).
        ///     <para>Implements <see cref="INodeBase.Quota"/></para>
        /// </summary>
        public long? Quota { get; internal set; }

        /// <summary>
        ///     The creation date of the node.
        ///     <para>Implements <see cref="INodeBase.CreatedAt"/></para>
        /// </summary>
        public DateTime? CreatedAt { get; internal set; }

        /// <summary>
        ///     The user which created the node. See also <seealso cref="UserInfo"/>
        ///     <para>Implements <see cref="INodeBase.CreatedBy"/></para>
        /// </summary>
        public UserInfo CreatedBy { get; internal set; }

        /// <summary>
        ///     The update date of the node. Note: This date is also updated on meta data changes like node name or others.
        ///     <para>Implements <see cref="INodeBase.UpdatedAt"/></para>
        /// </summary>
        public DateTime? UpdatedAt { get; internal set; }

        /// <summary>
        ///     The user which updated the node. See also <seealso cref="UserInfo"/>
        ///     <para>Implements <see cref="INodeBase.UpdatedBy"/></para>
        /// </summary>
        public UserInfo UpdatedBy { get; internal set; }

        /// <summary>
        ///     The permissions for the node. See also <seealso cref="NodePermissions"/>
        ///     <para>Implements <see cref="INodeBase.Permissions"/></para>
        /// </summary>
        public NodePermissions Permissions { get; internal set; }

        /// <summary>
        ///     The number of download shares which referencing this node.
        ///     <para>Implements <see cref="INodeBase.CountDownloadShares"/></para>
        /// </summary>
        public int? CountDownloadShares { get; internal set; }

        /// <summary>
        ///     The number of upload shares which referencing this node.
        ///     <para>Implements <see cref="INodeBase.CountUploadShares"/></para>
        /// </summary>
        public int? CountUploadShares { get; internal set; }

        #endregion

        /// <summary>
        ///     Checks if user is granted any room permission.
        /// </summary>
        public bool IsGranted { get; internal set; }

        /// <summary>
        ///     List of rooms, where this room is a parent (if exist).
        /// </summary>
        public IEnumerable<UserRoomData> Children {
            get; internal set;
        }
    }
}
