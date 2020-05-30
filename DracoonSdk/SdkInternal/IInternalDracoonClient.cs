namespace Dracoon.Sdk.SdkInternal {
    internal interface IInternalDracoonClient : IInternalDracoonClientBase {
        string EncryptionPassword { get; set; }

        DracoonAccountImpl AccountImpl { get; }
        DracoonNodesImpl NodesImpl { get; }
        DracoonSharesImpl SharesImpl { get; }
        DracoonServerImpl ServerImpl { get; }
        DracoonUsersImpl UsersImpl { get; }
        DracoonGroupsImpl GroupsImpl { get; }
        DracoonEventLogImpl EventLogImpl { get; }
    }
}
