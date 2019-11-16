namespace Dracoon.Sdk.Filter {
    public class GetRoomUsersFilter : DracoonFilter {

        public static NameFilter User => new NameFilter("user", FilterOperator.Contains);

        public static UserIdFilter UserId => new UserIdFilter();

        public static FlagFilter IsGranted => new FlagFilter("isGranted", true);

        public static FlagFilter PermissionsManage => new FlagFilter("permissionsManage");

        public static FlagFilter EffectivePerm => new FlagFilter("effectivePerm", true);
    }
}
