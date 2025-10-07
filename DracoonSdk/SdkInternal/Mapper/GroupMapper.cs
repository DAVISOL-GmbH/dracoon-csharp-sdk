using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.ApiModel.Requests;
using System.Linq;

namespace Dracoon.Sdk.SdkInternal.Mapper {
    internal static class GroupMapper {

        internal static GroupList FromApiGroupList(ApiGroupList apiGroupList) {
            GroupList groupList = new GroupList();
            CommonMapper.FromApiRangeList(apiGroupList, groupList, FromApiGroup);
            return groupList;
        }

        internal static Group FromApiGroup(ApiGroup apiGroup) {
            if (apiGroup == null) {
                return null;
            }

            Group group = new Group() {
                Id = apiGroup.Id,
                Name = apiGroup.Name,
                CountUsers = apiGroup.CountUsers,
                ExpireAt = apiGroup.ExpireAt,
                CreatedAt = apiGroup.CreatedAt,
                CreatedBy = UserMapper.FromApiUserInfo(apiGroup.CreatedBy),
                UpdatedAt = apiGroup.UpdatedAt,
                UpdatedBy = UserMapper.FromApiUserInfo(apiGroup.UpdatedBy),
                GroupRoles = apiGroup.GroupRoles?.Items?.Select(x => CommonMapper.FromApiRole(x))?.ToArray()
            };
            return group;
        }

        internal static GroupInfo FromApiGroupInfo(ApiGroupInfo apiGroupInfo) {
            if (apiGroupInfo == null) {
                return null;
            }

            GroupInfo groupInfo = new GroupInfo() {
                Id = apiGroupInfo.Id,
                Name = apiGroupInfo.Name,
            };
            return groupInfo;
        }

        internal static GroupUserList FromApiGroupUserList(ApiGroupUserList apiGroupUserList) {
            GroupUserList groupUserList = new GroupUserList();
            CommonMapper.FromApiRangeList(apiGroupUserList, groupUserList, FromApiGroupUser);
            return groupUserList;
        }

        private static GroupUser FromApiGroupUser(ApiGroupUser apiGroupUser) {
            if (apiGroupUser == null) {
                return null;
            }

            GroupUser groupUser = new GroupUser() {
                UserInfo = UserMapper.FromApiUserInfo(apiGroupUser.UserInfo),
                IsMember = apiGroupUser.IsMember,
            };
            return groupUser;
        }



        internal static ApiCreateGroupRequest ToApiCreateGroupRequest(CreateGroupRequest createGroupRequest) {
            ApiExpiration apiExpiration = null;
            if (createGroupRequest.Expiration.HasValue) {
                apiExpiration = new ApiExpiration() {
                    ExpireAt = createGroupRequest.Expiration,
                    EnableExpiration = createGroupRequest.Expiration.Value.Ticks != 0
                };
            }

            ApiCreateGroupRequest apiCreateGroupRequest = new ApiCreateGroupRequest() {
                Name = createGroupRequest.Name,
                Expiration = apiExpiration
            };
            return apiCreateGroupRequest;
        }

        internal static ApiUpdateGroupRequest ToApiUpdateGroupRequest(UpdateGroupRequest updateGroupRequest) {
            ApiExpiration apiExpiration = null;
            if (updateGroupRequest.Expiration.HasValue) {
                apiExpiration = new ApiExpiration() {
                    ExpireAt = updateGroupRequest.Expiration,
                    EnableExpiration = updateGroupRequest.Expiration.Value.Ticks != 0
                };
            }

            ApiUpdateGroupRequest apiUpdateGroupRequest = new ApiUpdateGroupRequest() {
                Name = updateGroupRequest.Name,
                Expiration = apiExpiration
            };
            return apiUpdateGroupRequest;
        }
    }
}
