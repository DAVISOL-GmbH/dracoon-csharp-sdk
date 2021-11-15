namespace Dracoon.Sdk.Filter {
    public class GetOAuthClientsFilter : DracoonFilter {

        public static FlagFilter IsStandard => new FlagFilter("isStandard");

        public static FlagFilter IsExternal => new FlagFilter("isExternal");

        public static FlagFilter IsEnabled => new FlagFilter("isEnabled");


        public void AddIsStandardFilter(DracoonFilterType<FlagFilter> isStandardFilter) {
            CheckFilter(isStandardFilter, nameof(isStandardFilter));
            FiltersList.Add(isStandardFilter);
        }

        public void AddIsExternalFilter(DracoonFilterType<FlagFilter> isExternalFilter) {
            CheckFilter(isExternalFilter, nameof(isExternalFilter));
            FiltersList.Add(isExternalFilter);
        }

        public void AddIsEnabledFilter(DracoonFilterType<FlagFilter> isEnabledFilter) {
            CheckFilter(isEnabledFilter, nameof(isEnabledFilter));
            FiltersList.Add(isEnabledFilter);
        }
    }
}
