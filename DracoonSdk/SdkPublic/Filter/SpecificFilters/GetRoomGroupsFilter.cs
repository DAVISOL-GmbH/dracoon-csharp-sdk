namespace Dracoon.Sdk.Filter {
    public class GetRoomGroupsFilter : DracoonFilter {

        public static NameFilter Name => new NameFilter("name", FilterOperator.Contains);

        public static GroupIdFilter GroupId => new GroupIdFilter();

        public static FlagFilter IsGranted => new FlagFilter("isGranted");

        public static FlagFilter PermissionsManage => new FlagFilter("permissionsManage");

        public static FlagFilter EffectivePerm => new FlagFilter("effectivePerm");


        public void AddNameFilter(DracoonFilterType<NameFilter> nameFilter) {
            CheckFilter(nameFilter, nameof(nameFilter));
            FiltersList.Add(nameFilter);
        }

        public void AddGroupIdFilter(DracoonFilterType<GroupIdFilter> groupIdFilter) {
            CheckFilter(groupIdFilter, nameof(groupIdFilter));
            FiltersList.Add(groupIdFilter);
        }

        public void AddIsGrantedFilter(DracoonFilterType<FlagFilter> isGrantedFilter) {
            CheckFilter(isGrantedFilter, nameof(isGrantedFilter));
            FiltersList.Add(isGrantedFilter);
        }

        public void AddPermissionsManageFilter(DracoonFilterType<FlagFilter> permissionsManageFilter) {
            CheckFilter(permissionsManageFilter, nameof(permissionsManageFilter));
            FiltersList.Add(permissionsManageFilter);
        }

        public void AddEffectivePermFilter(DracoonFilterType<FlagFilter> effectivePermFilter) {
            CheckFilter(effectivePermFilter, nameof(effectivePermFilter));
            FiltersList.Add(effectivePermFilter);
        }
    }
}
