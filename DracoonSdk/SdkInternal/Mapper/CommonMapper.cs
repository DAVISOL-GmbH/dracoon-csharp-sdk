using System;
using System.Collections.Generic;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.ApiModel.Requests;

namespace Dracoon.Sdk.SdkInternal.Mapper {
    internal static class CommonMapper {

        internal static NodeReferenceList FromApiNodeReferenceList(ApiNodeReferenceList apiNodeReferenceList, NodeType nodeType) {
            if (apiNodeReferenceList == null) {
                return null;
            }

            NodeReferenceList nodeReferenceList = new NodeReferenceList() {
                Items = new List<NodeReference>()
            };
            if (apiNodeReferenceList.Items != null) {
                foreach (ApiNodeReference apiNodeReference in apiNodeReferenceList.Items) {
                    nodeReferenceList.Items.Add(FromApiNodeReference(apiNodeReference, nodeType));
                }
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
            if (apiRoleList.Items != null) {
                foreach (ApiRole apiRole in apiRoleList.Items) {
                    roleList.Items.Add(FromApiRole(apiRole));
                }
            }
            return roleList;
        }

        internal static Role FromApiRole(ApiRole apiRole) {
            if (apiRole == null) {
                return null;
            }

            Role role = new Role() {
                Id = apiRole.Id,
                Name = apiRole.Name,
                Description = apiRole.Description,
                Rights = new List<Right>()
            };
            if (apiRole.Rights != null) {
                foreach (ApiRight apiRight in apiRole.Rights) {
                    role.Rights.Add(FromApiRight(apiRight));
                }
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


        internal static ApiExpiration ToApiExpiration(DateTime? expireAt) {
            ApiExpiration apiExpiration = null;
            if (expireAt.HasValue) {
                apiExpiration = new ApiExpiration() {
                    ExpireAt = expireAt,
                    EnableExpiration = expireAt.Value.Ticks != 0
                };
            }
            return apiExpiration;
        }

        internal static RangeListBase<T> FromApiRangeList<TApi, T>(ApiRangeListBase<TApi> apiRangeList, RangeListBase<T> newList, Func<TApi, T> convertFunc) {
            if (apiRangeList == null) {
                return null;
            }

            newList.Offset = apiRangeList.Range.Offset;
            newList.Limit = apiRangeList.Range.Limit;
            newList.Total = apiRangeList.Range.Total;
            FromApiSimpleList(apiRangeList, newList, convertFunc);
            return newList;
        }

        internal static SimpleListBase<T> FromApiSimpleList<TApi, T>(ApiSimpleListBase<TApi> apiSimpleList, SimpleListBase<T> newList, Func<TApi, T> convertFunc) {
            if (apiSimpleList == null) {
                return newList;
            }

            List<T> items = new List<T>();
            foreach (TApi currentItem in apiSimpleList.Items) {
                items.Add(convertFunc(currentItem));
            }
            newList.Items = items.ToArray();
            return newList;
        }

        internal static ApiSimpleListBase<TApi> ToApiSimpleList<T, TApi>(SimpleListBase<T> simpleList, ApiSimpleListBase<TApi> newList, Func<T, TApi> convertFunc) {
            if (simpleList == null) {
                return newList;
            }

            List<TApi> items = new List<TApi>();
            foreach (T currentItem in simpleList.Items) {
                items.Add(convertFunc(currentItem));
            }
            newList.Items = items.ToArray();
            return newList;
        }

        internal static ApiChangeMembersRequest ToApiChangeMembersRequest(ChangeMembersRequest changeGroupMembersRequest) {
            ApiChangeMembersRequest apiChangeGroupMembersRequest = new ApiChangeMembersRequest() {
                Ids = changeGroupMembersRequest.Ids
            };
            return apiChangeGroupMembersRequest;
        }
    }
}
