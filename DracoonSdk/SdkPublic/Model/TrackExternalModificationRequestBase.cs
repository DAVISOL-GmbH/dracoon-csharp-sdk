using System;

namespace Dracoon.Sdk.Model {
    public abstract class TrackExternalModificationRequestBase {



        public TrackExternalModificationRequestBase(DateTime? creationTime = null, DateTime? modificationTime = null) {
            CreationTimestamp = creationTime;
            ModificationTimestamp = modificationTime;
        }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="node"]/CreationTimestamp/*'/>
        public DateTime? CreationTimestamp { get; internal set; }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="node"]/ModificationTimestamp/*'/>
        public DateTime? ModificationTimestamp { get; internal set; }
    }
}
