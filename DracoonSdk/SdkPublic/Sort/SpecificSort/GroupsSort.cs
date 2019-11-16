namespace Dracoon.Sdk.Sort {
    public class GroupsSort : DracoonSort {

        public static CountUsersSort<GroupsSort> CountUsers => new CountUsersSort<GroupsSort>(new GroupsSort());

        /// <include file = "SpecificSort.xml" path='docs/members[@name="searchNodesSort"]/ExpireAt/*'/>
        public static ExpireAtSort<GroupsSort> ExpireAt => new ExpireAtSort<GroupsSort>(new GroupsSort());

        /// <include file = "SpecificSort.xml" path='docs/members[@name="searchNodesSort"]/CreatedAt/*'/>
        public static CreatedAtSort<GroupsSort> CreatedAt => new CreatedAtSort<GroupsSort>(new GroupsSort());

        /// <include file = "SpecificSort.xml" path='docs/members[@name="searchNodesSort"]/Name/*'/>
        public static NameSort<GroupsSort> Name => new NameSort<GroupsSort>(new GroupsSort());
    }
}
