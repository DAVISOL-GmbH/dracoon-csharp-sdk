namespace Dracoon.Sdk.Model {
    public class AuditUserPermission {

        public long UserId {
            get; internal set;
        }

        public string UserLogin {
            get; internal set;
        }

        public string UserFirstName {
            get; internal set;
        }

        public string UserLastName {
            get; internal set;
        }

        public NodePermissions Permissions {
            get; internal set;
        }
    }
}
