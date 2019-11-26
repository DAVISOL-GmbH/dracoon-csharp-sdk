namespace Dracoon.Sdk.Model {
    public class UserAuthData {

        public AuthMethodType Method {
            get; set;
        }

        public string Login {
            get; set;
        }

        public string Password {
            get; set;
        }

        public bool MustChangePassword {
            get; set;
        }

        public int? AdConfigId {
            get; set;
        }

        public int? OidConfigId {
            get; set;
        }
    }
}
