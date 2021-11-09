namespace Dracoon.Sdk.Model {
    public sealed class ServerAuthenticationMethod {

        public UserAuthMethod AuthMethod { get; internal set; }

        public bool IsEnabled { get; internal set; }

        public int Priority { get; internal set; }
    }
}
