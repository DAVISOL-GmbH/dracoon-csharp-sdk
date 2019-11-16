using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public abstract class SimpleListBase<T> {

        public IEnumerable<T> Items {
            get; internal set;
        }
    }
}
