using System;
using Dracoon.Sdk.SdkInternal;

namespace Dracoon.Sdk {
    /// <include file = "SdkPublicDoc.xml" path='docs/members[@name="dracoonClient"]/DracoonClient/*'/>
    public class DracoonClient : DracoonClientBase, IInternalDracoonClient, IInternalDracoonClientBase {

        #region Class-Members

        /// <include file = "SdkPublicDoc.xml" path='docs/members[@name="dracoonClient"]/EncryptionPassword/*'/>
        public string EncryptionPassword { get; set; }

        #region Public interfaces

        private readonly DracoonAccountImpl _account;
        private readonly DracoonNodesImpl _nodes;
        private readonly DracoonSharesImpl _shares;
        private readonly DracoonServerImpl _server;
        private readonly DracoonUsersImpl _users;
        private readonly DracoonGroupsImpl _groups;
        private readonly DracoonRolesImpl _roles;
        private readonly DracoonEventLogImpl _eventLog;

        DracoonAccountImpl IInternalDracoonClient.AccountImpl => _account;

        DracoonNodesImpl IInternalDracoonClient.NodesImpl => _nodes;

        DracoonSharesImpl IInternalDracoonClient.SharesImpl => _shares;

        DracoonServerImpl IInternalDracoonClient.ServerImpl => _server;

        DracoonUsersImpl IInternalDracoonClient.UsersImpl => _users;

        DracoonGroupsImpl IInternalDracoonClient.GroupsImpl => _groups;

        DracoonRolesImpl IInternalDracoonClient.RolesImpl => _roles;

        DracoonEventLogImpl IInternalDracoonClient.EventLogImpl => _eventLog;

        /// <include file = "SdkPublicDoc.xml" path='docs/members[@name="dracoonClient"]/Account/*'/>
        public IAccount Account => _account;

        /// <include file = "SdkPublicDoc.xml" path='docs/members[@name="dracoonClient"]/Server/*'/>
        public IServer Server => _server;

        /// <include file = "SdkPublicDoc.xml" path='docs/members[@name="dracoonClient"]/Nodes/*'/>
        public INodes Nodes => _nodes;

        /// <include file = "SdkPublicDoc.xml" path='docs/members[@name="dracoonClient"]/Shares/*'/>
        public IShares Shares => _shares;

        /// <include file = "SdkPublicDoc.xml" path='docs/members[@name="dracoonClient"]/Users/*'/>
        public IUsers Users => _users;

        public IGroups Groups => _groups;

        public IRoles Roles => _roles;

        public IEventLog EventLog => _eventLog;

        #endregion

        #endregion

        /// <include file = "SdkPublicDoc.xml" path='docs/members[@name="dracoonClient"]/DracoonClientConstructor/*'/>
        public DracoonClient(Uri serverUri, DracoonAuth auth = null, string encryptionPassword = null, ILog logger = null, DracoonHttpConfig httpConfig = null) {
            EncryptionPassword = encryptionPassword;
            InitInternal(serverUri, auth, logger, httpConfig);

            #region init public interfaces

            _account = new DracoonAccountImpl(this);
            _server = new DracoonServerImpl(this);
            _nodes = new DracoonNodesImpl(this);
            _shares = new DracoonSharesImpl(this);
            _users = new DracoonUsersImpl(this);
            _groups = new DracoonGroupsImpl(this);
            _roles = new DracoonRolesImpl(this);
            _eventLog = new DracoonEventLogImpl(this);

            #endregion
        }
    }
}
