using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public class ConfigRoomRequest {

        public int? RecycleBinRetentionPeriod {
            get; set;
        }

        public bool? InheritPermissions {
            get; set;
        }

        public bool? TakeOverPermissions {
            get; set;
        }

        public IEnumerable<long> AdminIds {
            get; set;
        }

        public IEnumerable<long> AdminGroupIds {
            get; set;
        }

        public GroupMemberAcceptance? NewGroupMemberAcceptance {
            get; set;
        }

        public bool? HasActivitiesLog {
            get; set;
        }

        public Classification? Classification {
            get; set;
        }
    }
}
