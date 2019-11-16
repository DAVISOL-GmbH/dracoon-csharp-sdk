using System;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiLogEvent {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id {
            get;
            internal set;
        }
        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Time {
            get;
            internal set;
        }
        [JsonProperty("userId", NullValueHandling = NullValueHandling.Ignore)]
        public long UserId {
            get;
            internal set;
        }
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message {
            get;
            internal set;
        }
        [JsonProperty("operationId", NullValueHandling = NullValueHandling.Ignore)]
        public int OperationId {
            get;
            internal set;
        }
        [JsonProperty("operationName", NullValueHandling = NullValueHandling.Ignore)]
        public string OperationName {
            get;
            internal set;
        }
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public int Status {
            get;
            internal set;
        }
        [JsonProperty("userClient", NullValueHandling = NullValueHandling.Ignore)]
        public string UserClient {
            get;
            internal set;
        }
        [JsonProperty("customerId", NullValueHandling = NullValueHandling.Ignore)]
        public long CustomerId {
            get;
            internal set;
        }
        [JsonProperty("userName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName {
            get;
            internal set;
        }
        [JsonProperty("userIp", NullValueHandling = NullValueHandling.Ignore)]
        public string UserIp {
            get;
            internal set;
        }
        [JsonProperty("authParentSource", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthParentSource {
            get;
            internal set;
        }
        [JsonProperty("authParentTarget", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthParentTarget {
            get;
            internal set;
        }
        [JsonProperty("objectId1", NullValueHandling = NullValueHandling.Ignore)]
        public long ObjectId1 {
            get;
            internal set;
        }
        [JsonProperty("objectType1", NullValueHandling = NullValueHandling.Ignore)]
        public int ObjectType1 {
            get;
            internal set;
        }
        [JsonProperty("objectName1", NullValueHandling = NullValueHandling.Ignore)]
        public string ObjectName1 {
            get;
            internal set;
        }
        [JsonProperty("objectId2", NullValueHandling = NullValueHandling.Ignore)]
        public long ObjectId2 {
            get;
            internal set;
        }
        [JsonProperty("objectType2", NullValueHandling = NullValueHandling.Ignore)]
        public int ObjectType2 {
            get;
            internal set;
        }
        [JsonProperty("objectName2", NullValueHandling = NullValueHandling.Ignore)]
        public string ObjectName2 {
            get;
            internal set;
        }
        [JsonProperty("attribute1", NullValueHandling = NullValueHandling.Ignore)]
        public string Attribute1 {
            get;
            internal set;
        }
        [JsonProperty("attribute2", NullValueHandling = NullValueHandling.Ignore)]
        public string Attribute2 {
            get;
            internal set;
        }
        [JsonProperty("attribute3", NullValueHandling = NullValueHandling.Ignore)]
        public string Attribute3 {
            get;
            internal set;
        }
    }
}
