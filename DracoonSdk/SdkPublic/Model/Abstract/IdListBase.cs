using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public abstract class IdListBase {

        public ICollection<long> Ids {
            get; private set;
        } = new List<long>();
    }
}
