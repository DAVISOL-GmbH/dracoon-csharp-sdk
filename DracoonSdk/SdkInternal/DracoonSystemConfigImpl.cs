using Dracoon.Sdk.Filter;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.ApiModel.Requests;
using Dracoon.Sdk.SdkInternal.Mapper;
using Dracoon.Sdk.SdkInternal.Validator;
using RestSharp;
using System.Collections.Generic;
using static Dracoon.Sdk.SdkInternal.DracoonRequestExecutor;

namespace Dracoon.Sdk.SdkInternal {
    internal class DracoonSystemConfigImpl : ISystemConfig {
        internal const string Logtag = nameof(DracoonSystemConfigImpl);
        private readonly IInternalDracoonClient _client;

        internal DracoonSystemConfigImpl(IInternalDracoonClient client) {
            _client = client;
        }


        public ServerGeneralConfiguration GetGeneralConfiguration() {
            _client.Executor.CheckApiServerVersion();
            IRestRequest request = _client.Builder.GetGeneralConfiguration();
            ApiGeneralConfiguration apiGeneralConfig =
                _client.Executor.DoSyncApiCall<ApiGeneralConfiguration>(request, RequestType.GetServerGeneralConfig);
            return SettingsMapper.FromApiGeneralConfiguration(apiGeneralConfig);
        }

        public ServerGeneralConfiguration UpdateGeneralConfiguration(UpdateSystemGeneralConfigRequest updateRequest) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            updateRequest.MustNotNull(nameof(updateRequest));
            #endregion

            ApiUpdateSystemGeneralConfigRequest apiUpdateSystemGeneralConfigRequest = SettingsMapper.ToApiUpdateSystemGeneralConfigRequest(updateRequest);

            IRestRequest request = _client.Builder.UpdateGeneralConfiguration(apiUpdateSystemGeneralConfigRequest);
            ApiGeneralConfiguration apiGeneralConfig =
                _client.Executor.DoSyncApiCall<ApiGeneralConfiguration>(request, RequestType.PutServerGeneralConfig);
            return SettingsMapper.FromApiGeneralConfiguration(apiGeneralConfig);
        }

        #region Authentication related configuration

        public ServerAuthenticationConfiguration GetAuthConfiguration() {
            _client.Executor.CheckApiServerVersion();
            IRestRequest request = _client.Builder.GetAuthenticationConfiguration();
            ApiAuthenticationConfiguration apiAuthenticationConfig = _client.Executor.DoSyncApiCall<ApiAuthenticationConfiguration>(request, RequestType.GetAuthenticationSettings);
            return SettingsMapper.FromApiAuthenticationConfiguration(apiAuthenticationConfig);
        }

        public ActiveDirectoryConfigList GetAuthActiveDirectoryConfigurations() {
            _client.Executor.CheckApiServerVersion();
            IRestRequest request = _client.Builder.GetAuthActiveDirectoryConfigurations();
            ApiActiveDirectoryConfigList apiActiveDirectoryConfigList =
                _client.Executor.DoSyncApiCall<ApiActiveDirectoryConfigList>(request, RequestType.GetAuthActiveDirectorySettings);
            return SettingsMapper.FromApiActiveDirectoryConfigList(apiActiveDirectoryConfigList);
        }

        public OpenIdIdpConfigList GetAuthOpenIdIdpConfigurations() {
            _client.Executor.CheckApiServerVersion();
            IRestRequest request = _client.Builder.GetAuthOpenIdIdpConfigurations();
            IEnumerable<ApiOpenIdIdpConfig> apiOpenIdIdpConfigs =
                _client.Executor.DoSyncApiCall<List<ApiOpenIdIdpConfig>>(request, RequestType.GetAuthOpenIdIdpSettings);
            return SettingsMapper.FromApiOpenIdIpdConfigList(apiOpenIdIdpConfigs);
        }

