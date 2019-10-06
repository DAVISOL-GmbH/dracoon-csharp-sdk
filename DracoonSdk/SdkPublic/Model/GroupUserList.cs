using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public class GroupUserList {

        public long Offset {
            get; internal set;
        }

        public long Limit {
            get; internal set;
        }

        public long Total {
            get; internal set;
        }

        public List<GroupUser> Items {
            get; internal set;
        }
    }
}
