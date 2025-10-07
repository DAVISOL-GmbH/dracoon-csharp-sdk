namespace Dracoon.Sdk.Model {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
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
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
