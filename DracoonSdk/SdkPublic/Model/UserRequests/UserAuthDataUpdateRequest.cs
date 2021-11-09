namespace Dracoon.Sdk.Model {
    public class UserAuthDataUpdateRequest {

        public UserAuthMethod Method {
            get; internal set;
        }

        public string Login {
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
