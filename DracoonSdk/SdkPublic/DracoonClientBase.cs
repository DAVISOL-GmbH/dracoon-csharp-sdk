using System;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal;
using Dracoon.Sdk.SdkInternal.OAuth;
using Dracoon.Sdk.SdkInternal.Validator;

namespace Dracoon.Sdk {
    public abstract class DracoonClientBase {

        /// <include file = "SdkPublicDoc.xml" path='docs/members[@name="dracoonClient"]/ServerUri/*'/>
        public Uri ServerUri {
            get; private set;
        }

        /// <include file = "SdkPublicDoc.xml" path='docs/members[@name="dracoonClient"]/Auth/*'/>
        public DracoonAuth Auth {
            get {
                return OAuthClient.dracoonAuth;
            }
            set {
                OAuthClient.dracoonAuth = value;
            }
        }

        public RequestInformation LastRequest { get; internal set; }

        #region Internal

        internal DracoonHttpConfig HttpConfig {
            get; private set;
        }

        internal ILog Log {
            get; private set;
        }

        internal DracoonRequestBuilder RequestBuilder {
            get; private set;
        }

        internal DracoonRequestExecuter RequestExecutor {
            get; private set;
        }

        internal DracoonErrorParser ApiErrorParser {
            get; private set;
        }

        internal OAuthClient OAuthClient {
            get; private set;
        }

        #endregion


        #region init internal

        protected void InitInternal(Uri serverUri, DracoonAuth auth, ILog logger, DracoonHttpConfig httpConfig) {
            serverUri.MustBeValid(nameof(serverUri));

            ServerUri = serverUri;
            Log = logger ?? new EmptyLog();
            HttpConfig = httpConfig ?? new DracoonHttpConfig();

            #region init internal

            OAuthClient = new OAuthClient(this, auth);
            RequestBuilder = new DracoonRequestBuilder(this);
            RequestExecutor = new DracoonRequestExecuter(this);
            ApiErrorParser = new DracoonErrorParser(this);

            #endregion
        }

        #endregion

    }
}
