using Dracoon.Sdk.Filter;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.ApiModel.Requests;
using Dracoon.Sdk.SdkInternal.Mapper;
using Dracoon.Sdk.SdkInternal.Validator;
using RestSharp;
using static Dracoon.Sdk.SdkInternal.DracoonRequestExecutor;

namespace Dracoon.Sdk.SdkInternal {
    internal class DracoonRolesImpl : IRoles {

        internal static readonly string Logtag = nameof(DracoonRolesImpl);
        private readonly IInternalDracoonClient _client;

        internal DracoonRolesImpl(IInternalDracoonClient client) {
            _client = client;
        }

        #region Role services

        public RoleList GetRoles() {
            _client.Executor.CheckApiServerVersion();

            RestRequest restRequest = _client.Builder.GetRoles();
            ApiRoleList result = _client.Executor.DoSyncApiCall<ApiRoleList>(restRequest, RequestType.GetRoles);
            return CommonMapper.FromApiRoleList(result);
        }

        public RoleGroupList GetRoleGroups(long roleId, long? offset = null, long? limit = null, GetUserGroupsFilter filter = null) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            roleId.MustPositive(nameof(roleId));
            #endregion

            RestRequest restRequest = _client.Builder.GetRoleGroups(roleId, offset, limit, filter);
            ApiRoleGroupList result = _client.Executor.DoSyncApiCall<ApiRoleGroupList>(restRequest, RequestType.GetRoleGroups);
            return RoleMapper.FromApiRoleGroupList(result);
        }

        public RoleUserList GetRoleUsers(long roleId, long? offset = null, long? limit = null, GetGroupUsersFilter filter = null) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            roleId.MustPositive(nameof(roleId));
            #endregion

            RestRequest restRequest = _client.Builder.GetRoleUsers(roleId, offset, limit, filter);
            ApiRoleUserList result = _client.Executor.DoSyncApiCall<ApiRoleUserList>(restRequest, RequestType.GetRoleUsers);
            return RoleMapper.FromApiRoleUserList(result);
        }

        public RoleGroupList AddRoleGroups(long roleId, ChangeMembersRequest addGroupsParams) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            roleId.MustPositive(nameof(roleId));
            addGroupsParams.MustNotNull(nameof(addGroupsParams));
            #endregion

            ApiChangeMembersRequest apiChangeMembersRequest = CommonMapper.ToApiChangeMembersRequest(addGroupsParams);
            RestRequest restRequest = _client.Builder.PostRoleGroups(roleId, apiChangeMembersRequest);
            ApiRoleGroupList result = _client.Executor.DoSyncApiCall<ApiRoleGroupList>(restRequest, RequestType.PostRoleGroups);
            return RoleMapper.FromApiRoleGroupList(result);
        }

        public RoleUserList AddRoleUsers(long roleId, ChangeMembersRequest addUsersParams) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            roleId.MustPositive(nameof(roleId));
            addUsersParams.MustNotNull(nameof(addUsersParams));
            #endregion

            ApiChangeMembersRequest apiChangeMembersRequest = CommonMapper.ToApiChangeMembersRequest(addUsersParams);
            RestRequest restRequest = _client.Builder.PostRoleUsers(roleId, apiChangeMembersRequest);
            ApiRoleUserList result = _client.Executor.DoSyncApiCall<ApiRoleUserList>(restRequest, RequestType.PostRoleUsers);
            return RoleMapper.FromApiRoleUserList(result);
        }

        public RoleGroupList DeleteRoleGroups(long roleId, ChangeMembersRequest deleteGroupsParams) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            roleId.MustPositive(nameof(roleId));
            deleteGroupsParams.MustNotNull(nameof(deleteGroupsParams));
            #endregion

            ApiChangeMembersRequest apiChangeMembersRequest = CommonMapper.ToApiChangeMembersRequest(deleteGroupsParams);
            RestRequest restRequest = _client.Builder.DeleteRoleGroups(roleId, apiChangeMembersRequest);
            ApiRoleGroupList result = _client.Executor.DoSyncApiCall<ApiRoleGroupList>(restRequest, RequestType.DeleteRoleGroups);
            return RoleMapper.FromApiRoleGroupList(result);
        }

        public RoleUserList DeleteRoleUsers(long roleId, ChangeMembersRequest deleteUsersParams) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            roleId.MustPositive(nameof(roleId));
            deleteUsersParams.MustNotNull(nameof(deleteUsersParams));
            #endregion

            ApiChangeMembersRequest apiChangeMembersRequest = CommonMapper.ToApiChangeMembersRequest(deleteUsersParams);
            RestRequest restRequest = _client.Builder.DeleteRoleUsers(roleId, apiChangeMembersRequest);
            ApiRoleUserList result = _client.Executor.DoSyncApiCall<ApiRoleUserList>(restRequest, RequestType.DeleteRoleUsers);
            return RoleMapper.FromApiRoleUserList(result);
        }

        #endregion
    }
}
