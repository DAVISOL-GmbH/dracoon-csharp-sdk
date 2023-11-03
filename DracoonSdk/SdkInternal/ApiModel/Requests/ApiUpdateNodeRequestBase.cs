using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel.Requests {
    internal abstract class ApiUpdateNodeRequestBase : ApiTrackExternalModification {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("notes", NullValueHandling = NullValueHandling.Ignore)]
        public string Notes { get; set; }

        [JsonProperty("timestampCreation", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? TimestampCreation { get; set; }

        [JsonProperty("timestampModification", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? TimestampModification { get; set; }
    }
}
