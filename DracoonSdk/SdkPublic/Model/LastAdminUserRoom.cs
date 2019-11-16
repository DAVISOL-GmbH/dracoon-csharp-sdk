namespace Dracoon.Sdk.Model {
    public class LastAdminUserRoom {

        public long Id {
            get; internal set;
        }

        public string Name {
            get; internal set;
        }

        public string ParentPath {
            get; internal set;
        }

        public bool LastAdminInGroup {
            get; internal set;
        }

        public long ParentId {
            get; internal set;
        }

        public long? LastAdminInGroupId {
            get; internal set;
        }
    }
}
