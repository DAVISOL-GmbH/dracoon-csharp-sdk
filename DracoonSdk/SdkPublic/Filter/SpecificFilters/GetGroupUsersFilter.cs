namespace Dracoon.Sdk.Filter {
    public class GetGroupUsersFilter : DracoonFilter {

        public static UserFilter User => new UserFilter();

        public static IsMemberFilter IsMember => new IsMemberFilter();

        public void AddIsMemberFilter(DracoonFilterType<IsMemberFilter> isMemberFilter) {
            CheckFilter(isMemberFilter, nameof(isMemberFilter));
            FiltersList.Add(isMemberFilter);
        }
    }
}
