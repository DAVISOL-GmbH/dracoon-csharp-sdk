using System;
using Dracoon.Sdk.Filter;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.Sort;

namespace Dracoon.Sdk {
    public interface IEventLog {

        AuditNodeList GetAuditNodes(long? offset = null, long? limit = null, GetAuditNodesFilter filter = null, AuditNodesSort sort = null);

        LogEventList GetEvents(DateTime? dateStart = null, DateTime? dateEnd = null, EventStatus? status = null, int? operationId = null, long? userId = null, string userClient = null, long? offset = null, long? limit = null, EventLogsSort sort = null);

        LogOperationList GetOperations(bool? isDeprecated = null);
    }
}
