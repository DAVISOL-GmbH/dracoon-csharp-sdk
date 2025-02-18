using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel.Requests;
using Dracoon.Sdk.SdkInternal.Util;

namespace Dracoon.Sdk.SdkInternal.Mapper {
    internal static class FolderMapper {
        internal static ApiCreateFolderRequest ToApiCreateFolderRequest(CreateFolderRequest createFolderRequest) {
            ApiCreateFolderRequest apiCreateFolderRequest = new ApiCreateFolderRequest {
                ParentId = createFolderRequest.ParentId,
                Name = createFolderRequest.Name,
                Notes = createFolderRequest.Notes,
                Classification = EnumConverter.ConvertClassificationEnumToValue(createFolderRequest.Classification),
                CreationTimestamp = createFolderRequest.CreationTimestamp,
                ModificationTimestamp = createFolderRequest.ModificationTimestamp
            };
            return apiCreateFolderRequest;
        }

        internal static ApiUpdateFolderRequest ToApiUpdateFolderRequest(UpdateFolderRequest updateFolderRequest) {
            ApiUpdateFolderRequest apiUpdateFolderRequest = new ApiUpdateFolderRequest {
                Name = updateFolderRequest.Name,
                Notes = updateFolderRequest.Notes,
                Classification = EnumConverter.ConvertClassificationEnumToValue(updateFolderRequest.Classification),
                CreationTimestamp = updateFolderRequest.CreationTimestamp,
                ModificationTimestamp = updateFolderRequest.ModificationTimestamp
            };
            return apiUpdateFolderRequest;
        }
    }
}
