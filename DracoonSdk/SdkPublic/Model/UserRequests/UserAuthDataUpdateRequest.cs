namespace Dracoon.Sdk.Model {
    public class UserAuthDataUpdateRequest {

        public UserAuthMethod Method {
            get; internal set;
        }

        public string Login {
            get; internal set;
        }

        public int? ADConfigId {
            get; internal set;
        }

        public int? OIDConfigId {
            get; internal set;
        }
    }
}
