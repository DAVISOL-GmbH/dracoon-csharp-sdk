using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.Mapper;
using Dracoon.Sdk.SdkInternal.Validator;
using RestSharp;
using System;
using static Dracoon.Sdk.SdkInternal.DracoonRequestExecutor;

namespace Dracoon.Sdk.SdkInternal {
    internal class DracoonServerImpl : IServer {
        internal const string Logtag = nameof(DracoonServerImpl);
        private readonly IInternalDracoonClient _client;

        public IServerSettings ServerSettings { get; set; }

        internal DracoonServerImpl(IInternalDracoonClient client) {
            _client = client;
            ServerSettings = new DracoonServerSettingsImpl(client);
        }

        public string GetVersion() {
            _client.Executor.CheckApiServerVersion();
            IRestRequest request = _client.Builder.GetServerVersion();
            ApiServerVersion result = _client.Executor.DoSyncApiCall<ApiServerVersion>(request, RequestType.GetServerVersion);
            return result.ServerVersion;
        }

        public DateTime? GetTime() {
            _client.Executor.CheckApiServerVersion();
            IRestRequest request = _client.Builder.GetServerTime();
            ApiServerTime result = _client.Executor.DoSyncApiCall<ApiServerTime>(request, RequestType.GetServerTime);
            return result.Time;
        }

        public PublicDownloadShare GetPublicDownloadShare(string accessKey) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            accessKey.MustNotNullOrEmptyOrWhitespace(nameof(accessKey));
            #endregion

            IRestRequest restRequest = _client.Builder.GetPublicDownloadShare(accessKey);
            ApiPublicDownloadShare result = _client.Executor.DoSyncApiCall<ApiPublicDownloadShare>(restRequest, RequestType.GetPublicDownloadShare);
            return ServerMapper.FromApiPublicDownloadShare(result);
        }

        public PublicUploadShare GetPublicUploadShare(string accessKey) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            accessKey.MustNotNullOrEmptyOrWhitespace(nameof(accessKey));
            #endregion

            IRestRequest restRequest = _client.Builder.GetPublicUploadShare(accessKey);
            ApiPublicUploadShare result = _client.Executor.DoSyncApiCall<ApiPublicUploadShare>(restRequest, RequestType.GetPublicUploadShare);
            return ServerMapper.FromApiPublicUploadShare(result);
        }
    }
}
