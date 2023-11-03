using System;

namespace Dracoon.Sdk.Model {
    /// <summary>
    ///     Request to update the meta data of a room. Implements <see cref="UpdateNodeRequestBase"/> and <see cref="TrackExternalModificationRequestBase"/>.
    /// </summary>
    public class UpdateRoomRequest : UpdateNodeRequestBase {

        /// <summary>
        ///     The new quota of the room.
        /// </summary>
        public long? Quota { get; set; }

        /// <summary>
        ///     Constructs a new update room request.
        /// </summary>
        /// <param name="id"><see cref="UpdateNodeRequestBase.Id"/></param>
        /// <param name="name"><see cref="UpdateNodeRequestBase.Name"/></param>
        /// <param name="quota"><see cref="Quota"/></param>
        /// <param name="notes"><see cref="UpdateNodeRequestBase.Notes"/></param>
        /// <param name="creationTime"><see cref="TrackExternalModificationRequestBase.CreationTimestamp"/></param>
        /// <param name="modificationTime"><see cref="TrackExternalModificationRequestBase.ModificationTimestamp"/></param>
        public UpdateRoomRequest(long id, string name = null, long? quota = null, string notes = null, DateTime? creationTime = null, DateTime? modificationTime = null)
            : base(id, name, notes, creationTime, modificationTime) {
            Quota = quota;
        }
    }
}
