using System;

namespace Dracoon.Sdk.Model {
    /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="createFolderRequest"]/CreateFolderRequest/*'/>
    public class CreateFolderRequest : CreateNodeRequestBase {
        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="createFolderRequest"]/ParentId/*'/>
        public long ParentId { get; private set; }

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="createFolderRequest"]/CreateFolderRequest/*'/>
        public CreateFolderRequest(long parentId, string name, string notes = null, DateTime? timestampCreation = null, DateTime? timestampModification = null)
            : base(name, notes, timestampCreation, timestampModification) {
            ParentId = parentId;
        }
    }
}
