using Newtonsoft.Json;
using System;

namespace Dracoon.Sdk.SdkInternal.ApiModel.Requests {

    /// <summary>
    /// Represents the base class for all requests that will create a new node (room, file or folder). Inherits from the <see cref="ApiTrackExternalModification"/> base class with external creation and modification timestamps.
    /// </summary>
    /// <seealso cref="ApiTrackExternalModification"/>
    internal abstract class ApiCreateNodeRequestBase : ApiTrackExternalModification {

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("notes", NullValueHandling = NullValueHandling.Ignore)]
        public string Notes { get; set; }

        [JsonProperty("classification", NullValueHandling = NullValueHandling.Ignore)]
        public int? Classification { get; set; }
    }
}
