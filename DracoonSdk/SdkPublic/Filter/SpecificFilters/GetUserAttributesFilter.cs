namespace Dracoon.Sdk.Filter {
    public class GetUserAttributesFilter : DracoonFilter {

        public static KeyFilter Key => new KeyFilter();

        public static ValueFilter IsMember => new ValueFilter();

    }
}
