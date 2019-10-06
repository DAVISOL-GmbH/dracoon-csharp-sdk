namespace Dracoon.Sdk.Sort {
    public class GroupsSort : DracoonSort {

        public static CountUsersSort<SearchNodesSort> CountUsers => new CountUsersSort<SearchNodesSort>(new SearchNodesSort());

        /// <include file = "SpecificSort.xml" path='docs/members[@name="searchNodesSort"]/ExpireAt/*'/>
        public static ExpireAtSort<SearchNodesSort> ExpireAt => new ExpireAtSort<SearchNodesSort>(new SearchNodesSort());

        /// <include file = "SpecificSort.xml" path='docs/members[@name="searchNodesSort"]/CreatedAt/*'/>
        public static CreatedAtSort<SearchNodesSort> CreatedAt => new CreatedAtSort<SearchNodesSort>(new SearchNodesSort());

        /// <include file = "SpecificSort.xml" path='docs/members[@name="searchNodesSort"]/Name/*'/>
        public static NameSort<SearchNodesSort> Name => new NameSort<SearchNodesSort>(new SearchNodesSort());
    }
}
