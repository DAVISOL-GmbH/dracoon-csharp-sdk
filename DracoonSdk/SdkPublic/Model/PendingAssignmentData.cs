namespace Dracoon.Sdk.Model {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class PendingAssignmentData {

        public long RoomId { get; set; }

        public PendingAssignmentState State { get; set; }

        public UserInfo UserInfo { get; set; }

        public GroupInfo GroupInfo { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
