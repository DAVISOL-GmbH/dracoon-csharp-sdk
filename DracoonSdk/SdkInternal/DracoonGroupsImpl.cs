using Dracoon.Sdk.Filter;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.ApiModel.Requests;
using Dracoon.Sdk.SdkInternal.Mapper;
using Dracoon.Sdk.SdkInternal.Validator;
using Dracoon.Sdk.Sort;
using RestSharp;

namespace Dracoon.Sdk.SdkInternal {
    internal class DracoonGroupsImpl : IGroups {

        internal static readonly string LOGTAG = typeof(DracoonGroupsImpl).Name;
        private DracoonClient client;

        internal DracoonGroupsImpl(DracoonClient client) {
            this.client = client;
        }

        #region Group services

        public GroupList GetGroups(long? offset = null, long? limit = null, GetGroupsFilter filter = null, GroupsSort sort = null) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            offset.MustNotNegative(nameof(offset));
            limit.MustPositive(nameof(limit));
            #endregion

            RestRequest restRequest = client.RequestBuilder.GetGroups(offset, limit, filter, sort);
            ApiGroupList result = client.RequestExecutor.DoSyncApiCall<ApiGroupList>(restRequest, DracoonRequestExecuter.RequestType.GetGroups);
            return GroupMapper.FromApiGroupList(result);
        }

        public Group GetGroup(long groupId) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            groupId.MustPositive(nameof(groupId));
            #endregion

            RestRequest restRequest = client.RequestBuilder.GetGroup(groupId);
            ApiGroup result = client.RequestExecutor.DoSyncApiCall<ApiGroup>(restRequest, DracoonRequestExecuter.RequestType.GetGroup);
            return GroupMapper.FromApiGroup(result);
        }

        public NodeReferenceList GetGroupLastAdminRooms(long groupId) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            groupId.MustPositive(nameof(groupId));
            #endregion

            RestRequest restRequest = client.RequestBuilder.GetGroupLastAdminRooms(groupId);
            ApiNodeReferenceList result = client.RequestExecutor.DoSyncApiCall<ApiNodeReferenceList>(restRequest, DracoonRequestExecuter.RequestType.GetGroupLastAdminRooms);
            return CommonMapper.FromApiNodeReferenceList(result, NodeType.Room);
        }

        public RoleList GetGroupRoles(long groupId) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            groupId.MustPositive(nameof(groupId));
            #endregion

            RestRequest restRequest = client.RequestBuilder.GetGroupRoles(groupId);
            ApiRoleList result = client.RequestExecutor.DoSyncApiCall<ApiRoleList>(restRequest, DracoonRequestExecuter.RequestType.GetGroupRoles);
            return CommonMapper.FromApiRoleList(result);
        }

        public GroupUserList GetGroupUsers(long groupId, long? offset = null, long? limit = null, GetUsersFilter filter = null) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            groupId.MustPositive(nameof(groupId));
            #endregion

            RestRequest restRequest = client.RequestBuilder.GetGroupUsers(groupId, offset, limit, filter);
            ApiGroupUserList result = client.RequestExecutor.DoSyncApiCall<ApiGroupUserList>(restRequest, DracoonRequestExecuter.RequestType.GetGroupUsers);
            return GroupMapper.FromApiGroupUserList(result);
        }

        public Group CreateGroup(CreateGroupRequest groupParams) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            groupParams.MustNotNull(nameof(groupParams));
            groupParams.Name.MustNotNullOrEmptyOrWhitespace(nameof(groupParams.Name), true);
            #endregion

            ApiCreateGroupRequest apiCreateGroupRequest = GroupMapper.ToApiCreateGroupRequest(groupParams);
            RestRequest restRequest = client.RequestBuilder.PostGroup(apiCreateGroupRequest);
            ApiGroup result = client.RequestExecutor.DoSyncApiCall<ApiGroup>(restRequest, DracoonRequestExecuter.RequestType.PostGroup);
            return GroupMapper.FromApiGroup(result);
        }

        public Group AddGroupUsers(long groupId, ChangeGroupMembersRequest groupUserParams) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            groupId.MustPositive(nameof(groupId));
            groupUserParams.MustNotNull(nameof(groupUserParams));
            #endregion

            ApiChangeGroupMembersRequest apiChangeGroupMembersRequest = GroupMapper.ToApiChangeGroupMembersRequest(groupUserParams);
            RestRequest restRequest = client.RequestBuilder.PostGroupUser(groupId, apiChangeGroupMembersRequest);
            ApiGroup result = client.RequestExecutor.DoSyncApiCall<ApiGroup>(restRequest, DracoonRequestExecuter.RequestType.PostGroupUsers);
            return GroupMapper.FromApiGroup(result);
        }

        public Group UpdateGroup(long groupId, UpdateGroupRequest groupParams) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            groupId.MustPositive(nameof(groupId));
            groupParams.MustNotNull(nameof(groupParams));
            groupParams.Name.MustNotNullOrEmptyOrWhitespace(nameof(groupParams.Name), true);
            #endregion

            ApiUpdateGroupRequest apiUpdateGroupRequest = GroupMapper.ToApiUpdateGroupRequest(groupParams);
            RestRequest restRequest = client.RequestBuilder.PutGroup(groupId, apiUpdateGroupRequest);
            ApiGroup result = client.RequestExecutor.DoSyncApiCall<ApiGroup>(restRequest, DracoonRequestExecuter.RequestType.PutGroup);
            return GroupMapper.FromApiGroup(result);
        }

        public void DeleteGroup(long groupId) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            groupId.MustPositive(nameof(groupId));
            #endregion

            RestRequest restRequest = client.RequestBuilder.DeleteGroup(groupId);
            client.RequestExecutor.DoSyncApiCall<VoidResponse>(restRequest, DracoonRequestExecuter.RequestType.DeleteGroup);
        }

        public void DeleteGroupUsers(long groupId, ChangeGroupMembersRequest deleteUsersParams) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            groupId.MustPositive(nameof(groupId));
            deleteUsersParams.MustNotNull(nameof(deleteUsersParams));
            #endregion

            ApiChangeGroupMembersRequest apiChangeGroupMembersRequest = GroupMapper.ToApiChangeGroupMembersRequest(deleteUsersParams);
            RestRequest restRequest = client.RequestBuilder.DeleteGroupUsers(groupId, apiChangeGroupMembersRequest);
            client.RequestExecutor.DoSyncApiCall<VoidResponse>(restRequest, DracoonRequestExecuter.RequestType.DeleteGroupUsers);
        }

        #endregion
    }
}
