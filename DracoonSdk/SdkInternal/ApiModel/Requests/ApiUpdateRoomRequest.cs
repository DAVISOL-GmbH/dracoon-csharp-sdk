using Newtonsoft.Json;
using System;

namespace Dracoon.Sdk.SdkInternal.ApiModel.Requests {
    internal class ApiUpdateRoomRequest : ApiUpdateNodeRequestBase {

        [JsonProperty("quota", NullValueHandling = NullValueHandling.Ignore)]
        public long? Quota { get; set; }
    }
}
