using System;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal;
using Dracoon.Sdk.SdkInternal.OAuth;
using Dracoon.Sdk.SdkInternal.Validator;

namespace Dracoon.Sdk {
    public abstract class DracoonClientBase : IInternalDracoonClientBase {

        /// <include file = "SdkPublicDoc.xml" path='docs/members[@name="dracoonClient"]/ServerUri/*'/>
        public Uri ServerUri {
            get; private set;
        }

        /// <include file = "SdkPublicDoc.xml" path='docs/members[@name="dracoonClient"]/Auth/*'/>
        public DracoonAuth Auth {
            get {
                return _oauth.Auth;
            }
            set {
                _oauth.Auth = value;
            }
        }

        public RequestInformation LastRequest { get; internal set; }

        #region Private Fields

        private IDracoonHttpConfig _httpConfig;
        private IRequestBuilder _requestBuilder;
        private IRequestExecutor _requestExecutor;
        private IOAuth _oauth;
        private ILog _logger;

        #endregion

        #region Internal

        ILog IInternalDracoonClientBase.Log => _logger;

        IRequestBuilder IInternalDracoonClientBase.Builder => _requestBuilder;

        IRequestExecutor IInternalDracoonClientBase.Executor => _requestExecutor;

        internal DracoonErrorParser ApiErrorParser {
            get; private set;
        }

        IOAuth IInternalDracoonClientBase.OAuth => _oauth;

        IDracoonHttpConfig IInternalDracoonClientBase.HttpConfig => _httpConfig;

        #endregion


        #region init internal

        protected void InitInternal(Uri serverUri, DracoonAuth auth, ILog logger, DracoonHttpConfig httpConfig) {
            serverUri.MustBeValid(nameof(serverUri));

            _logger = logger ?? new EmptyLog();
            ServerUri = serverUri;
            _httpConfig = httpConfig ?? new DracoonHttpConfig();

            #region init internal

            _oauth = new OAuthClient(this, auth);
            _requestBuilder = new DracoonRequestBuilder(this, _oauth);
            _requestExecutor = new DracoonRequestExecutor(this, _oauth);
            ApiErrorParser = new DracoonErrorParser(this);

            #endregion
        }

        #endregion

    }
}
