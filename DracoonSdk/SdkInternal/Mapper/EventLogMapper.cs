using System.Collections.Generic;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;

namespace Dracoon.Sdk.SdkInternal.Mapper {
    internal static class EventLogMapper {

        internal static AuditNodeList FromApiAuditNodeResponseList(ApiAuditNodeResponseList apiAuditNodeResponseList, long offset, long limit) {

            List<AuditNodeResponse> auditNodeResponses = new List<AuditNodeResponse>();
            foreach (ApiAuditNodeResponse apiAuditNodeResponse in apiAuditNodeResponseList) {
                auditNodeResponses.Add(FromApiAuditNodeResponse(apiAuditNodeResponse));
            }
            AuditNodeList auditNodeList = new AuditNodeList() {
                Limit = limit,
                Offset = offset,
                Total = auditNodeResponses.Count,
                Items = auditNodeResponses.ToArray()
            };
            return auditNodeList;
        }

        private static AuditNodeResponse FromApiAuditNodeResponse(ApiAuditNodeResponse apiAuditNodeResponse) {
            List<AuditUserPermission> auditUserPermissions = new List<AuditUserPermission>();
            if (apiAuditNodeResponse.AuditUserPermissionList != null) {
                foreach (ApiAuditUserPermission apiAuditUserPermission in apiAuditNodeResponse.AuditUserPermissionList) {
                    auditUserPermissions.Add(FromApiAuditUserPermission(apiAuditUserPermission));
                }
            }

            AuditNodeResponse auditNodeResponse = new AuditNodeResponse() {
                NodeId = apiAuditNodeResponse.NodeId,
                NodeName = apiAuditNodeResponse.NodeName,
                NodeParentPath = apiAuditNodeResponse.NodeParentPath,
                NodeParentId = apiAuditNodeResponse.NodeParentId,
                NodeCountChildren = apiAuditNodeResponse.NodeCountChildren,
                AuditUserPermissionList = auditUserPermissions.ToArray(),
                NodeSize = apiAuditNodeResponse.NodeSize,
                NodeRecycleBinRetentionPeriod = apiAuditNodeResponse.NodeRecycleBinRetentionPeriod,
                NodeQuota = apiAuditNodeResponse.NodeQuota,
                NodeIsEncrypted = apiAuditNodeResponse.NodeIsEncrypted,
                NodeHasActivitiesLog = apiAuditNodeResponse.NodeHasActivitiesLog,
                NodeCreatedAt = apiAuditNodeResponse.NodeCreatedAt,
                NodeCreatedBy = UserMapper.FromApiUserInfo(apiAuditNodeResponse.NodeCreatedBy),
                NodeUpdatedAt = apiAuditNodeResponse.NodeUpdatedAt,
                NodeUpdatedBy = UserMapper.FromApiUserInfo(apiAuditNodeResponse.NodeUpdatedBy)
            };
            return auditNodeResponse;
        }

        private static AuditUserPermission FromApiAuditUserPermission(ApiAuditUserPermission apiAuditUserPermission) {
            AuditUserPermission auditUserPermission = new AuditUserPermission() {
                UserId = apiAuditUserPermission.UserId,
                UserLogin = apiAuditUserPermission.UserLogin,
                UserFirstName = apiAuditUserPermission.UserFirstName,
                UserLastName = apiAuditUserPermission.UserLastName,
                Permissions = NodeMapper.FromApiNodePermissions(apiAuditUserPermission.Permissions)
            };
            return auditUserPermission;
        }

        internal static LogEventList FromApiLogEventList(ApiLogEventList apiLogEventList) {
            LogEventList logEventList = new LogEventList();
            CommonMapper.FromApiRangeList(apiLogEventList, logEventList, FromApiLogEvent);
            return logEventList;
        }

        private static LogEvent FromApiLogEvent(ApiLogEvent apiLogEvent) {
            LogEvent logEvent = new LogEvent() {
                Id = apiLogEvent.Id,
                Time = apiLogEvent.Time,
                UserId = apiLogEvent.UserId,
                Message = apiLogEvent.Message,
                OperationId = apiLogEvent.OperationId,
                OperationName = apiLogEvent.OperationName,
                Status = apiLogEvent.Status == 0 ? EventStatus.Success : EventStatus.Error,
                UserClient = apiLogEvent.UserClient,
                CustomerId = apiLogEvent.CustomerId,
                UserName = apiLogEvent.UserName,
                UserIp = apiLogEvent.UserIp,
                AuthParentSource = apiLogEvent.AuthParentSource,
                AuthParentTarget = apiLogEvent.AuthParentTarget,
                ObjectId1 = apiLogEvent.ObjectId1,
                ObjectName1 = apiLogEvent.ObjectName1,
                ObjectType1 = apiLogEvent.ObjectType1,
                ObjectId2 = apiLogEvent.ObjectId2,
                ObjectName2 = apiLogEvent.ObjectName2,
                ObjectType2 = apiLogEvent.ObjectType2,
                Attribute1 = apiLogEvent.Attribute1,
                Attribute2 = apiLogEvent.Attribute2,
                Attribute3 = apiLogEvent.Attribute3,
            };
            return logEvent;
        }

        internal static LogOperationList FromApiLogOperationList(ApiLogOperationList apiLogOperationList) {
            if (apiLogOperationList == null) {
                return null;
            }

            List<LogOperation> items = new List<LogOperation>();
            foreach (ApiLogOperation currentItem in apiLogOperationList.Items) {
                items.Add(FromApiLogOperation(currentItem));
            }
            LogOperationList logOperationList = new LogOperationList() {
                Items = items.ToArray()
            };

            return logOperationList;
        }

        private static LogOperation FromApiLogOperation(ApiLogOperation apiLogOperation) {
            LogOperation logOperation = new LogOperation() {
                Id = apiLogOperation.Id,
                Name = apiLogOperation.Name,
                IsDeprecated = apiLogOperation.IsDeprecated
            };
            return logOperation;
        }
    }
}
