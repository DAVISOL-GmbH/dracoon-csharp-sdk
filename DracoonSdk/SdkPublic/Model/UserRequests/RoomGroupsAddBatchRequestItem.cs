namespace Dracoon.Sdk.Model {
    public class RoomGroupsAddBatchRequestItem {

        public long Id {
            get; internal set;
        }

        public NodePermissions Permissions {
            get; internal set;
        }

        public GroupMemberAcceptance NewGroupMemberAcceptance {
            get; internal set;
        }
    }
}
