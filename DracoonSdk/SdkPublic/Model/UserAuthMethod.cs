using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public class UserAuthMethod {

        public AuthMethodType AuthId {
            get; internal set;
        }

        public bool IsEnabled {
            get; internal set;
        }

        public List<KeyValuePair<string, string>> Options {
            get; internal set;
        }
    }
}
