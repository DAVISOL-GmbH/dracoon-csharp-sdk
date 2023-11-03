using System;

namespace Dracoon.Sdk.Model {
    /// <summary>
    ///     Request to upload a new file.
    /// </summary>
    public class FileUploadRequest : CreateNodeRequestBase {
        /// <summary>
        ///     The id under which the new file should be created.
        /// </summary>
        public long ParentId { get; private set; }

        /// <summary>
        ///     The classification of the new file. See also <seealso cref="Dracoon.Sdk.Model.Classification"/>
        /// </summary>
        public Classification? Classification { get; set; }

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
        /// <param name="name"><see cref="Name"/></param>
        /// <param name="classification"><see cref="Classification"/></param>
        /// <param name="resolutionStrategy"><see cref="ResolutionStrategy"/></param>
        /// <param name="notes"><see cref="Notes"/></param>
        /// <param name="expirationDate"><see cref="ExpirationDate"/></param>
        /// <param name="creationTime"><see cref="CreationTime"/></param>
        /// <param name="modificationTime"><see cref="ModificationTime"/></param>
        public FileUploadRequest(long parentId, string name, Classification? classification = null,
            ResolutionStrategy resolutionStrategy = ResolutionStrategy.AutoRename, string notes = null, DateTime? expirationDate = null,
            DateTime? creationTime = null, DateTime? modificationTime = null)
            : base(name, notes, creationTime, modificationTime) {
            ParentId = parentId;
            Classification = classification;
            ResolutionStrategy = resolutionStrategy;
            ExpirationDate = expirationDate;
        }
    }
}
