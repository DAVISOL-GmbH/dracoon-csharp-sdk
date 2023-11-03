using Newtonsoft.Json;
using System;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    /// <summary>
    /// Represents the most-common base class for objects transporting an external creation and modification timestamp.
    /// </summary>
    internal abstract class ApiTrackExternalModification {

        [JsonProperty("timestampCreation", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreationTimestamp { get; set; }

        [JsonProperty("timestampModification", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ModificationTimestamp { get; set; }
    }
}
