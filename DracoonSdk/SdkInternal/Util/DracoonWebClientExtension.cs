using System;
using System.Net;

namespace Dracoon.Sdk.SdkInternal.Util {
    internal class DracoonWebClientExtension : WebClient {
        private readonly long? _rangeFrom;
        private readonly long? _rangeTo;
        private IDracoonHttpConfig _config;

        public DracoonWebClientExtension(long? rangeFrom = null, long? rangeTo = null) {
            _rangeFrom = rangeFrom;
            _rangeTo = rangeTo;
        }

        public void SetHttpConfigParams(IDracoonHttpConfig httpConfig) {
            _config = httpConfig;
        }

        protected override WebRequest GetWebRequest(Uri address) {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
            if (request != null) {
                if (_rangeFrom.HasValue && _rangeTo.HasValue) {
                    request.AddRange(_rangeFrom.Value, _rangeTo.Value);
                }

                request.Timeout = _config.ConnectionTimeout;
                if (_config.WebProxy != null) {
                    request.Proxy = _config.WebProxy;
                }
            }

            return request;
        }
    }
}
