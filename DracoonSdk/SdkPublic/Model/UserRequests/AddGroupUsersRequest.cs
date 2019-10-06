using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    internal class AddGroupUserRequest {
        public List<long> Ids {
            get; private set;
        }

        public AddGroupUserRequest(List<long> ids) {
            Ids = ids;
        }
    }
}
