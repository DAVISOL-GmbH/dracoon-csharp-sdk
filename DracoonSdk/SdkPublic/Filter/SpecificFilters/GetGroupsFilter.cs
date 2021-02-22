namespace Dracoon.Sdk.Filter {
    public class GetGroupsFilter : DracoonFilter {

        public static NameFilter Name => new NameFilter();

        public void AddGroupNameFilter(DracoonFilterType<NameFilter> groupNameFilter) {
            CheckFilter(groupNameFilter, nameof(groupNameFilter));
            FiltersList.Add(groupNameFilter);
        }
    }
}
