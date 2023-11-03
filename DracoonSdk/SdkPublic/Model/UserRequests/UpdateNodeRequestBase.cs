using System;

namespace Dracoon.Sdk.Model {
    public abstract class UpdateNodeRequestBase : TrackExternalModificationRequestBase {

        public UpdateNodeRequestBase(long id, string name = null, string notes = null, DateTime? creationTime = null, DateTime? modificationTime = null)
            : base(creationTime, modificationTime) {
            Id = id;
            Name = name;
            Notes = notes;
        }

        /// <summary>
        ///     The node id of the folder which should be updated.
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        ///     The new name of the folder.
        ///     <para>
        ///         Nullable
        ///     </para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The new notes of the folder.
        ///     <para>
        ///         Nullable
        ///     </para>
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        ///     The external creation time of this node.
        ///     <para>
        ///         Nullable. If not set, the default is the current server time in UTC.
        ///     </para>
        /// </summary>
        public DateTime? CreationTime { get; set; }

        /// <summary>
        ///     The content modification time of this node.
        ///     <para>
        ///         Nullable. If not set, the default is the current server time in UTC.
        ///     </para>
        /// </summary>
        public DateTime? ModificationTime { get; set; }

    }
}