        public RadiusConfig GetAuthRadiusConfiguration() {
            _client.Executor.CheckApiServerVersion();
            IRestRequest request = _client.Builder.GetAuthRadiusConfiguration();
            ApiRadiusConfig apiRadiusConfig =
                _client.Executor.DoSyncApiCall<ApiRadiusConfig>(request, RequestType.GetAuthRadiusSettings);
            return SettingsMapper.FromApiRadiusConfiguration(apiRadiusConfig);
        }

        #region OAuth Clients

        public OAuthClientConfigList GetOAuthClientConfigurations(GetOAuthClientsFilter filter = null) {
            _client.Executor.CheckApiServerVersion();
            IRestRequest request = _client.Builder.GetOAuthClientConfigurations(filter);
            List<ApiOAuthClientConfiguration> apiOAuthClientConfigList =
                _client.Executor.DoSyncApiCall<List<ApiOAuthClientConfiguration>>(request, RequestType.GetSystemOAuthClientConfigs);
            return SettingsMapper.FromApiOAuthClientConfigList(apiOAuthClientConfigList);
        }

        public OAuthClientConfiguration GetOAuthClientConfiguration(string clientId) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            clientId.MustNotNullOrEmptyOrWhitespace(nameof(clientId));
            #endregion
            IRestRequest request = _client.Builder.GetOAuthClientConfiguration(clientId);
            ApiOAuthClientConfiguration apiOAuthClientConfig =
                _client.Executor.DoSyncApiCall<ApiOAuthClientConfiguration>(request, RequestType.GetSystemOAuthClientConfig);
            return SettingsMapper.FromApiOAuthClientConfiguration(apiOAuthClientConfig);
        }

        public OAuthClientConfiguration CreateOAuthClientConfiguration(CreateOAuthClientRequest createRequest) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            createRequest.MustNotNull(nameof(createRequest));
            createRequest.ClientName.MustNotNullOrEmptyOrWhitespace(nameof(createRequest.ClientName), false);
            createRequest.GrantTypes.MustNotBeDefault(nameof(createRequest.GrantTypes));
            #endregion

            ApiCreateOAuthClientRequest apiCreateOAuthClientRequest = SettingsMapper.ToApiCreateOAuthClientRequest(createRequest);

            IRestRequest request = _client.Builder.CreateOAuthClientConfiguration(apiCreateOAuthClientRequest);
            ApiOAuthClientConfiguration apiOAuthClientConfig =
                _client.Executor.DoSyncApiCall<ApiOAuthClientConfiguration>(request, RequestType.PostSystemOAuthClientConfig);
            return SettingsMapper.FromApiOAuthClientConfiguration(apiOAuthClientConfig);
        }

        public OAuthClientConfiguration UpdateOAuthClientConfiguration(string clientId, UpdateOAuthClientRequest updateRequest) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            clientId.MustNotNullOrEmptyOrWhitespace(nameof(clientId));
            updateRequest.MustNotNull(nameof(updateRequest));
            updateRequest.ClientName.MustNotNullOrEmptyOrWhitespace(nameof(updateRequest.ClientName), true);
            #endregion

            ApiUpdateOAuthClientRequest apiUpdateOAuthClientRequest = SettingsMapper.ToApiUpdateOAuthClientRequest(updateRequest);

            IRestRequest request = _client.Builder.UpdateOAuthClientConfiguration(clientId, apiUpdateOAuthClientRequest);
            ApiOAuthClientConfiguration apiOAuthClientConfig =
                _client.Executor.DoSyncApiCall<ApiOAuthClientConfiguration>(request, RequestType.PutSystemOAuthClientConfig);
            return SettingsMapper.FromApiOAuthClientConfiguration(apiOAuthClientConfig);
        }

        public void DeleteOAuthClientConfiguration(string clientId) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            clientId.MustNotNullOrEmptyOrWhitespace(nameof(clientId));
            #endregion
            IRestRequest request = _client.Builder.DeleteOAuthClientConfiguration(clientId);
            _client.Executor.DoSyncApiCall<VoidResponse>(request, RequestType.DeleteSystemOAuthClientConfig);
        }

        #endregion

        #endregion
    }
}
