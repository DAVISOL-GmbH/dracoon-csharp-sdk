using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public sealed class ServerAuthenticationConfiguration {
        public IEnumerable<ServerAuthenticationMethod> AuthMethods {
            get; internal set;
        }

    }
}
