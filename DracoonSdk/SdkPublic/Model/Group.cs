using System;
using System.Collections;
using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public class Group : GroupInfo {

        public int CountUsers {
            get; internal set;
        }

        public DateTime? ExpireAt {
            get; internal set;
        }

        public DateTime CreatedAt {
            get; internal set;
        }

        public UserInfo CreatedBy {
            get; internal set;
        }

        public DateTime? UpdatedAt {
            get; internal set;
        }

        public UserInfo UpdatedBy {
            get; internal set;
        }

        public IEnumerable<Role> GroupRoles {
            get; internal set;
        }
    }
}
