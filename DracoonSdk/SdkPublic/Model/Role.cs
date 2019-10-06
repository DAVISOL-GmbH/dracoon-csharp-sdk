using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public class Role {

        public long Id {
            get; internal set;
        }

        public string Name {
            get; internal set;
        }

        public string Description {
            get; internal set;
        }

        public List<Right> Rights {
            get; internal set;
        }
    }
}
