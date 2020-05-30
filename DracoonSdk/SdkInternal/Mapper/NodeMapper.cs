using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.ApiModel.Requests;
using Dracoon.Sdk.SdkInternal.Util;
using System;
using System.Collections.Generic;

namespace Dracoon.Sdk.SdkInternal.Mapper {
    internal static class NodeMapper {
        internal static NodeList FromApiNodeList(ApiNodeList apiNodeList) {
            if (apiNodeList == null) {
                return null;
            }

            var items = new List<Node>();
            foreach (ApiNode currentNode in apiNodeList.Items) {
                items.Add(FromApiNode(currentNode));
            }
            NodeList nodeList = new NodeList() {
                Offset = apiNodeList.Range.Offset,
                Limit = apiNodeList.Range.Limit,
                Total = apiNodeList.Range.Total,
                Items = items.ToArray(),
            };
            return nodeList;
        }

        internal static Node FromApiNode(ApiNode apiNode) {
            if (apiNode == null) {
                return null;
            }

            Node node = new Node {
                Id = apiNode.Id,
                Type = EnumConverter.ConvertValueToNodeTypeEnum(apiNode.Type),
                ParentId = apiNode.ParentId,
                ParentPath = apiNode.ParentPath,
                Name = apiNode.Name,
                Extension = apiNode.FileType,
                MediaType = apiNode.MediaType,
                MediaToken = apiNode.MediaToken,
                Size = apiNode.Size,
                Quota = apiNode.Quota,
                Classification = EnumConverter.ConvertValueToClassificationEnum(apiNode.Classification),
                Notes = apiNode.Notes,
                Hash = apiNode.Hash,
                ExpireAt = apiNode.ExpireAt,
                CreatedAt = apiNode.CreatedAt,
                CreatedBy = UserMapper.FromApiUserInfo(apiNode.CreatedBy),
                UpdatedAt = apiNode.UpdatedAt,
                UpdatedBy = UserMapper.FromApiUserInfo(apiNode.UpdatedBy),
                HasInheritPermissions = apiNode.InheritPermissions,
                Permissions = FromApiNodePermissions(apiNode.Permissions),
                IsFavorite = apiNode.IsFavorite,
                IsEncrypted = apiNode.IsEncrypted,
                CountChildren = apiNode.CountChildren,
                CountRooms = apiNode.CountRooms,
                CountFolders = apiNode.CountFolders,
                CountFiles = apiNode.CountFiles,
                CountDeletedVersions = apiNode.CountDeletedVersions,
                RecycleBinRetentionPeriod = apiNode.RecycleBinRetentionPeriod,
                CountDownloadShares = apiNode.CountDownloadShares,
                CountUploadShares = apiNode.CountUploadShares,
                BranchVersion = apiNode.BranchVersion
            };
            return node;
        }

        internal static NodePermissions FromApiNodePermissions(ApiNodePermissions apiNodePermissions) {
            if (apiNodePermissions == null) {
                return null;
            }

            NodePermissions nodePermissions = new NodePermissions {
                Manage = apiNodePermissions.Manage,
                Read = apiNodePermissions.Read,
                Create = apiNodePermissions.Create,
                Change = apiNodePermissions.Change,
                Delete = apiNodePermissions.Delete,
                ManageDownloadShare = apiNodePermissions.ManageDownloadShare,
                ManageUploadShare = apiNodePermissions.ManageUploadShare,
                CanReadRecycleBin = apiNodePermissions.ReadRecycleBin,
                CanRestoreRecycleBin = apiNodePermissions.RestoreRecycleBin,
                CanDeleteRecycleBin = apiNodePermissions.DeleteRecycleBin
            };
            return nodePermissions;
        }

        internal static ApiDeleteNodesRequest ToApiDeleteNodesRequest(DeleteNodesRequest request) {
            ApiDeleteNodesRequest apiDeleteNodesRequest = new ApiDeleteNodesRequest {
                NodeIds = request.Ids
            };
            return apiDeleteNodesRequest;
        }

