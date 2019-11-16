namespace Dracoon.Sdk.Filter {
    public class GetUserGroupsFilter : DracoonFilter {

        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="getNodesFilter"]/Name/*'/>
        public static NameFilter Name => new NameFilter();

        public static IsMemberFilter IsMember => new IsMemberFilter();

    }
}
