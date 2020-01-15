namespace Dracoon.Sdk.Filter {
    public class GetUsersFilter : DracoonFilter {

        public static EmailFilter Email => new EmailFilter();

        public static UserNameFilter UserName => new UserNameFilter();

        public static LoginFilter Login => new LoginFilter();

        public static FirstNameFilter FirstName => new FirstNameFilter();

        public static LastNameFilter LastName => new LastNameFilter();

        public static IsLockedFilter IsLocked => new IsLockedFilter();

        public static EffectiveRolesFilter EffectiveRoles => new EffectiveRolesFilter();


        public void AddEmailFilter(DracoonFilterType<EmailFilter> emailFilter) {
            CheckFilter(emailFilter, nameof(emailFilter));
            filtersList.Add(emailFilter);
        }

        public void AddUserNameFilter(DracoonFilterType<UserNameFilter> userNameFilter) {
            CheckFilter(userNameFilter, nameof(userNameFilter));
            filtersList.Add(userNameFilter);
        }

        public void AddLoginFilter(DracoonFilterType<LoginFilter> loginFilter) {
            CheckFilter(loginFilter, nameof(loginFilter));
            filtersList.Add(loginFilter);
        }

        public void AddFirstNameFilter(DracoonFilterType<FirstNameFilter> firstNameFilter) {
            CheckFilter(firstNameFilter, nameof(firstNameFilter));
            filtersList.Add(firstNameFilter);
        }

        public void AddLastNameFilter(DracoonFilterType<LastNameFilter> lastNameFilter) {
            CheckFilter(lastNameFilter, nameof(lastNameFilter));
            filtersList.Add(lastNameFilter);
        }

        public void AddIsLockedFilter(DracoonFilterType<IsLockedFilter> isLockedFilter) {
            CheckFilter(isLockedFilter, nameof(isLockedFilter));
            filtersList.Add(isLockedFilter);
        }

        public void AddEffectiveRolesFilter(DracoonFilterType<EffectiveRolesFilter> effectiveRolesFilter) {
            CheckFilter(effectiveRolesFilter, nameof(effectiveRolesFilter));
            filtersList.Add(effectiveRolesFilter);
        }
    }
}
