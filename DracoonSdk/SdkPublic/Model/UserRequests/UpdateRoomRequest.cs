using System;

namespace Dracoon.Sdk.Model {
    /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="updateRoomRequest"]/UpdateRoomRequest/*'/>
    public class UpdateRoomRequest : UpdateNodeRequestBase {

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="updateRoomRequest"]/Quota/*'/>
        public long? Quota { get; set; }

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="updateRoomRequest"]/UpdateRoomRequestConstructor/*'/>
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
        public UpdateRoomRequest(long id, string name = null, long? quota = null, string notes = null, DateTime? creationTime = null, DateTime? modificationTime = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            : base(id, name, notes, creationTime, modificationTime) {
            Quota = quota;
        }
    }
}
