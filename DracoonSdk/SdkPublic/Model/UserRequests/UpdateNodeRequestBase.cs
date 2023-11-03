using System;

namespace Dracoon.Sdk.Model {
    /// <summary>
    /// Represents the base class for update node requests.
    /// </summary>
    public abstract class UpdateNodeRequestBase : TrackExternalModificationRequestBase {

        /// <summary>
        /// Initializes the base properties of the update node request (for rooms, files or folders).
        /// </summary>
        /// <param name="id"><see cref="Id"/></param>
        /// <param name="name"><see cref="Name"/></param>
        /// <param name="notes"><see cref="Notes"/></param>
        /// <param name="creationTime"><see cref="TrackExternalModificationRequestBase.CreationTimestamp"/></param>
        /// <param name="modificationTime"><see cref="TrackExternalModificationRequestBase.ModificationTimestamp"/></param>
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
    }
}
