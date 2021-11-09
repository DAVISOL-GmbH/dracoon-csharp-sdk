using System;

namespace Dracoon.Sdk.Model {
    /// <include file="UserRequestsDoc.xml" path='docs/members[@name="updateFileRequest"]/UpdateFileRequest/*'/>
    public class UpdateFileRequest : UpdateNodeRequestBase {

        /// <include file="UserRequestsDoc.xml" path='docs/members[@name="updateFileRequest"]/Classification/*'/>
        public Classification? Classification { get; set; }

        /// <include file="UserRequestsDoc.xml" path='docs/members[@name="updateFileRequest"]/Expiration/*'/>
        public DateTime? Expiration { get; set; }

        /// <include file="UserRequestsDoc.xml" path='docs/members[@name="updateFileRequest"]/UpdateFileRequestConstructor/*'/>
        public UpdateFileRequest(long id, string name = null, Classification? classification = null, string notes = null,
            DateTime? expiration = null, DateTime? creationTime = null, DateTime? modificationTime = null)
            : base(id, name, notes, creationTime, modificationTime) {
            Classification = classification;
            Expiration = expiration;
        }
    }
}
