using System;
using Dracoon.Sdk.Filter;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.Mapper;
using Dracoon.Sdk.SdkInternal.Validator;
using Dracoon.Sdk.Sort;
using RestSharp;
using static Dracoon.Sdk.SdkInternal.DracoonRequestExecutor;

namespace Dracoon.Sdk.SdkInternal {
    internal class DracoonEventLogImpl : IEventLog {

        internal static readonly string Logtag = nameof(DracoonEventLogImpl);
        private readonly IInternalDracoonClient _client;

        internal DracoonEventLogImpl(IInternalDracoonClient client) {
            _client = client;
        }

        #region Event services

        public AuditNodeList GetAuditNodes(long? offset = null, long? limit = null, GetAuditNodesFilter filter = null, AuditNodesSort sort = null) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            offset.NullableMustNotNegative(nameof(offset));
            limit.NullableMustPositive(nameof(limit));
            #endregion

            RestRequest restRequest = _client.Builder.GetAuditNodes(offset, limit, filter, sort);
            ApiAuditNodeResponseList result = _client.Executor.DoSyncApiCall<ApiAuditNodeResponseList>(restRequest, RequestType.GetAuditNodes);
            return EventLogMapper.FromApiAuditNodeResponseList(result, offset ?? 0, limit ?? 500);
        }

        public LogEventList GetEvents(DateTime? dateStart = null, DateTime? dateEnd = null, EventStatus? status = null, int? operationId = null, long? userId = null, string userClient = null, long? offset = null, long? limit = null, EventLogsSort sort = null) {
            _client.Executor.CheckApiServerVersion();
            #region Parameter Validation
            userId.NullableMustPositive(nameof(userId));
            operationId.NullableMustPositive(nameof(operationId));
            offset.NullableMustNotNegative(nameof(offset));
            limit.NullableMustPositive(nameof(limit));
            #endregion

            RestRequest restRequest = _client.Builder.GetEvents(dateStart, dateEnd, status, operationId, userId, userClient, offset, limit, sort);
            ApiLogEventList result = _client.Executor.DoSyncApiCall<ApiLogEventList>(restRequest, RequestType.GetEvents);
            return EventLogMapper.FromApiLogEventList(result);
        }

        public LogOperationList GetOperations(bool? isDeprecated = null) {
            _client.Executor.CheckApiServerVersion();

            RestRequest restRequest = _client.Builder.GetOperations(isDeprecated);
            ApiLogOperationList result = _client.Executor.DoSyncApiCall<ApiLogOperationList>(restRequest, RequestType.GetOperations);
            return EventLogMapper.FromApiLogOperationList(result);
        }

        #endregion
    }
}
