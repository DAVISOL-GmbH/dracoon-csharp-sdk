using System;
using System.Collections.Generic;
using System.Linq;

namespace Dracoon.Sdk.Model {
    public class RoomGroupsAddBatchRequest : SimpleListBase<RoomGroupsAddBatchRequestItem> {
        public RoomGroupsAddBatchRequest(IEnumerable<RoomGroupsAddBatchRequestItem> items) {
            Items = items?.ToArray() ?? Array.Empty<RoomGroupsAddBatchRequestItem>();
        }
    }
}
