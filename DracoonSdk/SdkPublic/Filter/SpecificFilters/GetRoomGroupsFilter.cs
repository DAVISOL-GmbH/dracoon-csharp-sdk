namespace Dracoon.Sdk.Filter {
    public class GetRoomGroupsFilter : DracoonFilter {

        public static NameFilter Name => new NameFilter("name", FilterOperator.Contains);

        public static GroupIdFilter GroupId => new GroupIdFilter();

        public static FlagFilter IsGranted => new FlagFilter("isGranted");

        public static FlagFilter PermissionsManage => new FlagFilter("permissionsManage");

        public static FlagFilter EffectivePerm => new FlagFilter("effectivePerm");
    }
}
