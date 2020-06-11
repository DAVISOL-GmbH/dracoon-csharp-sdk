using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public class ChangeMembersRequest {

        public List<long> Ids {
            get; private set;
        }

        public ChangeMembersRequest(List<long> ids) {
            Ids = ids;
        }
    }
}
