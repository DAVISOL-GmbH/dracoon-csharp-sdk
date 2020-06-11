using Dracoon.Sdk.Filter;
using Dracoon.Sdk.Model;

namespace Dracoon.Sdk {
    public interface IRoles {

        RoleList GetRoles();

        RoleGroupList GetRoleGroups(long roleId, long? offset = null, long? limit = null, GetUserGroupsFilter filter = null);

        RoleUserList GetRoleUsers(long roleId, long? offset = null, long? limit = null, GetGroupUsersFilter filter = null);

        RoleGroupList AddRoleGroups(long roleId, ChangeMembersRequest addGroupsParams);

        RoleUserList AddRoleUsers(long roleId, ChangeMembersRequest addUsersParams);

        RoleGroupList DeleteRoleGroups(long roleId, ChangeMembersRequest deleteGroupsParams);

        RoleUserList DeleteRoleUsers(long roleId, ChangeMembersRequest deleteUsersParams);
    }
}
