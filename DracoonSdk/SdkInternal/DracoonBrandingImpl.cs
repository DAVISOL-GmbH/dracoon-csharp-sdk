using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.Mapper;
using RestSharp;
using static Dracoon.Sdk.SdkInternal.DracoonRequestExecutor;

namespace Dracoon.Sdk.SdkInternal {
    internal class DracoonBrandingImpl : IBranding {

        internal static readonly string Logtag = nameof(DracoonBrandingImpl);
        private readonly IInternalDracoonBrandingClient _client;

        internal DracoonBrandingImpl(IInternalDracoonBrandingClient client) {
            _client = client;
        }

        #region Tenant branding services

        public CacheableBrandingResponse GetBranding() {
            _client.Executor.CheckApiServerVersion();

            RestRequest restRequest = _client.Builder.GetBranding();
            ApiCacheableBrandingResponse result = _client.Executor.DoSyncApiCall<ApiCacheableBrandingResponse>(restRequest, RequestType.GetBranding);
            return BrandingMapper.FromApiCacheableBrandingResponse(result);
        }

        public SoftwareVersionData GetVersion() {
            _client.Executor.CheckApiServerVersion();

            RestRequest restRequest = _client.Builder.GetBrandingServerVersion();
            ApiSoftwareVersionData result = _client.Executor.DoSyncApiCall<ApiSoftwareVersionData>(restRequest, RequestType.GetBrandingServerVersion);
            return BrandingMapper.FromApiSoftwareVersionData(result);
        }

        #endregion
    }
}
