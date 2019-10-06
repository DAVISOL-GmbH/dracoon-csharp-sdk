
using System;

namespace Dracoon.Sdk.Model {
    public class UpdateGroupRequest {

        public string Name {
            get; private set;
        }

        public DateTime? Expiration {
            get; set;
        }
    }
}
