using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;

namespace Dracoon.Sdk.SdkInternal.Mapper {
    internal static class RoleMapper {

        internal static RoleList FromApiRoleList(ApiRoleList apiRoleList) {
            return CommonMapper.FromApiRoleList(apiRoleList);
        }


        internal static RoleUserList FromApiRoleUserList(ApiRoleUserList apiRoleUserList) {
            RoleUserList roleUserList = new RoleUserList();
            CommonMapper.FromApiRangeList(apiRoleUserList, roleUserList, FromApiRoleUser);
            return roleUserList;
        }

        internal static RoleUser FromApiRoleUser(ApiRoleUser apiRoleUser) {
            if (apiRoleUser == null) {
                return null;
            }

            RoleUser roleUser = new RoleUser() {
                UserInfo = UserMapper.FromApiUserInfo(apiRoleUser.UserInfo),
                IsMember = apiRoleUser.IsMember
            };
            return roleUser;
        }

        internal static RoleGroupList FromApiRoleGroupList(ApiRoleGroupList apiRoleGroupList) {
            RoleGroupList roleGroupList = new RoleGroupList();
            CommonMapper.FromApiRangeList(apiRoleGroupList, roleGroupList, FromApiRoleGroup);
            return roleGroupList;
        }

        private static RoleGroup FromApiRoleGroup(ApiRoleGroup apiRoleGroup) {
            if (apiRoleGroup == null) {
                return null;
            }

            RoleGroup roleGroup = new RoleGroup() {
                Id = apiRoleGroup.Id,
                IsMember = apiRoleGroup.IsMember,
                Name = apiRoleGroup.Name
            };
            return roleGroup;
        }
    }
}
