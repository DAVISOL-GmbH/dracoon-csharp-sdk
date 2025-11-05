using System;

namespace Dracoon.Sdk.Model {
    /// <summary>
    /// Declares common properties of classes which represents information about a node.
    /// </summary>
    public interface INodeBase {

        /// <summary>
        ///     The id of the node.
        /// </summary>
        long Id { get; }
        
        /// <summary>
        ///     The type of the node. See also <seealso cref="NodeType"/>
        /// </summary>
        NodeType Type { get; }

        /// <summary>
        ///     The name of the node.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     The parent id of the node.
        /// </summary>
        long? ParentId { get; }

        /// <summary>
        ///     Is set to <c>true</c> if the user have ever set this node as favorite.
        /// </summary>
        bool? IsFavorite { get; }

        /// <summary>
        ///     Indicates of this node is encrypted.
        /// </summary>
        bool? IsEncrypted { get; }

        /// <summary>
        ///     The byte size of the node. If the node is a <see cref="NodeType.Room"/> or <see cref="NodeType.Folder"/> the total byte size of the underlying files.
        /// </summary>
        long? Size { get; }

        /// <summary>
        ///     The quota in bytes. (Only if it is a <see cref="NodeType.Room"/>).
        /// </summary>
        long? Quota { get; }

        /// <summary>
        ///     The creation date of the node.
        /// </summary>
        DateTime? CreatedAt { get; }

        /// <summary>
        ///     The user which created the node. See also <seealso cref="UserInfo"/>
        /// </summary>
        UserInfo CreatedBy { get; }

        /// <summary>
        ///     The update date of the node. Note: This date is also updated on meta data changes like node name or others.
        /// </summary>
        DateTime? UpdatedAt { get; }

        /// <summary>
        ///     The user which updated the node. See also <seealso cref="UserInfo"/>
        /// </summary>
        UserInfo UpdatedBy { get; }

        /// <summary>
        ///     The permissions for the node. See also <seealso cref="NodePermissions"/>
        /// </summary>
        NodePermissions Permissions { get; }

        /// <summary>
        ///     The number of download shares which referencing this node.
        /// </summary>
        int? CountDownloadShares { get; }

        /// <summary>
        ///     The number of upload shares which referencing this node.
        /// </summary>
        int? CountUploadShares { get; }
    }
}
