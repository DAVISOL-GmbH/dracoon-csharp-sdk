using Newtonsoft.Json;
using System;

namespace Dracoon.Sdk.SdkInternal.ApiModel.Requests {
    internal class ApiCreateFolderRequest : ApiCreateNodeRequestBase {
        [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
        public long ParentId { get; set; }
    }
}
