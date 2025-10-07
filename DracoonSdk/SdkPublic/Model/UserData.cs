using Dracoon.Crypto.Sdk.Model;

namespace Dracoon.Sdk.Model {
    public class UserData : UserItem {

        public UserAuthData AuthData {
            get; internal set;
        }

        public UserPublicKey PublicKeyContainer {
            get; internal set;
        }
    }
}
