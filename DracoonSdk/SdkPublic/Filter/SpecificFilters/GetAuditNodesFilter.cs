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

        public void AddNodeIdFilter(DracoonFilterType<NodeIdFilter> nodeIdFilter) {
            CheckFilter(nodeIdFilter, nameof(nodeIdFilter));
            FiltersList.Add(nodeIdFilter);
        }

        public void AddNodeNameFilter(DracoonFilterType<NameFilter> nodeNameFilter) {
            CheckFilter(nodeNameFilter, nameof(nodeNameFilter));
            FiltersList.Add(nodeNameFilter);
        }

        public void AddNodeParentIdFilter(DracoonFilterType<NodeIdFilter> nodeParentIdFilter) {
            CheckFilter(nodeParentIdFilter, nameof(nodeParentIdFilter));
            FiltersList.Add(nodeParentIdFilter);
        }

        public void AddUserIdFilter(DracoonFilterType<UserIdFilter> userIdFilter) {
            CheckFilter(userIdFilter, nameof(userIdFilter));
            FiltersList.Add(userIdFilter);
        }

        public void AddUserNameFilter(DracoonFilterType<NameFilter> userNameFilter) {
            CheckFilter(userNameFilter, nameof(userNameFilter));
            FiltersList.Add(userNameFilter);
        }

        public void AddUserFirstNameFilter(DracoonFilterType<NameFilter> userFirstNameFilter) {
            CheckFilter(userFirstNameFilter, nameof(userFirstNameFilter));
            FiltersList.Add(userFirstNameFilter);
        }

        public void AddUserLastNameFilter(DracoonFilterType<NameFilter> userLastNameFilter) {
            CheckFilter(userLastNameFilter, nameof(userLastNameFilter));
            FiltersList.Add(userLastNameFilter);
        }

        public void AddPermissionsManageFilter(DracoonFilterType<FlagFilter> permissionsManageFilter) {
            CheckFilter(permissionsManageFilter, nameof(permissionsManageFilter));
            FiltersList.Add(permissionsManageFilter);
        }

        public void AddNodeIsEncryptedFilter(DracoonFilterType<FlagFilter> nodeIsEncryptedFilter) {
            CheckFilter(nodeIsEncryptedFilter, nameof(nodeIsEncryptedFilter));
            FiltersList.Add(nodeIsEncryptedFilter);
        }

        public void AddNodeHasActivitiesLogFilter(DracoonFilterType<FlagFilter> nodeHasActivitiesLogFilter) {
            CheckFilter(nodeHasActivitiesLogFilter, nameof(nodeHasActivitiesLogFilter));
            FiltersList.Add(nodeHasActivitiesLogFilter);
        }
    }
}
