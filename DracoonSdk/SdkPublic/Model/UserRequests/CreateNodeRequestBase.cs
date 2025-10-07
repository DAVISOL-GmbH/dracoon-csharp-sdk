using System;

namespace Dracoon.Sdk.Model {
    /// <summary>
    /// Represents the base class for create node requests.
    /// </summary>
    public abstract class CreateNodeRequestBase : TrackExternalModificationRequestBase {

        /// <summary>
        /// Initializes the base properties of the create node request (for rooms, files or folders).
        /// </summary>
        /// <param name="name"><see cref="Name"/></param>
        /// <param name="notes"><see cref="Notes"/></param>
        /// <param name="classification"><see cref="Classification"/></param>
        /// <param name="creationTime"><see cref="TrackExternalModificationRequestBase.CreationTimestamp"/></param>
        /// <param name="modificationTime"><see cref="TrackExternalModificationRequestBase.ModificationTimestamp"/></param>
        public CreateNodeRequestBase(string name, string notes = null, Classification? classification = null, DateTime? creationTime = null, DateTime? modificationTime = null)
            : base(creationTime, modificationTime) {
            Name = name;
            Notes = notes;
            Classification = classification;
        }

        /// <summary>
        ///     The name of the new node.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///     The notes for the new node.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        ///     The classification for this node.
        ///     <para>
        ///         Nullable. If not set the parent room classification (or default if not available which is internal) is used.
        ///     </para>
        /// </summary>
        public Classification? Classification { get; set; }
    }
}
