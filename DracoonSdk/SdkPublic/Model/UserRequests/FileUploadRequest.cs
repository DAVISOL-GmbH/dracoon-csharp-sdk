using System;

namespace Dracoon.Sdk.Model {
    /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="fileUploadRequest"]/FileUploadRequest/*'/>
    public class FileUploadRequest : CreateNodeRequestBase {
        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="fileUploadRequest"]/ParentId/*'/>
        public long ParentId { get; private set; }

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="fileUploadRequest"]/Classification/*'/>
        public Classification? Classification { get; set; }

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="fileUploadRequest"]/ResolutionStrategy/*'/>
        public ResolutionStrategy ResolutionStrategy { get; set; }

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="fileUploadRequest"]/ExpirationDate/*'/>
        public DateTime? ExpirationDate { get; set; }

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="fileUploadRequest"]/CreationTime/*'/>
        public DateTime? CreationTime { get; set; }

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="fileUploadRequest"]/ModificationTime/*'/>
        public DateTime? ModificationTime { get; set; }

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="fileUploadRequest"]/FileUploadRequestConstructor/*'/>
        public FileUploadRequest(long parentId, string name, Classification? classification = null,
            ResolutionStrategy resolutionStrategy = ResolutionStrategy.AutoRename, string notes = null, DateTime? expirationDate = null,
            DateTime? creationTime = null, DateTime? modificationTime = null)
            : base(name, notes, creationTime, modificationTime) {
            ParentId = parentId;
            Classification = classification;
            ResolutionStrategy = resolutionStrategy;
            ExpirationDate = expirationDate;
            CreationTime = creationTime;
            ModificationTime = modificationTime;
        }
    }
}
