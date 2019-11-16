using System;
using Dracoon.Sdk.Filter;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.Mapper;
using Dracoon.Sdk.SdkInternal.Validator;
using Dracoon.Sdk.Sort;
using RestSharp;

namespace Dracoon.Sdk.SdkInternal {
    internal class DracoonEventLogImpl : IEventLog {

        internal static readonly string LOGTAG = typeof(DracoonEventLogImpl).Name;
        private DracoonClient client;

        internal DracoonEventLogImpl(DracoonClient client) {
            this.client = client;
        }

        #region Event services

        public AuditNodeList GetAuditNodes(long? offset = null, long? limit = null, GetAuditNodesFilter filter = null, AuditNodesSort sort = null) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            offset.MustNotNegative(nameof(offset));
            limit.MustPositive(nameof(limit));
            #endregion

            RestRequest restRequest = client.RequestBuilder.GetAuditNodes(offset, limit, filter, sort);
            ApiAuditNodeResponseList result = client.RequestExecutor.DoSyncApiCall<ApiAuditNodeResponseList>(restRequest, DracoonRequestExecuter.RequestType.GetAuditNodes);
            return EventLogMapper.FromApiAuditNodeResponseList(result, offset ?? 0, limit ?? 500);
        }

        public LogEventList GetEvents(DateTime? dateStart = null, DateTime? dateEnd = null, EventStatus? status = null, int? operationId = null, long? userId = null, string userClient = null, long? offset = null, long? limit = null, EventLogsSort sort = null) {
            client.RequestExecutor.CheckApiServerVersion();
            #region Parameter Validation
            userId.MustPositive(nameof(userId));
            operationId.MustPositive(nameof(operationId));
            offset.MustNotNegative(nameof(offset));
            limit.MustPositive(nameof(limit));
            #endregion

            RestRequest restRequest = client.RequestBuilder.GetEvents(dateStart, dateEnd, status, operationId, userId, userClient, offset, limit, sort);
            ApiLogEventList result = client.RequestExecutor.DoSyncApiCall<ApiLogEventList>(restRequest, DracoonRequestExecuter.RequestType.GetEvents);
            return EventLogMapper.FromApiLogEventList(result);
        }

        public LogOperationList GetOperations(bool? isDeprecated = null) {
            client.RequestExecutor.CheckApiServerVersion();

            RestRequest restRequest = client.RequestBuilder.GetOperations(isDeprecated);
            ApiLogOperationList result = client.RequestExecutor.DoSyncApiCall<ApiLogOperationList>(restRequest, DracoonRequestExecuter.RequestType.GetOperations);
            return EventLogMapper.FromApiLogOperationList(result);
        }

        #endregion
    }
}
