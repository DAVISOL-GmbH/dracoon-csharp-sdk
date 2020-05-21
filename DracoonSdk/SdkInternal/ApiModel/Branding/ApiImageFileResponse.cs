using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiImageFileResponse {
        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public string Size {
            get; internal set;
        }
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url {
            get; internal set;
        }
    }
}
