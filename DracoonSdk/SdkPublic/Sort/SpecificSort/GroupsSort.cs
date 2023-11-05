namespace Dracoon.Sdk.Sort {
    public class GroupsSort : DracoonSort {

        public static CountUsersSort<GroupsSort> CountUsers => new CountUsersSort<GroupsSort>(new GroupsSort());

        public static ExpireAtSort<GroupsSort> ExpireAt => new ExpireAtSort<GroupsSort>(new GroupsSort());

        public static CreatedAtSort<GroupsSort> CreatedAt => new CreatedAtSort<GroupsSort>(new GroupsSort());

        public static NameSort<GroupsSort> Name => new NameSort<GroupsSort>(new GroupsSort());
    }
}
