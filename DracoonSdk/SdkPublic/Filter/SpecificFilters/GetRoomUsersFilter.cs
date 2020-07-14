namespace Dracoon.Sdk.Filter {
    public class GetRoomUsersFilter : DracoonFilter {

        public static NameFilter User => new NameFilter("user", FilterOperator.Contains);

        public static UserIdFilter UserId => new UserIdFilter();

        public static FlagFilter IsGranted => new FlagFilter("isGranted", true);

        public static FlagFilter PermissionsManage => new FlagFilter("permissionsManage");

        public static FlagFilter EffectivePerm => new FlagFilter("effectivePerm", true);


        public void AddUserFilter(DracoonFilterType<NameFilter> userFilter) {
            CheckFilter(userFilter, nameof(userFilter));
            FiltersList.Add(userFilter);
        }

        public void AddUserIdFilter(DracoonFilterType<UserIdFilter> userIdFilter) {
            CheckFilter(userIdFilter, nameof(userIdFilter));
            FiltersList.Add(userIdFilter);
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
