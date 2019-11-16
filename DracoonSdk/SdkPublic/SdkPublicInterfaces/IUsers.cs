using Dracoon.Sdk.Filter;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.Sort;

namespace Dracoon.Sdk {
    public interface IUsers {

        UserList GetUsers(bool? includeAttributes = null, long? offset = null, long? limit = null, GetUsersFilter filter = null, UsersSort sort = null);

        UserData GetUser(long userId, bool? effectiveRoles = null);

        UserGroupList GetUserGroups(long userId, long? offset = null, long? limit = null, GetUserGroupsFilter filter = null);

        LastAdminUserRoomList GetUserLastAdminRooms(long userId);

        RoleList GetUserRoles(long userId);

        AttributesResponse GetUserAttributes(long userId, long? offset = null, long? limit = null, GetUserAttributesFilter filter = null, UserAttributesSort sort = null);

        UserData CreateUser(CreateUserRequest groupParams);

        UserData OverwriteUserAttributes(long userId, UserAttributes userAttributes);

        UserData UpdateUser(long userId, UpdateUserRequest userParams);

        UserData UpdateUserAttributes(long userId, UserAttributes userParams);

        void DeleteUser(long userId);

        void DeleteUserAttribute(long userId, string userAttributeKey);
    }
}
