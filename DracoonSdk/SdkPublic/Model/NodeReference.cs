namespace Dracoon.Sdk.Model {
    public class NodeReference {

        public long Id {
            get; internal set;
        }

        public NodeType Type {
            get; internal set;
        }

        public long? ParentId {
            get; internal set;
        }

        public string ParentPath {
            get; internal set;
        }

        public string Name {
            get; internal set;
        }
    }
}
