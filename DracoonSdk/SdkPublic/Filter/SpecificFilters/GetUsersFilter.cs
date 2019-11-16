namespace Dracoon.Sdk.Filter {
    public class GetUsersFilter : DracoonFilter {

        public static EmailFilter Email => new EmailFilter();

        public static UserNameFilter UserName => new UserNameFilter();

        public static LoginFilter Login => new LoginFilter();

        public static FirstNameFilter FirstName => new FirstNameFilter();

        public static LastNameFilter LastName => new LastNameFilter();

        public static IsLockedFilter IsLocked => new IsLockedFilter();

        public static EffectiveRolesFilter EffectiveRoles => new EffectiveRolesFilter();
    }
}
