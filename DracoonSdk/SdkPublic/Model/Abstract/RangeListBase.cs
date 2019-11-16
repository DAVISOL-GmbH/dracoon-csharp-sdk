using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public abstract class RangeListBase<T> : SimpleListBase<T> {
        public long Offset {
            get; internal set;
        }

        public long Limit {
            get; internal set;
        }

        public long Total {
            get; internal set;
        }
    }
}
