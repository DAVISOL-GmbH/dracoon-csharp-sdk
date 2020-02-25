using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public abstract class CollectionListBase<T> {

        public ICollection<T> Items {
            get; private set;
        } = new List<T>();
    }
}
