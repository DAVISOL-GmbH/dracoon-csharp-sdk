using System;

namespace Dracoon.Sdk.Model {
    /// <summary>
    ///     Request to create a new folder. Implements <see cref="CreateNodeRequestBase"/> and <see cref="TrackExternalModificationRequestBase"/>.
    /// </summary>
    public class CreateFolderRequest : CreateNodeRequestBase{

        /// <summary>
        ///     The parent node id under which the new folder should be created.
        /// </summary>
        public long ParentId { get; private set; }

        /// <summary>
        ///     Constructs a new create folder request.
        /// </summary>
        /// <param name="parentId"><see cref="ParentId"/></param>
        /// <param name="name"><see cref="CreateNodeRequestBase.Name"/></param>
        /// <param name="notes"><see cref="CreateNodeRequestBase.Notes"/></param>
        /// <param name="classification"><see cref="Classification"/></param>
        /// <param name="creationTime"><see cref="TrackExternalModificationRequestBase.CreationTimestamp"/></param>
        /// <param name="modificationTime"><see cref="TrackExternalModificationRequestBase.ModificationTimestamp"/></param>
        public CreateFolderRequest(long parentId, string name, string notes = null, Classification? classification = null, DateTime? creationTime = null, DateTime? modificationTime = null) 
            : base(name, notes, classification, creationTime, modificationTime) {
            ParentId = parentId;
        }
    }
}
