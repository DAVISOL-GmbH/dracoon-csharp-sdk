using Dracoon.Crypto.Sdk;
using Dracoon.Sdk.Error;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.ApiModel.Settings;
using Dracoon.Sdk.SdkInternal.Mapper;
using RestSharp;
using System.Collections.Generic;
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
        public List<UserKeyPairAlgorithmData> GetAvailableUserKeyPairAlgorithms() {
            try {
                // Check if api supports this api endpoint. If not only provide the algorithm for the "old" crypto.
                _client.Executor.CheckApiServerVersion(ApiConfig.ApiGetAlgorithmsMinimumVersion);
            } catch (DracoonApiException) {
                return new List<UserKeyPairAlgorithmData>() { new UserKeyPairAlgorithmData() {
                    Algorithm = UserKeyPairAlgorithm.RSA2048,
                    State = AlgorithmState.Required
                }};
            }

            IRestRequest request = _client.Builder.GetAlgorithms();
            ApiAlgorithms algorithms = _client.Executor.DoSyncApiCall<ApiAlgorithms>(request, DracoonRequestExecutor.RequestType.GetAlgorithms);
            return SettingsMapper.FromApiUserKeyPairAlgorithms(algorithms.KeyPairAlgorithms);
        }

        public List<FileKeyAlgorithmData> GetAvailableFileKeyAlgorithms() {
            try {
                // Check if api supports this api endpoint. If not only provide the algorithm for the "old" crypto.
                _client.Executor.CheckApiServerVersion(ApiConfig.ApiGetAlgorithmsMinimumVersion);
            } catch (DracoonApiException) {
                return new List<FileKeyAlgorithmData>() { new FileKeyAlgorithmData() {
                    Algorithm = EncryptedFileKeyAlgorithm.RSA2048_AES256GCM,
                    State = AlgorithmState.Required
                }};
            }

            IRestRequest request = _client.Builder.GetAlgorithms();
            ApiAlgorithms algorithms = _client.Executor.DoSyncApiCall<ApiAlgorithms>(request, DracoonRequestExecutor.RequestType.GetAlgorithms);
            return SettingsMapper.FromApiFileKeyAlgorithms(algorithms.FileKeyAlgorithms);
        }

    }
}
