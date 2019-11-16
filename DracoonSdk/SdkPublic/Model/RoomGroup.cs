namespace Dracoon.Sdk.Model {
    public class RoomGroup {

        public GroupInfo GroupInfo {
            get; internal set;
        }

        public bool IsGranted {
            get; internal set;
        }

        public GroupMemberAcceptance NewGroupMemberAcceptance { get; set; }

        public NodePermissions Permissions {
            get; internal set;
        }
    }
}
