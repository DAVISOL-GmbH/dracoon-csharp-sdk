using System;

namespace Dracoon.Sdk.Model {
    public abstract class CreateNodeRequestBase : TrackExternalModificationRequestBase {

        public CreateNodeRequestBase(string name, string notes = null, DateTime? creationTime = null, DateTime? modificationTime = null)
            : base(creationTime, modificationTime) {
            Name = name;
            Notes = notes;
        }

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="createFolderRequest"]/Name/*'/>
        public string Name { get; private set; }

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="createFolderRequest"]/Notes/*'/>
        public string Notes { get; set; }
    }
}
