using Dracoon.Sdk.Filter;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.Sort;

namespace Dracoon.Sdk {
    /// <summary>
    ///     Handler to do actions on other users.
    /// </summary>
    public interface IUsers {
        /// <summary>
        ///     Get the avatar image of a given user.
        /// </summary>
        /// <param name="userId">The ID of the user for which the avatar should be returned.</param>
        /// <param name="avatarUuid">The corresponding uuid of the current avatar image for the given user.</param>
        /// <returns>The avatar image of the requested user.</returns>
        /// <exception cref="Dracoon.Sdk.Error.DracoonApiException"></exception>
        /// <exception cref="Dracoon.Sdk.Error.DracoonNetIOException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        byte[] GetUserAvatar(long userId, string avatarUuid);

        UserList GetUsers(bool? includeAttributes = null, bool? includeRoles = null, bool? includeHasManageableRooms = null, long? offset = null, long? limit = null, GetUsersFilter filter = null, UsersSort sort = null);

        UserData GetUser(long userId, bool? effectiveRoles = null);

        UserGroupList GetUserGroups(long userId, long? offset = null, long? limit = null, GetUserGroupsFilter filter = null);

        LastAdminUserRoomList GetUserLastAdminRooms(long userId);

        RoleList GetUserRoles(long userId);

        AttributesResponse GetUserAttributes(long userId, long? offset = null, long? limit = null, GetUserAttributesFilter filter = null, UserAttributesSort sort = null);

        UserData CreateUser(CreateUserRequest groupParams);

        // Deprecated since APIv4.28.0
        //UserData OverwriteUserAttributes(long userId, UserAttributes userAttributes);

        UserData UpdateUser(long userId, UpdateUserRequest userParams);

        void UpdateUserAttributes(long userId, UserAttributes userParams);

        void DeleteUser(long userId);

        void DeleteUserAttribute(long userId, string userAttributeKey);
    }
}
