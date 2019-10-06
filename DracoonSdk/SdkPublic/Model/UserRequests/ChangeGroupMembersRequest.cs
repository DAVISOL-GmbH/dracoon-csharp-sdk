using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public class ChangeGroupMembersRequest {

        public List<long> Ids {
            get; private set;
        }

        public ChangeGroupMembersRequest(List<long> ids) {
            Ids = ids;
        }
    }
}
