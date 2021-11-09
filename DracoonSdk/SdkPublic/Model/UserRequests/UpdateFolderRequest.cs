using System;

namespace Dracoon.Sdk.Model {
    /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="updateFolderRequest"]/UpdateFolderRequest/*'/>
    public class UpdateFolderRequest : UpdateNodeRequestBase {

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="updateFolderRequest"]/UpdateFolderRequestConstructor/*'/>
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
        public UpdateFolderRequest(long id, string name = null, string notes = null, DateTime? creationTime = null, DateTime? modificationTime = null)
            : base(id, name, notes, creationTime, modificationTime) {
        }
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
    }
}
