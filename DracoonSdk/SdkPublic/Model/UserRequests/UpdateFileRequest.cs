using System;

namespace Dracoon.Sdk.Model {
    /// <summary>
    ///     Request to update the meta data of a file. Implements <see cref="UpdateNodeRequestBase"/> and <see cref="TrackExternalModificationRequestBase"/>.
    /// </summary>
    public class UpdateFileRequest : UpdateNodeRequestBase {

        /// <summary>
        ///     The new classification of the file. See also <seealso cref="Dracoon.Sdk.Model.Classification"/>
        /// </summary>
        public Classification? Classification { get; set; }

        /// <summary>
        ///     The new expiration date of the file.
        /// </summary>
        public DateTime? Expiration { get; set; }

        /// <summary>
        ///     Constructs a new update file request.
        /// </summary>
        /// <param name="id"><see cref="UpdateNodeRequestBase.Id"/></param>
        /// <param name="name"><see cref="UpdateNodeRequestBase.Name"/></param>
        /// <param name="classification"><see cref="Classification"/></param>
        /// <param name="notes"><see cref="UpdateNodeRequestBase.Notes"/></param>
        /// <param name="expiration"><see cref="Expiration"/></param>
        /// <param name="creationTime"><see cref="TrackExternalModificationRequestBase.CreationTimestamp"/></param>
        /// <param name="modificationTime"><see cref="TrackExternalModificationRequestBase.ModificationTimestamp"/></param>
        public UpdateFileRequest(long id, string name = null, Classification? classification = null, string notes = null,
            DateTime? expiration = null, DateTime? creationTime = null, DateTime? modificationTime = null)
            : base(id, name, notes, creationTime, modificationTime) {
            Classification = classification;
            Expiration = expiration;
        }
    }
}
