using System.Collections.Generic;
using System.Linq;

namespace Dracoon.Sdk.Model {
    public class RoomUsersAddBatchRequest : SimpleListBase<RoomUsersAddBatchRequestItem> {
        public RoomUsersAddBatchRequest(IEnumerable<RoomUsersAddBatchRequestItem> items) {
            Items = items?.ToArray() ?? new RoomUsersAddBatchRequestItem[0];
        }
    }
}
