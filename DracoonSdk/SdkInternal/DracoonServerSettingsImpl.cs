using System.Collections.Generic;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.Mapper;
using RestSharp;
using static Dracoon.Sdk.SdkInternal.DracoonRequestExecutor;

namespace Dracoon.Sdk.SdkInternal {
    internal class DracoonServerSettingsImpl : IServerSettings {
        internal const string Logtag = nameof(DracoonServerSettingsImpl);
        private readonly IInternalDracoonClient _client;

        internal DracoonServerSettingsImpl(IInternalDracoonClient client) {
            _client = client;
        }

        public ServerDefaultSettings GetDefault() {
            _client.Executor.CheckApiServerVersion();
            IRestRequest request = _client.Builder.GetDefaultsSettings();
            ApiDefaultsSettings apiDefaultsSettings =
                _client.Executor.DoSyncApiCall<ApiDefaultsSettings>(request, RequestType.GetDefaultsSettings);
            return SettingsMapper.FromApiDefaultsSettings(apiDefaultsSettings);
        }

        public ServerGeneralSettings GetGeneral() {
            _client.Executor.CheckApiServerVersion();
            IRestRequest request = _client.Builder.GetGeneralSettings();
            ApiGeneralSettings apiGeneralSettings =
                _client.Executor.DoSyncApiCall<ApiGeneralSettings>(request, RequestType.GetGeneralSettings);
            return SettingsMapper.FromApiGeneralSettings(apiGeneralSettings);
        }

        public ServerInfrastructureSettings GetInfrastructure() {
            _client.Executor.CheckApiServerVersion();
            IRestRequest request = _client.Builder.GetInfrastructureSettings();
            ApiInfrastructureSettings apiInfrastructureSettings =
                _client.Executor.DoSyncApiCall<ApiInfrastructureSettings>(request, RequestType.GetInfrastructureSettings);
            return SettingsMapper.FromApiInfrastructureSettings(apiInfrastructureSettings);
        }

        public PasswordPolicies GetPasswordPolicies() {
            _client.Executor.CheckApiServerVersion(ApiConfig.ApiGetPasswordPoliciesMinimumVersion);
            IRestRequest request = _client.Builder.GetPasswordPolicies();
            ApiPasswordSettings apiPasswordPolicies =
                _client.Executor.DoSyncApiCall<ApiPasswordSettings>(request, RequestType.GetPasswordPolicies);
            return SettingsMapper.FromApiPasswordPolicies(apiPasswordPolicies);
        }

        public ServerAuthenticationSettings GetAuth() {
            _client.Executor.CheckApiServerVersion();
            IRestRequest request = _client.Builder.GetAuthenticationSettings();
            ApiAuthenticationSettings apiAuthenticationSettings = _client.Executor.DoSyncApiCall<ApiAuthenticationSettings>(request, RequestType.GetAuthenticationSettings);
            return SettingsMapper.FromApiAuthenticationSettings(apiAuthenticationSettings);
        }

        public ActiveDirectoryConfigList GetAuthActiveDirectorySettings() {
            _client.Executor.CheckApiServerVersion();
            IRestRequest request = _client.Builder.GetAuthActiveDirectorySettings();
            ApiActiveDirectoryConfigList apiActiveDirectoryConfigList =
                _client.Executor.DoSyncApiCall<ApiActiveDirectoryConfigList>(request, RequestType.GetAuthActiveDirectorySettings);
            return SettingsMapper.FromApiActiveDirectoryConfigList(apiActiveDirectoryConfigList);
        }

        public OpenIdIdpConfigList GetAuthOpenIdIdpSettings() {
            _client.Executor.CheckApiServerVersion();
            IRestRequest request = _client.Builder.GetAuthOpenIdIdpSettings();
            IEnumerable<ApiOpenIdIdpConfig> apiOpenIdIdpConfigs =
                _client.Executor.DoSyncApiCall<List<ApiOpenIdIdpConfig>>(request, RequestType.GetAuthOpenIdIdpSettings);
            return SettingsMapper.FromApiOpenIdIpdConfigs(apiOpenIdIdpConfigs);
        }

        public RadiusConfig GetAuthRadiusSettings() {
            _client.Executor.CheckApiServerVersion();
            IRestRequest request = _client.Builder.GetAuthRadiusSettings();
            ApiRadiusConfig apiRadiusConfig =
                _client.Executor.DoSyncApiCall<ApiRadiusConfig>(request, RequestType.GetAuthRadiusSettings);
            return SettingsMapper.FromApiRadiusConfig(apiRadiusConfig);
        }
    }
}
