using System;
using System.Collections;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiGroup : ApiGroupInfo {

        [JsonProperty("cntUsers", NullValueHandling = NullValueHandling.Ignore)]
        public int CountUsers {
            get; set;
        }
        [JsonProperty("expireAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ExpireAt {
            get; set;
        }
        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedAt {
            get; set;
        }
        [JsonProperty("createdBy", NullValueHandling = NullValueHandling.Ignore)]
        public ApiUserInfo CreatedBy {
            get; set;
        }
        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdatedAt {
            get; set;
        }
        [JsonProperty("updatedBy", NullValueHandling = NullValueHandling.Ignore)]
        public ApiUserInfo UpdatedBy {
            get; set;
        }
        [JsonProperty("groupRoles", NullValueHandling = NullValueHandling.Ignore)]
        public ApiGroupRoleList GroupRoles {
            get; set;
        }
    }
}
