using System;

namespace Dracoon.Sdk.Model {
    /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="updateFolderRequest"]/UpdateFolderRequest/*'/>
    public class UpdateFolderRequest : UpdateNodeRequestBase {

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="updateFolderRequest"]/UpdateFolderRequestConstructor/*'/>
        public UpdateFolderRequest(long id, string name = null, string notes = null, DateTime? creationTime = null, DateTime? modificationTime = null)
            : base(id, name, notes, creationTime, modificationTime) {
        }
    }
}
