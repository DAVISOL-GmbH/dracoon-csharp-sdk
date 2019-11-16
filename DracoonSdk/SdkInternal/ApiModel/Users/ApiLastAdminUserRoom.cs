using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiLastAdminUserRoom {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id {
            get; internal set;
        }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name {
            get; internal set;
        }
        [JsonProperty("parentPath", NullValueHandling = NullValueHandling.Ignore)]
        public string ParentPath {
            get; internal set;
        }
        [JsonProperty("lastAdminInGroup", NullValueHandling = NullValueHandling.Ignore)]
        public bool LastAdminInGroup {
            get; internal set;
        }
        [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
        public long ParentId {
            get; internal set;
        }
        [JsonProperty("lastAdminInGroupId", NullValueHandling = NullValueHandling.Ignore)]
        public long? LastAdminInGroupId {
            get; internal set;
        }
    }
}
