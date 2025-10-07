using System.Collections.Generic;
using System.Linq;

namespace Dracoon.Sdk.Model {
    public class UserAttributes : SimpleListBase<KeyValuePair<string, string>> {

        public UserAttributes() { }

        public UserAttributes(IEnumerable<KeyValuePair<string, string>> items) {
            Items = items.ToArray();
        }
    }
}
