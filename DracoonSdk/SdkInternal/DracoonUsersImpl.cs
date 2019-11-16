using Dracoon.Sdk.Filter;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.ApiModel.Requests;
using Dracoon.Sdk.SdkInternal.Mapper;
using Dracoon.Sdk.SdkInternal.Validator;
using Dracoon.Sdk.Sort;
using RestSharp;

namespace Dracoon.Sdk.SdkInternal {
    internal class DracoonUsersImpl : IUsers {

        internal static readonly string LOGTAG = typeof(DracoonUsersImpl).Name;
        private DracoonClient client;

        internal DracoonUsersImpl(DracoonClient client) {
            this.client = client;
        }

        #region User services

        public UserList GetUsers(bool? includeAttributes = null, long? offset = null, long? limit = null, GetUsersFilter filter = null, UsersSort sort = null) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            offset.MustNotNegative(nameof(offset));
            limit.MustPositive(nameof(limit));
            #endregion

            RestRequest restRequest = client.RequestBuilder.GetUsers(includeAttributes, offset, limit, filter, sort);
            ApiUserList result = client.RequestExecutor.DoSyncApiCall<ApiUserList>(restRequest, DracoonRequestExecuter.RequestType.GetUsers);
            return UserMapper.FromApiUserList(result);
        }

        public UserData GetUser(long userId, bool? effectiveRoles = null) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            #endregion

