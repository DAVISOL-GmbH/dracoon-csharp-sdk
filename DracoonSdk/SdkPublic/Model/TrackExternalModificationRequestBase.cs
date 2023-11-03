using System;

namespace Dracoon.Sdk.Model {
    public abstract class TrackExternalModificationRequestBase {



        public TrackExternalModificationRequestBase(DateTime? creationTime = null, DateTime? modificationTime = null) {
            CreationTimestamp = creationTime;
            ModificationTimestamp = modificationTime;
        }

        /// <summary>
        ///     The creation date of the physical file.
        /// </summary>
        public DateTime? CreationTimestamp { get; internal set; }

        /// <summary>
        ///     The modification date of hte physical file. Note: This date is NOT changed on meta data changes.
        /// </summary>
        public DateTime? ModificationTimestamp { get; internal set; }
    }
}
