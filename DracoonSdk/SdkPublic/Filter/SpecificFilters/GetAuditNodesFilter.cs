namespace Dracoon.Sdk.Filter {
    public class GetAuditNodesFilter : DracoonFilter {

        public static NodeIdFilter NodeId => new NodeIdFilter("nodeId");

        public static NameFilter NodeName => new NameFilter("nodeName");

        public static NodeIdFilter NodeParentId => new NodeIdFilter("nodeParentId");

        public static UserIdFilter UserId => new UserIdFilter("userId");

        public static NameFilter UserName => new NameFilter("userName");

        public static NameFilter UserFirstName => new NameFilter("userFirstName");

        public static NameFilter UserLastName => new NameFilter("userLastName");

        public static FlagFilter PermissionsManage => new FlagFilter("permissionsManage");

        public static FlagFilter NodeIsEncrypted => new FlagFilter("nodeIsEncrypted");

        public static FlagFilter NodeHasActivitiesLog => new FlagFilter("nodeHasActivitiesLog");


        /// <include file="SpecificFilterDoc.xml" path='docs/members[@name="getDownloadSharesFilter"]/AddUserIdFilter/*'/>
        public void AddUserIdFilter(DracoonFilterType<UserIdFilter> userIdFilter) {
            CheckFilter(userIdFilter, nameof(userIdFilter));
            filtersList.Add(userIdFilter);
        }

    }
}
