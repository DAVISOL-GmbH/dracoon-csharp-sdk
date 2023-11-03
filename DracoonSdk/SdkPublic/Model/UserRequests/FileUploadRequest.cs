using System;

namespace Dracoon.Sdk.Model {
    /// <summary>
    ///     Request to upload a new file. Implements <see cref="CreateNodeRequestBase"/> and <see cref="TrackExternalModificationRequestBase"/>.
    /// </summary>
    public class FileUploadRequest : CreateNodeRequestBase {
        /// <summary>
        ///     The id under which the new file should be created.
        /// </summary>
        public long ParentId { get; private set; }

        /// <summary>
        ///     The conflict resolution strategy for the upload operation. See also <seealso cref="Dracoon.Sdk.Model.ResolutionStrategy"/>
        /// </summary>
        public ResolutionStrategy ResolutionStrategy { get; set; }

        /// <summary>
        ///     The expiration date of the new file.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        ///     Constructs a new file upload request.
        /// </summary>
        /// <param name="parentId"><see cref="ParentId"/></param>
        /// <param name="name"><see cref="CreateNodeRequestBase.Name"/></param>
        /// <param name="classification"><see cref="Classification"/></param>
        /// <param name="resolutionStrategy"><see cref="ResolutionStrategy"/></param>
        /// <param name="notes"><see cref="CreateNodeRequestBase.Notes"/></param>
        /// <param name="expirationDate"><see cref="ExpirationDate"/></param>
        /// <param name="creationTime"><see cref="TrackExternalModificationRequestBase.CreationTimestamp"/></param>
        /// <param name="modificationTime"><see cref="TrackExternalModificationRequestBase.ModificationTimestamp"/></param>
        public FileUploadRequest(long parentId, string name, Classification? classification = null,
            ResolutionStrategy resolutionStrategy = ResolutionStrategy.AutoRename, string notes = null, DateTime? expirationDate = null,
            DateTime? creationTime = null, DateTime? modificationTime = null)
            : base(name, notes, classification, creationTime, modificationTime) {
            ParentId = parentId;
            ResolutionStrategy = resolutionStrategy;
            ExpirationDate = expirationDate;
        }
    }
}
