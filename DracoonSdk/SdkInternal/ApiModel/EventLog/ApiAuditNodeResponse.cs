using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiAuditNodeResponse {
        [JsonProperty("nodeId", NullValueHandling = NullValueHandling.Ignore)]
        public long NodeId {
            get; internal set;
        }
        [JsonProperty("nodeName", NullValueHandling = NullValueHandling.Ignore)]
        public string NodeName {
            get; internal set;
        }
        [JsonProperty("nodeParentPath", NullValueHandling = NullValueHandling.Ignore)]
        public string NodeParentPath {
            get; internal set;
        }
        [JsonProperty("nodeCntChildren", NullValueHandling = NullValueHandling.Ignore)]
        public int NodeCountChildren {
            get; internal set;
        }
        [JsonProperty("auditUserPermissionList", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiAuditUserPermission> AuditUserPermissionList {
            get; internal set;
        }
        [JsonProperty("nodeParentId", NullValueHandling = NullValueHandling.Ignore)]
        public long NodeParentId {
            get; internal set;
        }
        [JsonProperty("nodeSize", NullValueHandling = NullValueHandling.Ignore)]
        public long NodeSize {
            get; internal set;
        }
        [JsonProperty("nodeRecycleBinRetentionPeriod", NullValueHandling = NullValueHandling.Ignore)]
        public int NodeRecycleBinRetentionPeriod {
            get; internal set;
        }
        [JsonProperty("nodeQuota", NullValueHandling = NullValueHandling.Ignore)]
        public long NodeQuota {
            get; internal set;
        }
        [JsonProperty("nodeIsEncrypted", NullValueHandling = NullValueHandling.Ignore)]
        public bool NodeIsEncrypted {
            get; internal set;
        }
        [JsonProperty("nodeHasActivitiesLog", NullValueHandling = NullValueHandling.Ignore)]
        public bool NodeHasActivitiesLog {
            get; internal set;
        }
        [JsonProperty("nodeCreatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime NodeCreatedAt {
            get; internal set;
        }
        [JsonProperty("nodeCreatedBy", NullValueHandling = NullValueHandling.Ignore)]
        public ApiUserInfo NodeCreatedBy {
            get; internal set;
        }
        [JsonProperty("nodeUpdatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? NodeUpdatedAt {
            get; internal set;
        }
        [JsonProperty("nodeUpdatedBy", NullValueHandling = NullValueHandling.Ignore)]
        public ApiUserInfo NodeUpdatedBy {
            get; internal set;
        }
    }
}
