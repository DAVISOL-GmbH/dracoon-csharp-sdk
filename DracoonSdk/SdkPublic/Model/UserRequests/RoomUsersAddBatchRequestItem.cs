namespace Dracoon.Sdk.Model {
    public class RoomUsersAddBatchRequestItem {

        public long Id {
            get; private set;
        }

        public NodePermissions Permissions {
            get; private set;
        }

        public RoomUsersAddBatchRequestItem(long userId, NodePermissions permissions) {
            Id = userId;
            Permissions = permissions;
        }
    }
}
