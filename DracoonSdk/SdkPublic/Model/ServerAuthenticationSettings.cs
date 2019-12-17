using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public sealed class ServerAuthenticationSettings {
        public IEnumerable<ServerAuthenticationMethod> AuthMethods {
            get; internal set;
        }

    }
}
