using System;

namespace Dracoon.Sdk.Model {
    /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="updateRoomRequest"]/UpdateRoomRequest/*'/>
    public class UpdateRoomRequest : UpdateNodeRequestBase {

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="updateRoomRequest"]/Quota/*'/>
        public long? Quota { get; set; }

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="updateRoomRequest"]/UpdateRoomRequestConstructor/*'/>
        public UpdateRoomRequest(long id, string name = null, long? quota = null, string notes = null, DateTime? creationTime = null, DateTime? modificationTime = null)
            : base(id, name, notes, creationTime, modificationTime) {
            Quota = quota;
        }
    }
}
