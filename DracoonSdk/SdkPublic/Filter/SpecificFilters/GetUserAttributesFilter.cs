namespace Dracoon.Sdk.Filter {
    public class GetUserAttributesFilter : DracoonFilter {

        public static KeyFilter Key => new KeyFilter();

        public static ValueFilter Value => new ValueFilter();


        public void AddKeyFilter(DracoonFilterType<KeyFilter> keyFilter) {
            CheckFilter(keyFilter, nameof(keyFilter));
            filtersList.Add(keyFilter);
        }

        public void AddValueFilter(DracoonFilterType<ValueFilter> valueFilter) {
            CheckFilter(valueFilter, nameof(valueFilter));
            filtersList.Add(valueFilter);
        }
    }
}
