using System;

namespace Dracoon.Sdk.Model {
    public class GroupUser {

        public UserInfo UserInfo {
            get; internal set;
        }

        public bool IsMember {
            get; internal set;
        }

        [Obsolete("Deprecated since version 4.11.0")]
        public long Id {
            get; internal set;
        }

        [Obsolete("Deprecated since version 4.11.0")]
        public string Login {
            get; internal set;
        }

        [Obsolete("Deprecated since version 4.11.0")]
        public string DisplayName {
            get; internal set;
        }

        [Obsolete("Deprecated since version 4.11.0")]
        public string Email {
            get; internal set;
        }
    }
}
