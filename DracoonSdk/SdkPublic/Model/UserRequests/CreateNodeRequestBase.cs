using System;

namespace Dracoon.Sdk.Model {
    public abstract class CreateNodeRequestBase : TrackExternalModificationRequestBase {

        public CreateNodeRequestBase(string name, string notes = null, DateTime? creationTime = null, DateTime? modificationTime = null)
            : base(creationTime, modificationTime) {
            Name = name;
            Notes = notes;
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
        ///     The real creation time of the file.
        /// </summary>
        public DateTime? CreationTime { get; set; }

        /// <summary>
        ///     The last modification time of the file.
        /// </summary>
        public DateTime? ModificationTime { get; set; }
    }
}
