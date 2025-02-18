using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.ApiModel.Requests;
using Dracoon.Sdk.SdkInternal.Util;

namespace Dracoon.Sdk.SdkInternal.Mapper {
    internal static class RoomMapper {
        internal static ApiCreateRoomRequest ToApiCreateRoomRequest(CreateRoomRequest createRoomRequest) {
            ApiCreateRoomRequest apiCreateRoomRequest = new ApiCreateRoomRequest {
                ParentId = null,
                Name = createRoomRequest.Name,
                Quota = createRoomRequest.Quota,
                Notes = createRoomRequest.Notes,
                RecycleBinRetentionPeriod = createRoomRequest.RecycleBinRetentionPeriod,
                InheritPermissions = createRoomRequest.HasInheritPermissions,
                AdminIds = createRoomRequest.AdminUserIds,
                AdminGroupIds = createRoomRequest.AdminGroupIds,
                NewGroupMemberAcceptance = EnumConverter.ConvertGroupMemberAcceptanceToValue(createRoomRequest.NewGroupMemberAcceptance),
                Classification = EnumConverter.ConvertClassificationEnumToValue(createRoomRequest.Classification),
                HasActivitiesLog = createRoomRequest.HasActivitiesLog,
                CreationTimestamp = createRoomRequest.CreationTimestamp,
                ModificationTimestamp = createRoomRequest.ModificationTimestamp
            };
            if (createRoomRequest.ParentId != 0)
                apiCreateRoomRequest.ParentId = createRoomRequest.ParentId;
            return apiCreateRoomRequest;
        }

        internal static ApiUpdateRoomRequest ToApiUpdateRoomRequest(UpdateRoomRequest updateRoomRequest) {
            ApiUpdateRoomRequest apiUpdateRoomRequest = new ApiUpdateRoomRequest {
                Name = updateRoomRequest.Name,
                Quota = updateRoomRequest.Quota,
                Notes = updateRoomRequest.Notes,
                CreationTimestamp = updateRoomRequest.CreationTimestamp,
                ModificationTimestamp = updateRoomRequest.ModificationTimestamp
            };
            return apiUpdateRoomRequest;
        }

        internal static ApiConfigRoomRequest ToApiConfigRoomRequest(ConfigRoomRequest configRoomRequest) {
            ApiConfigRoomRequest apiConfigRoomRequest = new ApiConfigRoomRequest() {
                RecycleBinRetentionPeriod = configRoomRequest.RecycleBinRetentionPeriod,
                InheritPermissions = configRoomRequest.InheritPermissions,
                TakeOverPermissions = configRoomRequest.TakeOverPermissions,
                AdminIds = configRoomRequest.AdminIds,
                AdminGroupIds = configRoomRequest.AdminGroupIds,
                NewGroupMemberAcceptance = EnumConverter.ConvertGroupMemberAcceptanceToValue(configRoomRequest.NewGroupMemberAcceptance),
                HasActivitiesLog = configRoomRequest.HasActivitiesLog,
                Classification = EnumConverter.ConvertClassificationEnumToValue(configRoomRequest.Classification)
            };
            return apiConfigRoomRequest;
        }

        internal static ApiEnableRoomEncryptionRequest ToApiEnableRoomEncryptionRequest(EnableRoomEncryptionRequest enableRoomEncryptionRequest, ApiUserKeyPair dataRoomRescueKey) {
            ApiEnableRoomEncryptionRequest apiEnableRoomEncryptionRequest = new ApiEnableRoomEncryptionRequest() {
                IsEncryptionEnabled = enableRoomEncryptionRequest.IsEncryptionEnabled,
                UseDataSpaceRescueKey = enableRoomEncryptionRequest.UseDataSpaceRescueKey,
                DataRoomRescueKey = dataRoomRescueKey
            };
            return apiEnableRoomEncryptionRequest;
        }
    }
}
