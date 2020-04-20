using System;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal;
using Dracoon.Sdk.SdkInternal.OAuth;
using Dracoon.Sdk.SdkInternal.Validator;

namespace Dracoon.Sdk {
    public class DracoonBrandingClient : DracoonClientBase {

        #region Class-Members

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

        #region Public interfaces

        internal DracoonBrandingImpl BrandingImpl {
            get; private set;
        }

        public IBranding Branding {
            get {
                return BrandingImpl;
            }
        }

        #endregion

        #endregion

        public DracoonBrandingClient(Uri serverUri, ILog logger = null, DracoonHttpConfig httpConfig = null) {
            InitInternal(serverUri, null, logger, httpConfig);

            #region init public interfaces

            BrandingImpl = new DracoonBrandingImpl(this);

            #endregion
        }


    }
}
