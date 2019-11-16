using System;
using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public class AuditNodeResponse {

        public long NodeId {
            get; internal set;
        }

        public string NodeName {
            get; internal set;
        }

        public string NodeParentPath {
            get; internal set;
        }

        public int NodeCountChildren {
            get; internal set;
        }

        public IEnumerable<AuditUserPermission> AuditUserPermissionList {
            get; internal set;
        }

        public long NodeParentId {
            get; internal set;
        }

        public long NodeSize {
            get; internal set;
        }

        public int NodeRecycleBinRetentionPeriod {
            get; internal set;
        }

        public long NodeQuota {
            get; internal set;
        }

        public bool NodeIsEncrypted {
            get; internal set;
        }

        public bool NodeHasActivitiesLog {
            get; internal set;
        }

        public DateTime NodeCreatedAt {
            get; internal set;
        }

        public UserInfo NodeCreatedBy {
            get; internal set;
        }

        public DateTime? NodeUpdatedAt {
            get; internal set;
        }

        public UserInfo NodeUpdatedBy {
            get; internal set;
        }
    }
}
