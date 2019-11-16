namespace Dracoon.Sdk.Model {
    public class RoomUsersAddBatchRequestItem {

        public long Id {
            get; internal set;
        }

        public NodePermissions Permissions {
            get; internal set;
        }
    }
}
