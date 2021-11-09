using System;

namespace Dracoon.Sdk.Model {
    public class GroupUser {

        public UserInfo UserInfo {
            get; internal set;
        }

        public bool IsMember {
            get; internal set;
        }
    }
}