        internal static ApiCopyNodesRequest ToApiCopyNodesRequest(CopyNodesRequest request) {
            List<ApiCopyNode> copyNodeList = new List<ApiCopyNode>();
            foreach (CopyNode currentCopyNode in request.NodesToBeCopied) {
                ApiCopyNode apiCopyNode = new ApiCopyNode {
                    NodeId = currentCopyNode.NodeId,
                    NewName = currentCopyNode.NewName
                };
                copyNodeList.Add(apiCopyNode);
            }

            ApiCopyNodesRequest apiCopyNodesRequest = new ApiCopyNodesRequest {
                Nodes = copyNodeList,
                ResolutionStrategy = EnumConverter.ConvertResolutionStrategyToValue(request.ResolutionStrategy),
                KeepShareLinks = request.KeepShareLinks
            };
            return apiCopyNodesRequest;
        }

        internal static ApiMoveNodesRequest ToApiMoveNodesRequest(MoveNodesRequest request) {
            List<ApiMoveNode> moveNodesList = new List<ApiMoveNode>();
            foreach (MoveNode currentMoveNode in request.NodesToBeMoved) {
                ApiMoveNode apiMoveNode = new ApiMoveNode {
                    NodeId = currentMoveNode.NodeId,
                    NewName = currentMoveNode.NewName
                };
                moveNodesList.Add(apiMoveNode);
            }

            ApiMoveNodesRequest apiMoveNodesRequest = new ApiMoveNodesRequest {
                Nodes = moveNodesList,
                ResolutionStrategy = EnumConverter.ConvertResolutionStrategyToValue(request.ResolutionStrategy),
                KeepShareLinks = request.KeepShareLinks
            };
            return apiMoveNodesRequest;
        }

        internal static RecycleBinItemList FromApiDeletedNodeSummaryList(ApiDeletedNodeSummaryList apiNodeList) {
            if (apiNodeList == null) {
                return null;
            }

            var items = new List<RecycleBinItem>();
            foreach (ApiDeletedNodeSummary currentNode in apiNodeList.Items) {
                items.Add(FromApiDeletedNodeSummary(currentNode));
            }
            RecycleBinItemList nodeList = new RecycleBinItemList() {
                Offset = apiNodeList.Range.Offset,
                Limit = apiNodeList.Range.Limit,
                Total = apiNodeList.Range.Total,
                Items = items.ToArray()
            };
            return nodeList;
        }

        internal static RecycleBinItem FromApiDeletedNodeSummary(ApiDeletedNodeSummary apiNode) {
            if (apiNode == null) {
                return null;
            }

            RecycleBinItem node = new RecycleBinItem {
                Type = EnumConverter.ConvertValueToNodeTypeEnum(apiNode.Type),
                ParentId = apiNode.ParentId,
                ParentPath = apiNode.ParentPath,
                Name = apiNode.Name,
                FirstDeletedAt = apiNode.FirstDeletedAt,
                LastDeletedAt = apiNode.LastDeletedAt,
                LastDeletedNodeId = apiNode.LastDeletedNodeId,
                VersionsCount = apiNode.CntVersions
            };
            return node;
        }

        internal static PreviousVersionList FromApiDeletedNodeVersionsList(ApiDeletedNodeVersionsList apiNodeList) {
            if (apiNodeList == null) {
                return null;
            }

            var items = new List<PreviousVersion>();
            foreach (ApiDeletedNodeVersion currentNode in apiNodeList.Items) {
                items.Add(FromApiDeletedNodeVersion(currentNode));
            }
            PreviousVersionList nodeList = new PreviousVersionList() {
                Offset = apiNodeList.Range.Offset,
                Limit = apiNodeList.Range.Limit,
                Total = apiNodeList.Range.Total,
                Items = items.ToArray()
            };
            return nodeList;
        }

        internal static PreviousVersion FromApiDeletedNodeVersion(ApiDeletedNodeVersion apiNode) {
            if (apiNode == null) {
                return null;
            }

            PreviousVersion node = new PreviousVersion {
                Type = EnumConverter.ConvertValueToNodeTypeEnum(apiNode.Type),
                ParentId = apiNode.ParentId,
                ParentPath = apiNode.ParentPath,
                Name = apiNode.Name,
                AccessedAt = apiNode.AccessedAt,
                Classification = EnumConverter.ConvertValueToClassificationEnum(apiNode.Classification),
                CreatedAt = apiNode.CreatedAt,
                CreatedBy = UserMapper.FromApiUserInfo(apiNode.CreatedBy),
                DeletedAt = apiNode.DeletedAt,
                DeletedBy = UserMapper.FromApiUserInfo(apiNode.DeletedBy),
                ExpireAt = apiNode.ExpireAt,
                Id = apiNode.Id,
                IsEncrypted = apiNode.IsEncrypted,
                Notes = apiNode.Notes,
                Size = apiNode.Size,
                UpdatedAt = apiNode.UpdatedAt,
                UpdatedBy = UserMapper.FromApiUserInfo(apiNode.UpdatedBy)
            };
            return node;
        }

