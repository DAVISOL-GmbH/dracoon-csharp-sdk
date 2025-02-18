﻿using Newtonsoft.Json;
using System;

namespace Dracoon.Sdk.SdkInternal.ApiModel.Requests {
    internal class ApiCreateFileUpload : ApiCreateNodeRequestBase {
        [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
        public long ParentId { get; set; }

        [JsonProperty("expiration", NullValueHandling = NullValueHandling.Ignore)]
        public ApiExpiration Expiration {
            get; set;
        }
        [JsonProperty("directS3Upload", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UseS3 {
            get; set;
        }
    }
}
