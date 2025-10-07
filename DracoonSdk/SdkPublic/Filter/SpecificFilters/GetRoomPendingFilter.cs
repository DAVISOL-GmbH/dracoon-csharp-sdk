namespace Dracoon.Sdk.Filter {
    public class GetRoomPendingFilter : DracoonFilter {

        public static UserIdFilter UserId = new UserIdFilter();

        public static GroupIdFilter GroupId = new GroupIdFilter();

        public static RoomIdFilter RoomId = new RoomIdFilter();

        public static AssignmentStateFilter State = new AssignmentStateFilter();
    }
}