            RestRequest restRequest = client.RequestBuilder.GetUser(userId);
            ApiUserData result = client.RequestExecutor.DoSyncApiCall<ApiUserData>(restRequest, DracoonRequestExecuter.RequestType.GetUser);
            return UserMapper.FromApiUserData(result);
        }

        public UserGroupList GetUserGroups(long userId, long? offset = null, long? limit = null, GetUserGroupsFilter filter = null) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            offset.MustNotNegative(nameof(offset));
            limit.MustPositive(nameof(limit));
            #endregion

            RestRequest restRequest = client.RequestBuilder.GetUserGroups(userId, offset, limit, filter);
            ApiUserGroupList result = client.RequestExecutor.DoSyncApiCall<ApiUserGroupList>(restRequest, DracoonRequestExecuter.RequestType.GetUserGroups);
            return UserMapper.FromApiUserGroupList(result);
        }

        public LastAdminUserRoomList GetUserLastAdminRooms(long userId) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            #endregion

            RestRequest restRequest = client.RequestBuilder.GetUserLastAdminRooms(userId);
            ApiLastAdminUserRoomList result = client.RequestExecutor.DoSyncApiCall<ApiLastAdminUserRoomList>(restRequest, DracoonRequestExecuter.RequestType.GetUserLastAdminRooms);
            return UserMapper.FromApiLastAdminUserRoomList(result);
        }

        public RoleList GetUserRoles(long userId) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            #endregion

            RestRequest restRequest = client.RequestBuilder.GetUserRoles(userId);
            ApiRoleList result = client.RequestExecutor.DoSyncApiCall<ApiRoleList>(restRequest, DracoonRequestExecuter.RequestType.GetUserRoles);
            return CommonMapper.FromApiRoleList(result);
        }

        public AttributesResponse GetUserAttributes(long userId, long? offset = null, long? limit = null, GetUserAttributesFilter filter = null, UserAttributesSort sort = null) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            offset.MustNotNegative(nameof(offset));
            limit.MustPositive(nameof(limit));
            #endregion

            RestRequest restRequest = client.RequestBuilder.GetUserUserAttributes(userId, offset, limit, filter, sort);
            ApiAttributesResponse result = client.RequestExecutor.DoSyncApiCall<ApiAttributesResponse>(restRequest, DracoonRequestExecuter.RequestType.GetUserUserAttributes);
            return UserMapper.FromApiAttributesResponse(result);
        }

        public UserData CreateUser(CreateUserRequest userParams) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            userParams.MustNotNull(nameof(userParams));
            userParams.UserName.MustNotNullOrEmptyOrWhitespace(nameof(userParams.UserName));
            userParams.FirstName.MustNotNullOrEmptyOrWhitespace(nameof(userParams.FirstName));
            userParams.LastName.MustNotNullOrEmptyOrWhitespace(nameof(userParams.LastName));
            #endregion

            ApiCreateUserRequest apiCreateUserRequest = UserMapper.ToApiCreateUserRequest(userParams);
            RestRequest restRequest = client.RequestBuilder.PostUser(apiCreateUserRequest);
            ApiUserData result = client.RequestExecutor.DoSyncApiCall<ApiUserData>(restRequest, DracoonRequestExecuter.RequestType.PostUser);
            return UserMapper.FromApiUserData(result);
        }

        public UserData OverwriteUserAttributes(long userId, UserAttributes userAttributeParams) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            userAttributeParams.MustNotNull(nameof(userAttributeParams));
            #endregion

            ApiUserAttributes apiUserAttributes = UserMapper.ToApiUserAttributes(userAttributeParams);
            RestRequest restRequest = client.RequestBuilder.PostUserUserAttributes(userId, apiUserAttributes);
            ApiUserData result = client.RequestExecutor.DoSyncApiCall<ApiUserData>(restRequest, DracoonRequestExecuter.RequestType.PostUserUserAttributes);
            return UserMapper.FromApiUserData(result);
        }

        public UserData UpdateUser(long userId, UpdateUserRequest userParams) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            NewMethod(userParams);
            userParams.UserName.MustNotNullOrEmptyOrWhitespace(nameof(userParams.UserName), true);
            userParams.FirstName.MustNotNullOrEmptyOrWhitespace(nameof(userParams.UserName), true);
            userParams.LastName.MustNotNullOrEmptyOrWhitespace(nameof(userParams.UserName), true);
            #endregion

            ApiUpdateUserRequest apiUpdateUserRequest = UserMapper.ToApiUpdateUserRequest(userParams);
            RestRequest restRequest = client.RequestBuilder.PutUser(userId, apiUpdateUserRequest);
            ApiUserData result = client.RequestExecutor.DoSyncApiCall<ApiUserData>(restRequest, DracoonRequestExecuter.RequestType.PutUser);
            return UserMapper.FromApiUserData(result);
        }

        private static void NewMethod(UpdateUserRequest userParams) {
            userParams.MustNotNull(nameof(userParams));
        }

        public UserData UpdateUserAttributes(long userId, UserAttributes userAttributeParams) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            userAttributeParams.MustNotNull(nameof(userAttributeParams));
            #endregion

            ApiUserAttributes apiUserAttributes = UserMapper.ToApiUserAttributes(userAttributeParams);
            RestRequest restRequest = client.RequestBuilder.PutUserUserAttributes(userId, apiUserAttributes);
            ApiUserData result = client.RequestExecutor.DoSyncApiCall<ApiUserData>(restRequest, DracoonRequestExecuter.RequestType.PutUserUserAttributes);
            return UserMapper.FromApiUserData(result);
        }

        public void DeleteUser(long userId) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            #endregion

            RestRequest restRequest = client.RequestBuilder.DeleteUser(userId);
            client.RequestExecutor.DoSyncApiCall<VoidResponse>(restRequest, DracoonRequestExecuter.RequestType.DeleteUser);
        }

        public void DeleteUserAttribute(long userId, string userAttributeKey) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            userAttributeKey.MustNotNullOrEmptyOrWhitespace(nameof(userAttributeKey));
            #endregion

            RestRequest restRequest = client.RequestBuilder.DeleteUserUserAttribute(userId, userAttributeKey);
            client.RequestExecutor.DoSyncApiCall<VoidResponse>(restRequest, DracoonRequestExecuter.RequestType.DeleteUserUserAttribute);
        }

        #endregion
    }
}
