using System;

namespace Dracoon.Sdk.Model {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class LogEvent {

        public long Id {
            get;
            internal set;
        }

        public DateTime Time {
            get;
            internal set;
        }

        public long UserId {
            get;
            internal set;
        }

        public string Message {
            get;
            internal set;
        }

        public int OperationId {
            get;
            internal set;
        }

        public string OperationName {
            get;
            internal set;
        }

        public EventStatus Status {
            get;
            internal set;
        }

        public string UserClient {
            get;
            internal set;
        }

        public long CustomerId {
            get;
            internal set;
        }

        public string UserName {
            get;
            internal set;
        }

        public string UserIp {
            get;
            internal set;
        }

        public string AuthParentSource {
            get;
            internal set;
        }

        public string AuthParentTarget {
            get;
            internal set;
        }

        public long ObjectId1 {
            get;
            internal set;
        }

        public int ObjectType1 {
            get;
            internal set;
        }

        public string ObjectName1 {
            get;
            internal set;
        }

        public long ObjectId2 {
            get;
            internal set;
        }

        public int ObjectType2 {
            get;
            internal set;
        }

        public string ObjectName2 {
            get;
            internal set;
        }

        public string Attribute1 {
            get;
            internal set;
        }

        public string Attribute2 {
            get;
            internal set;
        }

        public string Attribute3 {
            get;
            internal set;
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
