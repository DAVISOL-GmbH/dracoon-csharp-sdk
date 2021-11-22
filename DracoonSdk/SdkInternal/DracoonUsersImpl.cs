using Dracoon.Sdk.Filter;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.ApiModel.Requests;
using Dracoon.Sdk.SdkInternal.Mapper;
using Dracoon.Sdk.SdkInternal.Validator;
using Dracoon.Sdk.Sort;
using RestSharp;
using System;
using System.Net;
using static Dracoon.Sdk.SdkInternal.DracoonRequestExecutor;

namespace Dracoon.Sdk.SdkInternal {
    internal class DracoonUsersImpl : IUsers {

        internal const string Logtag = nameof(DracoonUsersImpl);
        private readonly IInternalDracoonClient _client;

        internal DracoonUsersImpl(IInternalDracoonClient client) {
            _client = client;
        }

        public SkiaSharp.SKData GetUserAvatar(long userId, string avatarUuid) {
            _client.Executor.CheckApiServerVersion();

            #region Parameter Validation

            userId.MustPositive(nameof(userId));
            avatarUuid.MustNotNullOrEmptyOrWhitespace(nameof(avatarUuid));

            #endregion

            IRestRequest request = _client.Builder.GetUserAvatar(userId, avatarUuid);
            ApiAvatarInfo apiAvatarInfo = _client.Executor.DoSyncApiCall<ApiAvatarInfo>(request, RequestType.GetResourcesAvatar);

            using (WebClient avatarClient = _client.Builder.ProvideAvatarDownloadWebClient()) {
                byte[] avatarImageBytes =
                    _client.Executor.ExecuteWebClientDownload(avatarClient, new Uri(apiAvatarInfo.AvatarUri), RequestType.GetResourcesAvatar);
                return SkiaSharp.SKData.CreateCopy(avatarImageBytes);
            }
        }


        #region User services

        public UserList GetUsers(bool? includeAttributes = null, bool? includeRoles = null, bool? includeHasManageableRooms = null, long? offset = null, long? limit = null, GetUsersFilter filter = null, UsersSort sort = null) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            offset.NullableMustNotNegative(nameof(offset));
            limit.NullableMustPositive(nameof(limit));
            #endregion

            IRestRequest restRequest = _client.Builder.GetUsers(includeAttributes, includeRoles, includeHasManageableRooms, offset, limit, filter, sort);
            ApiUserList result = _client.Executor.DoSyncApiCall<ApiUserList>(restRequest, RequestType.GetUsers);
            return UserMapper.FromApiUserList(result);
        }

        public UserData GetUser(long userId, bool? effectiveRoles = null) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            #endregion

