namespace Dracoon.Sdk.Model {
    public class RadiusConfig {

        public string IpAddress {
            get; internal set;
        }

        public int Port {
            get; internal set;
        }

        public string SharedSecret {
            get; internal set;
        }

        public bool OtpPinFirst {
            get; internal set;
        }

        public FailoverServer FailoverServer {
            get; internal set;
        }
    }
}
