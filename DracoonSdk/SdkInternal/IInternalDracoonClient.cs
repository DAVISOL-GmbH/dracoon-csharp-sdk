namespace Dracoon.Sdk.SdkInternal {
    internal interface IInternalDracoonClient : IInternalDracoonClientBase {
        char[] EncryptionPassword { get; set; }

        DracoonAccountImpl AccountImpl { get; }
        DracoonNodesImpl NodesImpl { get; }
        DracoonSharesImpl SharesImpl { get; }
        DracoonServerImpl ServerImpl { get; }
        DracoonUsersImpl UsersImpl { get; }
        DracoonGroupsImpl GroupsImpl { get; }
        DracoonRolesImpl RolesImpl { get; }
        DracoonEventLogImpl EventLogImpl { get; }
    }
}