            IRestRequest restRequest = _client.Builder.GetUser(userId, effectiveRoles);
            ApiUserData result = _client.Executor.DoSyncApiCall<ApiUserData>(restRequest, RequestType.GetUser);
            return UserMapper.FromApiUserData(result);
        }

        public UserGroupList GetUserGroups(long userId, long? offset = null, long? limit = null, GetUserGroupsFilter filter = null) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            offset.NullableMustNotNegative(nameof(offset));
            limit.NullableMustPositive(nameof(limit));
            #endregion

            IRestRequest restRequest = _client.Builder.GetUserGroups(userId, offset, limit, filter);
            ApiUserGroupList result = _client.Executor.DoSyncApiCall<ApiUserGroupList>(restRequest, RequestType.GetUserGroups);
            return UserMapper.FromApiUserGroupList(result);
        }

        public LastAdminUserRoomList GetUserLastAdminRooms(long userId) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            #endregion

            IRestRequest restRequest = _client.Builder.GetUserLastAdminRooms(userId);
            ApiLastAdminUserRoomList result = _client.Executor.DoSyncApiCall<ApiLastAdminUserRoomList>(restRequest, RequestType.GetUserLastAdminRooms);
            return UserMapper.FromApiLastAdminUserRoomList(result);
        }

        public RoleList GetUserRoles(long userId) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            #endregion

            IRestRequest restRequest = _client.Builder.GetUserRoles(userId);
            ApiRoleList result = _client.Executor.DoSyncApiCall<ApiRoleList>(restRequest, RequestType.GetUserRoles);
            return CommonMapper.FromApiRoleList(result);
        }

        public AttributesResponse GetUserAttributes(long userId, long? offset = null, long? limit = null, GetUserAttributesFilter filter = null, UserAttributesSort sort = null) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            offset.NullableMustNotNegative(nameof(offset));
            limit.NullableMustPositive(nameof(limit));
            #endregion

            IRestRequest restRequest = _client.Builder.GetUserUserAttributes(userId, offset, limit, filter, sort);
            ApiAttributesResponse result = _client.Executor.DoSyncApiCall<ApiAttributesResponse>(restRequest, RequestType.GetUserUserAttributes);
            return UserMapper.FromApiAttributesResponse(result);
        }

        public UserData CreateUser(CreateUserRequest userParams) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            userParams.MustNotNull(nameof(userParams));
            //userParams.UserName.MustNotNullOrEmptyOrWhitespace(nameof(userParams.UserName));
            userParams.FirstName.MustNotNullOrEmptyOrWhitespace(nameof(userParams.FirstName));
            userParams.LastName.MustNotNullOrEmptyOrWhitespace(nameof(userParams.LastName));
            #endregion

            ApiCreateUserRequest apiCreateUserRequest = UserMapper.ToApiCreateUserRequest(userParams);
            IRestRequest restRequest = _client.Builder.PostUser(apiCreateUserRequest);
            ApiUserData result = _client.Executor.DoSyncApiCall<ApiUserData>(restRequest, RequestType.PostUser);
            return UserMapper.FromApiUserData(result);
        }

        public UserData OverwriteUserAttributes(long userId, UserAttributes userAttributeParams) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            userAttributeParams.MustNotNull(nameof(userAttributeParams));
            #endregion

            ApiUserAttributes apiUserAttributes = UserMapper.ToApiUserAttributes(userAttributeParams);
            IRestRequest restRequest = _client.Builder.PostUserUserAttributes(userId, apiUserAttributes);
            ApiUserData result = _client.Executor.DoSyncApiCall<ApiUserData>(restRequest, RequestType.PostUserUserAttributes);
            return UserMapper.FromApiUserData(result);
        }

        public UserData UpdateUser(long userId, UpdateUserRequest userParams) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            userParams.MustNotNull(nameof(userParams));
            userParams.UserName.MustNotNullOrEmptyOrWhitespace(nameof(userParams.UserName), true);
            userParams.FirstName.MustNotNullOrEmptyOrWhitespace(nameof(userParams.UserName), true);
            userParams.LastName.MustNotNullOrEmptyOrWhitespace(nameof(userParams.UserName), true);
            #endregion

            ApiUpdateUserRequest apiUpdateUserRequest = UserMapper.ToApiUpdateUserRequest(userParams);
            IRestRequest restRequest = _client.Builder.PutUser(userId, apiUpdateUserRequest);
            ApiUserData result = _client.Executor.DoSyncApiCall<ApiUserData>(restRequest, RequestType.PutUser);
            return UserMapper.FromApiUserData(result);
        }

        public UserData UpdateUserAttributes(long userId, UserAttributes userAttributeParams) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            userAttributeParams.MustNotNull(nameof(userAttributeParams));
            #endregion

            ApiUserAttributes apiUserAttributes = UserMapper.ToApiUserAttributes(userAttributeParams);
            IRestRequest restRequest = _client.Builder.PutUserUserAttributes(userId, apiUserAttributes);
            ApiUserData result = _client.Executor.DoSyncApiCall<ApiUserData>(restRequest, RequestType.PutUserUserAttributes);
            return UserMapper.FromApiUserData(result);
        }

        public void DeleteUser(long userId) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            #endregion

            IRestRequest restRequest = _client.Builder.DeleteUser(userId);
            _client.Executor.DoSyncApiCall<VoidResponse>(restRequest, RequestType.DeleteUser);
        }

        public void DeleteUserAttribute(long userId, string userAttributeKey) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            userAttributeKey.MustNotNullOrEmptyOrWhitespace(nameof(userAttributeKey));
            #endregion

            IRestRequest restRequest = _client.Builder.DeleteUserUserAttribute(userId, userAttributeKey);
            _client.Executor.DoSyncApiCall<VoidResponse>(restRequest, RequestType.DeleteUserUserAttribute);
        }

        #endregion
    }
}
