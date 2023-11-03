using System;

using System;

namespace Dracoon.Sdk.Model {
    /// <summary>
    ///     Request to update the meta data of a room.
    /// </summary>
    public class UpdateRoomRequest : UpdateNodeRequestBase {

        /// <summary>
        ///     The new quota of the room.
        /// </summary>
        public long? Quota { get; set; }

        /// <summary>
        ///     Constructs a new update room request.
        /// </summary>
        /// <param name="id"><see cref="Id"/></param>
        /// <param name="name"><see cref="Name"/></param>
        /// <param name="quota"><see cref="Quota"/></param>
        /// <param name="notes"><see cref="Notes"/></param>
        /// <param name="creationTime"><see cref="CreationTime"/></param>
        /// <param name="modificationTime"><see cref="ModificationTime"/></param>
        public UpdateRoomRequest(long id, string name = null, long? quota = null, string notes = null, DateTime? creationTime = null, DateTime? modificationTime = null) : base(id, 17) {
            Id = id;
            Name = name;
            Quota = quota;
            Notes = notes;
        }
    }
}
