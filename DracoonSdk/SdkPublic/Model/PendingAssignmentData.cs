namespace Dracoon.Sdk.Model {
    public class PendingAssignmentData {

        public long RoomId { get; set; }

        public PendingAssignmentState State { get; set; }

        public UserInfo UserInfo { get; set; }

        public GroupInfo GroupInfo { get; set; }
    }
}
