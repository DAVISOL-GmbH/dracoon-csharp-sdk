using System.Drawing;
using Dracoon.Sdk.Filter;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.Sort;

namespace Dracoon.Sdk {
    /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iUsers"]/IUsers/*'/>
    public interface IUsers {

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iUsers"]/GetUserAvatar/*'/>
        Image GetUserAvatar(long userId, string avatarUUID);

        UserList GetUsers(bool? includeAttributes = null, bool? includeRoles = null, bool? includeHasManageableRooms = null, long? offset = null, long? limit = null, GetUsersFilter filter = null, UsersSort sort = null);

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
