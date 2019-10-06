using System;

namespace Dracoon.Sdk.Model {
    public class Group {

        public long Id {
            get; internal set;
        }

        public string Name {
            get; internal set;
        }

        public int CountUsers {
            get; internal set;
        }

        public DateTime? ExpireAt {
            get; internal set;
        }

        public DateTime? CreatedAt {
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
    }
}
