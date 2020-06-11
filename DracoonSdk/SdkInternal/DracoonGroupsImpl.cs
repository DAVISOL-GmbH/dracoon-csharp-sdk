using Dracoon.Sdk.Filter;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.ApiModel.Requests;
using Dracoon.Sdk.SdkInternal.Mapper;
using Dracoon.Sdk.SdkInternal.Validator;
using Dracoon.Sdk.Sort;
using RestSharp;
using static Dracoon.Sdk.SdkInternal.DracoonRequestExecutor;

namespace Dracoon.Sdk.SdkInternal {
    internal class DracoonGroupsImpl : IGroups {

        internal static readonly string Logtag = nameof(DracoonGroupsImpl);
        private readonly IInternalDracoonClient _client;

        internal DracoonGroupsImpl(IInternalDracoonClient client) {
            _client = client;
        }

        #region Group services

        public GroupList GetGroups(long? offset = null, long? limit = null, GetGroupsFilter filter = null, GroupsSort sort = null) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            offset.NullableMustNotNegative(nameof(offset));
            limit.NullableMustPositive(nameof(limit));
            #endregion

            IRestRequest restRequest = _client.Builder.GetGroups(offset, limit, filter, sort);
            ApiGroupList result = _client.Executor.DoSyncApiCall<ApiGroupList>(restRequest, RequestType.GetGroups);
            return GroupMapper.FromApiGroupList(result);
        }

        public Group GetGroup(long groupId) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            groupId.MustPositive(nameof(groupId));
            #endregion

            IRestRequest restRequest = _client.Builder.GetGroup(groupId);
            ApiGroup result = _client.Executor.DoSyncApiCall<ApiGroup>(restRequest, RequestType.GetGroup);
            return GroupMapper.FromApiGroup(result);
        }

        public NodeReferenceList GetGroupLastAdminRooms(long groupId) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            groupId.MustPositive(nameof(groupId));
            #endregion

            IRestRequest restRequest = _client.Builder.GetGroupLastAdminRooms(groupId);
            ApiNodeReferenceList result = _client.Executor.DoSyncApiCall<ApiNodeReferenceList>(restRequest, RequestType.GetGroupLastAdminRooms);
            return CommonMapper.FromApiNodeReferenceList(result, NodeType.Room);
        }

        public RoleList GetGroupRoles(long groupId) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            groupId.MustPositive(nameof(groupId));
            #endregion

            IRestRequest restRequest = _client.Builder.GetGroupRoles(groupId);
            ApiRoleList result = _client.Executor.DoSyncApiCall<ApiRoleList>(restRequest, RequestType.GetGroupRoles);
            return CommonMapper.FromApiRoleList(result);
        }

        public GroupUserList GetGroupUsers(long groupId, long? offset = null, long? limit = null, GetGroupUsersFilter filter = null) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            groupId.MustPositive(nameof(groupId));
            #endregion

            IRestRequest restRequest = _client.Builder.GetGroupUsers(groupId, offset, limit, filter);
            ApiGroupUserList result = _client.Executor.DoSyncApiCall<ApiGroupUserList>(restRequest, RequestType.GetGroupUsers);
            return GroupMapper.FromApiGroupUserList(result);
        }

        public Group CreateGroup(CreateGroupRequest groupParams) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            groupParams.MustNotNull(nameof(groupParams));
            groupParams.Name.MustNotNullOrEmptyOrWhitespace(nameof(groupParams.Name), true);
            #endregion

            ApiCreateGroupRequest apiCreateGroupRequest = GroupMapper.ToApiCreateGroupRequest(groupParams);
            IRestRequest restRequest = _client.Builder.PostGroup(apiCreateGroupRequest);
            ApiGroup result = _client.Executor.DoSyncApiCall<ApiGroup>(restRequest, RequestType.PostGroup);
            return GroupMapper.FromApiGroup(result);
        }

        public Group AddGroupUsers(long groupId, ChangeMembersRequest groupUserParams) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            groupId.MustPositive(nameof(groupId));
            groupUserParams.MustNotNull(nameof(groupUserParams));
            #endregion

            ApiChangeMembersRequest apiChangeGroupMembersRequest = CommonMapper.ToApiChangeMembersRequest(groupUserParams);
            IRestRequest restRequest = _client.Builder.PostGroupUser(groupId, apiChangeGroupMembersRequest);
            ApiGroup result = _client.Executor.DoSyncApiCall<ApiGroup>(restRequest, RequestType.PostGroupUsers);
            return GroupMapper.FromApiGroup(result);
        }

        public Group UpdateGroup(long groupId, UpdateGroupRequest groupParams) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            groupId.MustPositive(nameof(groupId));
            groupParams.MustNotNull(nameof(groupParams));
            groupParams.Name.MustNotNullOrEmptyOrWhitespace(nameof(groupParams.Name), true);
            #endregion

            ApiUpdateGroupRequest apiUpdateGroupRequest = GroupMapper.ToApiUpdateGroupRequest(groupParams);
            IRestRequest restRequest = _client.Builder.PutGroup(groupId, apiUpdateGroupRequest);
            ApiGroup result = _client.Executor.DoSyncApiCall<ApiGroup>(restRequest, RequestType.PutGroup);
            return GroupMapper.FromApiGroup(result);
        }

        public void DeleteGroup(long groupId) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            groupId.MustPositive(nameof(groupId));
            #endregion

            IRestRequest restRequest = _client.Builder.DeleteGroup(groupId);
            _client.Executor.DoSyncApiCall<VoidResponse>(restRequest, RequestType.DeleteGroup);
        }

        public void DeleteGroupUsers(long groupId, ChangeMembersRequest deleteUsersParams) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            groupId.MustPositive(nameof(groupId));
            deleteUsersParams.MustNotNull(nameof(deleteUsersParams));
            #endregion

            ApiChangeMembersRequest apiChangeGroupMembersRequest = CommonMapper.ToApiChangeMembersRequest(deleteUsersParams);
            IRestRequest restRequest = _client.Builder.DeleteGroupUsers(groupId, apiChangeGroupMembersRequest);
            _client.Executor.DoSyncApiCall<VoidResponse>(restRequest, RequestType.DeleteGroupUsers);
        }

        #endregion
    }
}
