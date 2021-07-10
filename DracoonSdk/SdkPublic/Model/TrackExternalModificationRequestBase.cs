using System;

namespace Dracoon.Sdk.Model {
    public abstract class TrackExternalModificationRequestBase {

        

        public TrackExternalModificationRequestBase(DateTime? timestampCreation = null, DateTime? timestampModification = null) {
            TimestampCreation = timestampCreation;
            TimestampModification = timestampModification;
        }

        public DateTime? TimestampCreation { get; internal set; }

        public DateTime? TimestampModification { get; internal set; }
    }
}
