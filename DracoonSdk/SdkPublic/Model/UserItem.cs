using System;

namespace Dracoon.Sdk.Model {
    public class UserItem {

        public long Id {
            get; internal set;
        }

        public string UserName {
            get; internal set;
        }

        public string FirstName {
            get; internal set;
        }

        public string LastName {
            get; internal set;
        }

        public bool IsLocked {
            get; internal set;
        }

        public bool HasManagableRooms {
            get; internal set;
        }

        public string AvatarUuid {
            get; internal set;
        }

        [Obsolete("[Deprecated since version 4.7.0, use IsLocked instead")]
        public int LockStatus {
            get; internal set;
        }

        [Obsolete("[Deprecated since version 4.13.0")]
        public string Login {
            get; internal set;
        }

        public string Title {
            get; internal set;
        }

        public DateTime? CreatedAt {
            get; internal set;
        }

        public DateTime? LastLoginSuccessAt {
            get; internal set;
        }

        public DateTime? ExpireAt {
            get; internal set;
        }

        public bool IsEncryptionEnabled {
            get; internal set;
        }

        public string Email {
            get; internal set;
        }

        public string Phone {
            get; internal set;
        }

        public long HomeRoomId {
            get; internal set;
        }

        public RoleList UserRoles {
            get; internal set;
        }

        public UserAttributes UserAttributes {
            get; internal set;
        }
    }
}