        internal static ApiRestorePreviousVersionsRequest ToApiRestorePreviousVersionsRequest(RestorePreviousVersionsRequest request) {
            ApiRestorePreviousVersionsRequest apiRequest = new ApiRestorePreviousVersionsRequest {
                DeletedNodeIds = request.RestoreVersionIds,
                KeepShareLinks = request.KeepShareLinks,
                ParentId = request.NewParentNodeId,
                ResolutionStrategy = EnumConverter.ConvertResolutionStrategyToValue(request.ResolutionStrategy)
            };
            return apiRequest;
        }

        internal static ApiDeletePreviousVersionsRequest ToApiDeletePreviousVersionsRequest(DeletePreviousVersionsRequest request) {
            ApiDeletePreviousVersionsRequest apiRequest = new ApiDeletePreviousVersionsRequest {
                VersionsToBeDeleted = request.VersionIds
            };
            return apiRequest;
        }









        internal static ApiRoomGroupsAddBatchRequest ToApiRoomGroupsAddBatchRequest(RoomGroupsAddBatchRequest roomGroupsAddBatchRequest) {
            ApiRoomGroupsAddBatchRequest apiRoomGroupsAddBatchRequest = new ApiRoomGroupsAddBatchRequest();
            CommonMapper.ToApiSimpleList(roomGroupsAddBatchRequest, apiRoomGroupsAddBatchRequest, ToApiRoomGroupsAddBatchRequestItem);
            return apiRoomGroupsAddBatchRequest;
        }

        private static ApiRoomGroupsAddBatchRequestItem ToApiRoomGroupsAddBatchRequestItem(RoomGroupsAddBatchRequestItem roomGroupsAddBatchRequestItem) {
            ApiRoomGroupsAddBatchRequestItem apiRoomGroupsAddBatchRequestItem = new ApiRoomGroupsAddBatchRequestItem() {
                Id = roomGroupsAddBatchRequestItem.Id,
                Permissions = ToApiNodePermissions(roomGroupsAddBatchRequestItem.Permissions),
                NewGroupMemberAcceptance = EnumConverter.ConvertGroupMemberAcceptanceToValue(roomGroupsAddBatchRequestItem.NewGroupMemberAcceptance)
            };
            return apiRoomGroupsAddBatchRequestItem;
        }

        private static ApiNodePermissions ToApiNodePermissions(NodePermissions nodePermissions) {
            if (nodePermissions == null) {
                return null;
            }

            ApiNodePermissions apiNodePermissions = new ApiNodePermissions() {
                Manage = nodePermissions.Manage,
                Read = nodePermissions.Read,
                Create = nodePermissions.Create,
                Change = nodePermissions.Change,
                Delete = nodePermissions.Delete,
                ManageDownloadShare = nodePermissions.ManageDownloadShare,
                ManageUploadShare = nodePermissions.ManageUploadShare,
                ReadRecycleBin = nodePermissions.CanReadRecycleBin,
                RestoreRecycleBin = nodePermissions.CanRestoreRecycleBin,
                DeleteRecycleBin = nodePermissions.CanDeleteRecycleBin
            };
            return apiNodePermissions;
        }

        internal static ApiRoomUsersAddBatchRequest ToApiRoomUsersAddBatchRequest(RoomUsersAddBatchRequest roomUsersAddBatchRequest) {
            ApiRoomUsersAddBatchRequest apiRoomUsersAddBatchRequest = new ApiRoomUsersAddBatchRequest();
            CommonMapper.ToApiSimpleList(roomUsersAddBatchRequest, apiRoomUsersAddBatchRequest, ToApiRoomUsersAddBatchRequestItem);
            return apiRoomUsersAddBatchRequest;
        }

