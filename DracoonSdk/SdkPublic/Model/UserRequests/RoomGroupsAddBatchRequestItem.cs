namespace Dracoon.Sdk.Model {
    public class RoomGroupsAddBatchRequestItem {

        public long Id {
            get; private set;
        }

        public NodePermissions Permissions {
            get; private set;
        }

        public GroupMemberAcceptance NewGroupMemberAcceptance {
            get; private set;
        }

        public RoomGroupsAddBatchRequestItem(long groupId, NodePermissions permissions, GroupMemberAcceptance newGroupMemberAcceptance) {
            Id = groupId;
            Permissions = permissions;
            NewGroupMemberAcceptance = newGroupMemberAcceptance;
        }
    }
}
