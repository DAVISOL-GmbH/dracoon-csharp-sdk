using System;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal;
using Dracoon.Sdk.SdkInternal.OAuth;
using Dracoon.Sdk.SdkInternal.Validator;

namespace Dracoon.Sdk {
    public class DracoonBrandingClient : DracoonClientBase, IInternalDracoonBrandingClient {

        #region Class-Members

        #region Public interfaces

        private readonly DracoonBrandingImpl _branding;

        DracoonBrandingImpl IInternalDracoonBrandingClient.BrandingImpl => _branding;

        public IBranding Branding => _branding;

        #endregion

        #endregion

        public DracoonBrandingClient(Uri serverUri, ILog logger = null, DracoonHttpConfig httpConfig = null) {
            InitInternal(serverUri, null, logger, httpConfig);

            #region init public interfaces

            _branding = new DracoonBrandingImpl(this);

            #endregion
        }


    }
}
