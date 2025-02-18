namespace Dracoon.Sdk.Filter {
    public class GetUserGroupsFilter : DracoonFilter {

        public static NameFilter Name => new NameFilter();

        public static IsMemberFilter IsMember => new IsMemberFilter();


        public void AddNameFilter(DracoonFilterType<NameFilter> nameFilter) {
            CheckFilter(nameFilter, nameof(nameFilter));
            FiltersList.Add(nameFilter);
        }

        public void AddIsMemberFilter(DracoonFilterType<IsMemberFilter> isMemberFilter) {
            CheckFilter(isMemberFilter, nameof(isMemberFilter));
            FiltersList.Add(isMemberFilter);
        }

    }
}
