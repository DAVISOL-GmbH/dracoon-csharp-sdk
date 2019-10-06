namespace Dracoon.Sdk.Filter {
    public class GetUsersFilter : DracoonFilter {

        public static UserFilter User => new UserFilter();

        public static IsMemberFilter IsMember => new IsMemberFilter();
    }
}
