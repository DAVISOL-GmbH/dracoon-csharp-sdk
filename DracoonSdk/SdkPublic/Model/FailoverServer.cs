namespace Dracoon.Sdk.Model {
    public class FailoverServer {

        public bool FailoverEnabled {
            get; internal set;
        }

        public string FailoverIpAddress {
            get; internal set;
        }

        public int FailoverPort {
            get; internal set;
        }
    }
}
