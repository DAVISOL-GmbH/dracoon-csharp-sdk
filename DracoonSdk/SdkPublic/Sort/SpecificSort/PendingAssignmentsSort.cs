namespace Dracoon.Sdk.Sort {
    public class PendingAssignmentsSort : DracoonSort {

        public static UserIdSort<PendingAssignmentsSort> UserId => new UserIdSort<PendingAssignmentsSort>(new PendingAssignmentsSort());

        public static GroupIdSort<PendingAssignmentsSort> GroupId => new GroupIdSort<PendingAssignmentsSort>(new PendingAssignmentsSort());

        public static RoomIdSort<PendingAssignmentsSort> RoomId => new RoomIdSort<PendingAssignmentsSort>(new PendingAssignmentsSort());

        public static AssignmentStateSort<PendingAssignmentsSort> AssignmentState => new AssignmentStateSort<PendingAssignmentsSort>(new PendingAssignmentsSort());
    }
}
