namespace Dracoon.Sdk.Sort {
    public class UserAttributesSort : DracoonSort {

        public static KeySort<UserAttributesSort> Key => new KeySort<UserAttributesSort>(new UserAttributesSort());

        public static ValueSort<UserAttributesSort> Value => new ValueSort<UserAttributesSort>(new UserAttributesSort());
    }
}
