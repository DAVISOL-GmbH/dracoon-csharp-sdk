using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal;
using Dracoon.Sdk.SdkInternal.OAuth;
using Dracoon.Sdk.SdkInternal.Validator;
using Dracoon.Sdk.SdkPublic.SdkPublicInterfaces;
using System;

namespace Dracoon.Sdk {
    /// <summary>
    /// Implements the base logic of a client connecting to a Dracoon-API (either the core or the branding API). Implemented by <see cref="DracoonClient"/> and <see cref="DracoonBrandingClient"/>.
    /// </summary>
    /// <seealso cref="DracoonClient"/>
    /// <seealso cref="DracoonBrandingClient"/>
    public abstract class DracoonClientBase : IInternalDracoonClientBase {

        /// <summary>
        /// <see cref="IInternalDracoonClientBase.ServerUri"/>
        /// </summary>
        public Uri ServerUri {
            get; private set;
        }

        /// <summary>
        ///     The current authorization data. See also <seealso cref="Dracoon.Sdk.DracoonAuth"/>
        /// </summary>
        public DracoonAuth Auth {
            get => _oauth.Auth;
            set => _oauth.Auth = value;
        }

        /// <summary>
        /// Get information about the last processed request (either successful or not)
        /// </summary>
        public RequestInformation LastRequest { get; internal set; }

        #region Private Fields

        private IDracoonHttpConfig _httpConfig;
        private IRequestBuilder _requestBuilder;
        private IRequestExecutor _requestExecutor;
        private IOAuth _oauth;
        private ILog _logger;
        private DracoonClientStatistics _statistics;

        #endregion

        #region Internal

        ILog IInternalDracoonClientBase.Log => _logger;

        IRequestBuilder IInternalDracoonClientBase.Builder => _requestBuilder;

        IRequestExecutor IInternalDracoonClientBase.Executor => _requestExecutor;

        IOAuth IInternalDracoonClientBase.OAuth => _oauth;

        IDracoonHttpConfig IInternalDracoonClientBase.HttpConfig => _httpConfig;

        DracoonClientStatistics IInternalDracoonClientBase.ClientStats => _statistics;

        #endregion

        /// <summary>
        /// Access the request statistics for this client instance.
        /// </summary>
        public IDracoonClientStatistics Statistics => _statistics;

        #region init internal

        /// <summary>
        /// Initialize the client's base properties
        /// </summary>
        /// <param name="serverUri"><see cref="ServerUri"/></param>
        /// <param name="auth"><see cref="Auth"/></param>
        /// <param name="logger"></param>
        /// <param name="httpConfig"></param>
        protected void InitInternal(Uri serverUri, DracoonAuth auth, ILog logger, DracoonHttpConfig httpConfig) {
            serverUri.MustBeValid(nameof(serverUri));

            _statistics = new DracoonClientStatistics();
            _logger = logger ?? new EmptyLog();
            ServerUri = serverUri;
            _httpConfig = httpConfig ?? new DracoonHttpConfig();

            #region init internal

            _oauth = new OAuthClient(this, auth);
            _requestBuilder = new DracoonRequestBuilder(this, _oauth);
            _requestExecutor = new DracoonRequestExecutor(this, _oauth);
            DracoonErrorParser.DracoonClient = this;
            
            #endregion
        }

        #endregion

    }
}
