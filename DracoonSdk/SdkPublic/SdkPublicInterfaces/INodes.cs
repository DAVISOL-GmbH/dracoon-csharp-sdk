using Dracoon.Sdk.Filter;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.Sort;
using System;
using System.Collections.Generic;
using System.IO;

namespace Dracoon.Sdk {
    /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/INodes/*'/>
    public interface INodes {
        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/GetNodes/*'/>
        NodeList GetNodes(long parentNodeId = 0, long? offset = null, long? limit = null, GetNodesFilter filter = null);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/GetNodeId/*'/>
        Node GetNode(long nodeId);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/GetNodePath/*'/>
        Node GetNode(string nodePath);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/DeleteNodes/*'/>
        void DeleteNodes(DeleteNodesRequest request);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/CopyNodes/*'/>
        Node CopyNodes(CopyNodesRequest request);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/MoveNodes/*'/>
        Node MoveNodes(MoveNodesRequest request);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/CreateRoom/*'/>
        Node CreateRoom(CreateRoomRequest request);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/UpdateRoom/*'/>
        Node UpdateRoom(UpdateRoomRequest request);

        Node UpdateRoomConfig(long roomId, ConfigRoomRequest request);

        LogEventList GetRoomEvents(long roomId, DateTime? dateStart = null, DateTime? dateEnd = null, EventStatus? status = null, int? operationId = null, long? userId = null, long? offset = null, long? limit = null, EventLogsSort sort = null);

        RoomGroupList GetRoomGroups(long roomId, long? offset = null, long? limit = null, GetRoomGroupsFilter filter = null);

        void OverwriteRoomGroups(long roomId, RoomGroupsAddBatchRequest request);

        void DeleteRoomGroups(long roomId, IEnumerable<long> groupIds);

        RoomUserList GetRoomUsers(long roomId, long? offset = null, long? limit = null, GetRoomUsersFilter filter = null);

        void OverwriteRoomUsers(long roomId, RoomUsersAddBatchRequest request);

        void DeleteRoomUsers(long roomId, IEnumerable<long> userIds);

        PendingAssignmentList GetRoomPending(long roomId, long? offset = null, long? limit = null, GetRoomPendingFilter filter = null, PendingAssignmentsSort sort = null);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/EnableRoomEncryption/*'/>
        Node EnableRoomEncryption(EnableRoomEncryptionRequest request);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/CreateFolder/*'/>
        Node CreateFolder(CreateFolderRequest request);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/UpdateFolder/*'/>
        Node UpdateFolder(UpdateFolderRequest request);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/UpdateFile/*'/>
        Node UpdateFile(UpdateFileRequest request);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/UploadFile/*'/>
        Node UploadFile(string actionId, FileUploadRequest request, Stream input, long fileSize = -1, IFileUploadCallback callback = null);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/StartUploadFileAsync/*'/>
        void StartUploadFileAsync(string actionId, FileUploadRequest request, Stream input, long fileSize = -1, IFileUploadCallback callback = null);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/CancelUploadFileAsync/*'/>
        void CancelUploadFileAsync(string actionId);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/DownloadFile/*'/>
        void DownloadFile(string actionId, long nodeId, Stream output, IFileDownloadCallback callback = null);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/StartDownloadFileAsync/*'/>
        void StartDownloadFileAsync(string actionId, long nodeId, Stream output, IFileDownloadCallback callback = null);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/CancelDownloadFileAsync/*'/>
        void CancelDownloadFileAsync(string actionId);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/SearchNodes/*'/>
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
        NodeList SearchNodes(string searchString, long parentNodeId = 0, int depthLevel = -1, long offset = 0, long limit = 500, SearchNodesFilter filter = null,
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            SearchNodesSort sort = null);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/GenerateMissingFileKeys/*'/>
        void GenerateMissingFileKeys(long? nodeId = null, int limit = int.MaxValue);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/SetNodeAsFavorite/*'/>
        Node SetNodeAsFavorite(long nodeId);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/DeleteNodeFromFavorites/*'/>
        void DeleteNodeFromFavorites(long nodeId);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/GetRecycleBinItems/*'/>
        RecycleBinItemList GetRecycleBinItems(long parentRoomId, long? offset = null, long? limit = null);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/EmptyRecycleBin/*'/>
        void EmptyRecycleBin(long parentRoomId);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/GetPreviousVersions/*'/>
        PreviousVersionList GetPreviousVersions(long parentId, NodeType type, string nodeName, long? offset = null, long? limit = null);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/GetPreviousVersion/*'/>
        PreviousVersion GetPreviousVersion(long previousNodeId);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/RestorePreviousVersion/*'/>
        void RestorePreviousVersion(RestorePreviousVersionsRequest request);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/DeletePreviousVersions/*'/>
        void DeletePreviousVersions(DeletePreviousVersionsRequest request);

        /// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iNodes"]/BuildMediaUrl/*'/>
        Uri BuildMediaUrl(string mediaToken, int width, int height);
    }
}
