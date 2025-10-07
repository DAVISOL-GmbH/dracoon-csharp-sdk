using System;
using System.Collections.Generic;
using System.Linq;

namespace Dracoon.Sdk.Model {
    public class ChangeMembersRequest {
        public ChangeMembersRequest(IEnumerable<long> ids) {
            Ids = ids?.ToArray() ?? Array.Empty<long>();
        }

        public IEnumerable<long> Ids {
            get; private set;
        }
    }
}
