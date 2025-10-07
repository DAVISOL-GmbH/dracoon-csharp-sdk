using System;

namespace Dracoon.Sdk.Model {

    /// <summary>
    /// Represents the most-common base class for objects transporting an external creation and modification timestamp.
    /// </summary>
    public abstract class TrackExternalModificationRequestBase {

        /// <summary>
        /// Initializes the external creation and modification timestamps of a node (room, file or folder)
        /// </summary>
        /// <param name="creationTime">The real (external) creation time of the node.</param>
        /// <param name="modificationTime">The real (external) last modification time of the node.</param>
        public TrackExternalModificationRequestBase(DateTime? creationTime = null, DateTime? modificationTime = null) {
            CreationTimestamp = creationTime;
            ModificationTimestamp = modificationTime;
        }

        /// <summary>
        ///     The real (external) creation time of the node.
        /// </summary>
        public DateTime? CreationTimestamp { get; internal set; }

        /// <summary>
        ///     The real (external) last modification time of the node. Note: This date is NOT changed on meta data changes.
        /// </summary>
        public DateTime? ModificationTimestamp { get; internal set; }
    }
}
