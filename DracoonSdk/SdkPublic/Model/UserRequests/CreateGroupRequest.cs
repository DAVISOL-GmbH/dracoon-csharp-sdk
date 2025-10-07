
using System;

namespace Dracoon.Sdk.Model {
    public class CreateGroupRequest {

        public string Name {
            get; private set;
        }

        public DateTime? Expiration {
            get; set;
        }

        public CreateGroupRequest(string name) {
            Name = name;
        }
    }
}
