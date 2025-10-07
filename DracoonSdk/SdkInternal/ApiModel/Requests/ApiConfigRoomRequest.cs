using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel.Requests {
    internal class ApiConfigRoomRequest {
        [JsonProperty("recycleBinRetentionPeriod", NullValueHandling = NullValueHandling.Ignore)]
        public int? RecycleBinRetentionPeriod {
            get; set;
        }
        [JsonProperty("inheritPermissions", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InheritPermissions {
            get; set;
        }
        [JsonProperty("takeOverPermissions", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TakeOverPermissions {
            get; set;
        }
        [JsonProperty("adminIds", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<long> AdminIds {
            get; set;
        }
        [JsonProperty("adminGroupIds", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<long> AdminGroupIds {
            get; set;
        }
        [JsonProperty("newGroupMemberAcceptance", NullValueHandling = NullValueHandling.Ignore)]
        public string NewGroupMemberAcceptance {
            get; set;
        }
        [JsonProperty("hasActivitiesLog", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasActivitiesLog {
            get; set;
        }
        [JsonProperty("classification", NullValueHandling = NullValueHandling.Ignore)]
        public int? Classification {
            get; set;
        }
    }
}
