namespace Dracoon.Sdk.Model {
    public class UserAuthData {

        public AuthMethodType Method {
            get; internal set;
        }

        public string Login {
            get; internal set;
        }

        public string Password {
            get; internal set;
        }

        public bool MustChangePassword {
            get; internal set;
        }

        public int? AdConfigId {
            get; internal set;
        }

        public int? OidConfigId {
            get; internal set;
        }
    }
}
