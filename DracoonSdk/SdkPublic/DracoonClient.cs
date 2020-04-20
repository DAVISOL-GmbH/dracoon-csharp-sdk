using System;
using Dracoon.Sdk.SdkInternal;

namespace Dracoon.Sdk {
    /// <include file = "SdkPublicDoc.xml" path='docs/members[@name="dracoonClient"]/DracoonClient/*'/>
    public class DracoonClient : DracoonClientBase {

        #region Class-Members

        /// <include file = "SdkPublicDoc.xml" path='docs/members[@name="dracoonClient"]/EncryptionPassword/*'/>
        public string EncryptionPassword {
            get; set;
        }

        #region Public interfaces

        internal DracoonAccountImpl AccountImpl {
            get; private set;
        }

        internal DracoonNodesImpl NodesImpl {
            get; private set;
        }

        internal DracoonSharesImpl SharesImpl {
            get; private set;
        }

        internal DracoonGroupsImpl GroupsImpl {
            get; private set;
        }

        internal DracoonUsersImpl UsersImpl {
            get; private set;
        }

        internal DracoonEventLogImpl EventLogImpl {
            get; private set;
        }

        internal DracoonServerImpl ServerImpl {
            get; private set;
        }

        /// <include file = "SdkPublicDoc.xml" path='docs/members[@name="dracoonClient"]/Account/*'/>
        public IAccount Account {
            get {
                return AccountImpl;
            }
        }

        /// <include file = "SdkPublicDoc.xml" path='docs/members[@name="dracoonClient"]/Server/*'/>
        public IServer Server {
            get {
                return ServerImpl;
            }
        }

        /// <include file = "SdkPublicDoc.xml" path='docs/members[@name="dracoonClient"]/Nodes/*'/>
        public INodes Nodes {
            get {
                return NodesImpl;
            }
        }

        /// <include file = "SdkPublicDoc.xml" path='docs/members[@name="dracoonClient"]/Shares/*'/>
        public IShares Shares {
            get {
                return SharesImpl;
            }
        }

        public IGroups Groups {
            get {
                return GroupsImpl;
            }
        }

        public IUsers Users {
            get {
                return UsersImpl;
            }
        }

        public IEventLog EventLog {
            get {
                return EventLogImpl;
            }
        }

        #endregion

        #endregion

        /// <include file = "SdkPublicDoc.xml" path='docs/members[@name="dracoonClient"]/DracoonClientConstructor/*'/>
        public DracoonClient(Uri serverUri, DracoonAuth auth = null, string encryptionPassword = null, ILog logger = null, DracoonHttpConfig httpConfig = null) {
            EncryptionPassword = encryptionPassword;
            InitInternal(serverUri, auth, logger, httpConfig);

            #region init public interfaces

            AccountImpl = new DracoonAccountImpl(this);
            ServerImpl = new DracoonServerImpl(this);
            NodesImpl = new DracoonNodesImpl(this);
            SharesImpl = new DracoonSharesImpl(this);
            GroupsImpl = new DracoonGroupsImpl(this);
            UsersImpl = new DracoonUsersImpl(this);
            EventLogImpl = new DracoonEventLogImpl(this);

            #endregion
        }


    }
}
