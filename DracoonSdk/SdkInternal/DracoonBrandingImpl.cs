using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.Mapper;
using RestSharp;

namespace Dracoon.Sdk.SdkInternal {
    internal class DracoonBrandingImpl : IBranding {

        internal static readonly string LOGTAG = nameof(DracoonBrandingImpl);
        private DracoonBrandingClient client;

        internal DracoonBrandingImpl(DracoonBrandingClient client) {
            this.client = client;
        }

        #region Tenant branding services

        public CacheableBrandingResponse GetBranding() {
            client.RequestExecutor.CheckApiServerVersion();

            RestRequest restRequest = client.RequestBuilder.GetBranding();
            ApiCacheableBrandingResponse result = client.RequestExecutor.DoSyncApiCall<ApiCacheableBrandingResponse>(restRequest, DracoonRequestExecuter.RequestType.GetBranding);
            return BrandingMapper.FromApiCacheableBrandingResponse(result);
        }

        public SoftwareVersionData GetVersion() {
            client.RequestExecutor.CheckApiServerVersion();

            RestRequest restRequest = client.RequestBuilder.GetBrandingServerVersion();
            ApiSoftwareVersionData result = client.RequestExecutor.DoSyncApiCall<ApiSoftwareVersionData>(restRequest, DracoonRequestExecuter.RequestType.GetBrandingServerVersion);
            return BrandingMapper.FromApiSoftwareVersionData(result);
        }

        #endregion
    }
}
