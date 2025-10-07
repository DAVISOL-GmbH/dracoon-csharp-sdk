namespace Dracoon.Sdk.Sort {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class AuditNodesSort : DracoonSort {

        public static NodeIdSort<AuditNodesSort> NodeId => new NodeIdSort<AuditNodesSort>(new AuditNodesSort());

        public static NodeNameSort<AuditNodesSort> NodeName => new NodeNameSort<AuditNodesSort>(new AuditNodesSort());

        public static NodeParentIdSort<AuditNodesSort> NodeParentId => new NodeParentIdSort<AuditNodesSort>(new AuditNodesSort());

        public static NodeSizeSort<AuditNodesSort> NodeSize => new NodeSizeSort<AuditNodesSort>(new AuditNodesSort());

        public static NodeQuotaSort<AuditNodesSort> NodeQuota => new NodeQuotaSort<AuditNodesSort>(new AuditNodesSort());
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