        private static ApiRoomUsersAddBatchRequestItem ToApiRoomUsersAddBatchRequestItem(RoomUsersAddBatchRequestItem roomUsersAddBatchRequestItem) {
            ApiRoomUsersAddBatchRequestItem apiRoomUsersAddBatchRequestItem = new ApiRoomUsersAddBatchRequestItem() {
                Id = roomUsersAddBatchRequestItem.Id,
                Permissions = ToApiNodePermissions(roomUsersAddBatchRequestItem.Permissions)
            };
            return apiRoomUsersAddBatchRequestItem;
        }

        internal static RoomGroupList FromApiRoomGroupList(ApiRoomGroupList apiRoomGroupList) {
            RoomGroupList roomGroupList = new RoomGroupList();
            CommonMapper.FromApiRangeList(apiRoomGroupList, roomGroupList, FromApiRoomGroup);
            return roomGroupList;
        }

        private static RoomGroup FromApiRoomGroup(ApiRoomGroup apiRoomGroup) {
            GroupInfo groupInfo = new GroupInfo() {
                Id = apiRoomGroup.Id,
                Name = apiRoomGroup.Name,
            };
            RoomGroup roomGroup = new RoomGroup() {
                GroupInfo = groupInfo,
                IsGranted = apiRoomGroup.IsGranted,
                Permissions = FromApiNodePermissions(apiRoomGroup.Permissions),
                NewGroupMemberAcceptance = EnumConverter.ConvertValueToGroupMemberAcceptance(apiRoomGroup.NewGroupMemberAcceptance).Value
            };
            return roomGroup;
        }

        internal static RoomUserList FromApiRoomUserList(ApiRoomUserList apiRoomUserList) {
            RoomUserList roomUserList = new RoomUserList();
            CommonMapper.FromApiRangeList(apiRoomUserList, roomUserList, FromApiRoomUser);
            return roomUserList;
        }

        private static RoomUser FromApiRoomUser(ApiRoomUser apiRoomUser) {
            RoomUser roomUser = new RoomUser() {
                UserInfo = UserMapper.FromApiUserInfo(apiRoomUser.UserInfo),
                IsGranted = apiRoomUser.IsGranted,
                Permissions = FromApiNodePermissions(apiRoomUser.Permissions),
                PublicKeyContainer = UserMapper.FromApiUserPublicKey(apiRoomUser.PublicKeyContainer)
            };
            return roomUser;
        }

        internal static PendingAssignmentList FromApiPendingAssignmentList(ApiPendingAssignmentList apiPendingAssignmentList) {
            PendingAssignmentList PendingAssignmentList = new PendingAssignmentList();
            CommonMapper.FromApiRangeList(apiPendingAssignmentList, PendingAssignmentList, FromApiPendingAssignmentData);
            return PendingAssignmentList;
        }

        private static PendingAssignmentData FromApiPendingAssignmentData(ApiPendingAssignmentData apiPendingAssignmentData) {
            PendingAssignmentData pendingAssignmentData = new PendingAssignmentData() {
                RoomId = apiPendingAssignmentData.RoomId,
                State = EnumConverter.ConvertValueToPendingAssignmentState(apiPendingAssignmentData.State).Value,
                UserInfo = UserMapper.FromApiUserInfo(apiPendingAssignmentData.UserInfo),
                GroupInfo = GroupMapper.FromApiGroupInfo(apiPendingAssignmentData.GroupInfo)
            };
            return pendingAssignmentData;
        }

        internal static ApiRoomGroupsDeleteBatchRequest ToApiRoomGroupsDeleteBatchRequest(IEnumerable<long> ids) {
            if (ids == null)
                return null;
            ApiRoomGroupsDeleteBatchRequest apiRoomGroupsDeleteBatchRequest = new ApiRoomGroupsDeleteBatchRequest() {
                Ids = ids
            };
            return apiRoomGroupsDeleteBatchRequest;
        }

        internal static ApiRoomUsersDeleteBatchRequest ToApiRoomUsersDeleteBatchRequest(IEnumerable<long> ids) {
            if (ids == null)
                return null;
            ApiRoomUsersDeleteBatchRequest apiRoomUsersDeleteBatchRequest = new ApiRoomUsersDeleteBatchRequest() {
                Ids = ids
            };
            return apiRoomUsersDeleteBatchRequest;
        }
    }
}