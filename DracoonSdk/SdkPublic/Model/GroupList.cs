using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public class GroupList {

        public long Offset {
            get; internal set;
        }

        public long Limit {
            get; internal set;
        }

        public long Total {
            get; internal set;
        }

        public List<Group> Items {
            get; internal set;
        }
    }
}
