namespace Dracoon.Sdk.Sort {
    public class UsersSort : DracoonSort {

        public static UserNameSort<UsersSort> UserName => new UserNameSort<UsersSort>(new UsersSort());

        public static EmailSort<UsersSort> Email => new EmailSort<UsersSort>(new UsersSort());

        public static LoginSort<UsersSort> Login => new LoginSort<UsersSort>(new UsersSort());

        public static FirstNameSort<UsersSort> FirstName => new FirstNameSort<UsersSort>(new UsersSort());

        public static LastNameSort<UsersSort> LastName => new LastNameSort<UsersSort>(new UsersSort());

        public static IsLockedSort<UsersSort> IsLocked => new IsLockedSort<UsersSort>(new UsersSort());

        public static LastLoginSuccessAtSort<UsersSort> LastLoginSuccessAt => new LastLoginSuccessAtSort<UsersSort>(new UsersSort());

        public static ExpireAtSort<UsersSort> ExpireAt => new ExpireAtSort<UsersSort>(new UsersSort());
    }
}
