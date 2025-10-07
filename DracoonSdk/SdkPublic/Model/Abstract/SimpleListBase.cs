using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public abstract class SimpleListBase<T> {

        /// <summary>
        ///     The returned collection of items.
        /// </summary>
        public IEnumerable<T> Items {
            get; internal set;
        }
    }
}
