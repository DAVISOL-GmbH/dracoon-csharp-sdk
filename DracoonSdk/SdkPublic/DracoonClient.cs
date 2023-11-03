using Dracoon.Sdk.SdkInternal;
using System;

namespace Dracoon.Sdk {
    /// <summary>
    ///     <para>
    ///         DracoonClient is the main class of the DRACOON SDK.It contains several handlers which group the functions of the SDK logically.
    ///     </para>
    ///     <list type = "bullet" >
    ///         <listheader>
    ///             <description>Following handlers are available:</description>
    ///         </listheader>
    ///         <item>
    ///             <term><see cref="Server"/>:</term>
    ///             <description><see cref="IServer"/></description>
    ///         </item>
    ///         <item>
    ///             <term><see cref="Account"/>:</term>
    ///             <description><see cref="IAccount"/></description>
    ///         </item>
    ///         <item>
    ///             <term><see cref="Nodes"/>:</term>
    ///             <description><see cref="INodes"/></description>
    ///         </item>
    ///         <item>
    ///             <term><see cref= "Shares"/>:</term>
    ///             <description><see cref="IShares"/></description>
    ///         </item>
    ///         <item>
    ///             <term><see cref= "Users"/>:</term>
    ///             <description><see cref="IUsers"/></description>
    ///         </item>
    ///         <item>
    ///             <term><see cref= "Groups"/>:</term>
    ///             <description><see cref="IGroups"/></description>
    ///         </item>
    ///         <item>
    ///             <term><see cref= "Roles"/>:</term>
    ///             <description><see cref="IRoles"/></description>
    ///         </item>
    ///         <item>
    ///             <term><see cref= "EventLog"/>:</term>
    ///             <description><see cref="IEventLog"/></description>
    ///         </item>
    ///     </list>
    /// </summary>
    public class DracoonClient : DracoonClientBase, IInternalDracoonClient, IInternalDracoonClientBase {

        #region Class-Members

        /// <summary>
        ///     The client's encryption password.
        /// </summary>
        public string EncryptionPassword { get; set; }

        #region Internal

        //private static DracoonHttpConfig _httpConfig;

        //internal static DracoonHttpConfig HttpConfig {
        //    get => _httpConfig ?? (_httpConfig = new DracoonHttpConfig());
        //    set => _httpConfig = value;
        //}


        //private static ILog _logger;

        //internal static ILog Log {
        //    get => _logger ?? (_logger = new EmptyLog());
        //    set => _logger = value;
        //}

        //private readonly IRequestBuilder _builder;

        //IRequestBuilder IInternalDracoonClientBase.Builder => _builder;

        //private readonly IRequestExecutor _executor;

        //IRequestExecutor IInternalDracoonClientBase.Executor => _executor;

        //IOAuth IInternalDracoonClientBase.OAuth => _oAuth;

        #endregion

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

        /// <summary>
        ///     Get Account handler. See also <seealso cref="IAccount"/>
        /// </summary>
        public IAccount Account => _account;

        /// <summary>
        ///     Get Server handler. See also <seealso cref="IServer"/>
        /// </summary>
        public IServer Server => _server;

        /// <summary>
        ///     Get Nodes handler. See also <seealso cref="INodes"/>
        /// </summary>
        public INodes Nodes => _nodes;

        /// <summary>
        ///     Get Shares handler. See also <seealso cref="IShares"/>
        /// </summary>
        public IShares Shares => _shares;

        /// <summary>
        ///     Get Users handler. See also <seealso cref="IUsers"/>
        /// </summary>
        public IUsers Users => _users;

        /// <summary>
        ///     Get Groups handler. See also <seealso cref="IGroups"/>
        /// </summary>
        public IGroups Groups => _groups;

        /// <summary>
        ///     Get Roles handler. See also <seealso cref="IRoles"/>
        /// </summary>
        public IRoles Roles => _roles;

        /// <summary>
        ///     Get ÊventLog handler. See also <seealso cref="IEventLog"/>
        /// </summary>
        public IEventLog EventLog => _eventLog;

        #endregion

        #endregion

        /// <summary>
        ///     Creates a new instance DRACOON client.
        /// </summary>
        /// <param name="serverUri">The used target server URI.</param>
        /// <param name="auth">The current authorization data. See also <seealso cref="DracoonAuth"/></param>
        /// <param name="encryptionPassword">The client's encryption password.</param>
        /// <param name="logger">The logger which should be used. See also <seealso cref="ILog"/></param>
        /// <param name="httpConfig">The self defined http configuration (otherwise the defaults of the DracoonHttpConfig is used). See also <seealso cref="DracoonHttpConfig"/></param>
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
