using Dracoon.Sdk.Filter;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.Sort;

namespace Dracoon.Sdk {
    public interface IGroups {

        GroupList GetGroups(long? offset = null, long? limit = null, GetGroupsFilter filter = null, GroupsSort sort = null);

        Group GetGroup(long groupId);

        NodeReferenceList GetGroupLastAdminRooms(long groupId);

        RoleList GetGroupRoles(long groupId);

        GroupUserList GetGroupUsers(long groupId, long? offset = null, long? limit = null, GetGroupUsersFilter filter = null);

        Group CreateGroup(CreateGroupRequest groupParams);

        Group AddGroupUsers(long groupId, ChangeGroupMembersRequest groupUserParams);

        Group UpdateGroup(long groupId, UpdateGroupRequest groupParams);

        void DeleteGroup(long groupId);

        void DeleteGroupUsers(long groupId, ChangeGroupMembersRequest deleteUsersParams);
    }
}
