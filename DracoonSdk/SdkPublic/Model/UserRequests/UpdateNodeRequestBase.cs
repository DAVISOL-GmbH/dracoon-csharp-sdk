using System;

namespace Dracoon.Sdk.Model {
    public abstract class UpdateNodeRequestBase : TrackExternalModificationRequestBase {

        public UpdateNodeRequestBase(long id, string name = null, string notes = null, DateTime? creationTime = null, DateTime? modificationTime = null)
            : base(creationTime, modificationTime) {
            Id = id;
            Name = name;
            Notes = notes;
        }

        /// <include file="UserRequestsDoc.xml" path='docs/members[@name="updateFileRequest"]/Id/*'/>
        public long Id { get; private set; }

        /// <include file="UserRequestsDoc.xml" path='docs/members[@name="updateFileRequest"]/Name/*'/>
        public string Name { get; set; }

        /// <include file="UserRequestsDoc.xml" path='docs/members[@name="updateFileRequest"]/Notes/*'/>
        public string Notes { get; set; }


    }
}
