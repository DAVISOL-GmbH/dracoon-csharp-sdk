using Dracoon.Crypto.Sdk.Model;

namespace Dracoon.Sdk.Model {
    public class RoomUser {

        public UserInfo UserInfo {
            get; internal set;
        }

        public bool IsGranted {
            get; internal set;
        }

        public NodePermissions Permissions {
            get; internal set;
        }

        public UserPublicKey PublicKeyContainer {
            get; internal set;
        }
    }
}
