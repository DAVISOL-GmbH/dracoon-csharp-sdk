using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;

namespace Dracoon.Sdk.SdkInternal.Mapper {
    internal static class CommonMapper {

        internal static NodeReferenceList FromApiNodeReferenceList(ApiNodeReferenceList apiNodeReferenceList, NodeType nodeType) {
            if (apiNodeReferenceList == null) {
                return null;
            }

            NodeReferenceList nodeReferenceList = new NodeReferenceList() {
                Items = new List<NodeReference>()
            };
            foreach (ApiNodeReference apiNodeReference in apiNodeReferenceList.Items) {
                nodeReferenceList.Items.Add(FromApiNodeReference(apiNodeReference, nodeType));
            }
            return nodeReferenceList;
        }

        private static NodeReference FromApiNodeReference(ApiNodeReference apiNodeReference, NodeType nodeType) {
            if (apiNodeReference == null) {
                return null;
            }

            NodeReference nodeReference = new NodeReference() {
                Id = apiNodeReference.Id,
                Name = apiNodeReference.Name,
                ParentId = apiNodeReference.ParentId,
                ParentPath = apiNodeReference.ParentPath,
                Type = nodeType
            };
            return nodeReference;
        }

        internal static RoleList FromApiRoleList(ApiRoleList apiRoleList) {
            if (apiRoleList == null) {
                return null;
            }

            RoleList roleList = new RoleList() {
                Items = new List<Role>()
            };
            foreach (ApiRole apiRole in apiRoleList.Items) {
                roleList.Items.Add(FromApiRole(apiRole));
            }
            return roleList;
        }

        private static Role FromApiRole(ApiRole apiRole) {
            if (apiRole == null) {
                return null;
            }

            Role role = new Role() {
                Id = apiRole.Id,
                Name = apiRole.Name,
                Description = apiRole.Description,
                Rights = new List<Right>()
            };
            foreach (ApiRight apiRight in apiRole.Rights) {
                role.Rights.Add(FromApiRight(apiRight));
            }
            return role;
        }

        private static Right FromApiRight(ApiRight apiRight) {
            if (apiRight == null) {
                return null;
            }

            Right right = new Right() {
                Id = apiRight.Id,
                Name = apiRight.Name,
                Description = apiRight.Description
            };
            return right;
        }

    }
}
