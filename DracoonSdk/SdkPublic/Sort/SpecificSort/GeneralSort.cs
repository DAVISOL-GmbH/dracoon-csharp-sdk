namespace Dracoon.Sdk.Sort {
    /// <include file = "SpecificSort.xml" path='docs/members[@name="generalSort"]/UpdatedAtSort/*'/>
    public class UpdatedAtSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        /// <include file = "SpecificSort.xml" path='docs/members[@name="generalSort"]/UpdatedAtSortConstructor/*'/>
        public UpdatedAtSort(T p) : base(p) {
            parent.sortString += "updatedAt";
        }
    }

    /// <include file = "SpecificSort.xml" path='docs/members[@name="generalSort"]/SizeSort/*'/>
    public class SizeSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        /// <include file = "SpecificSort.xml" path='docs/members[@name="generalSort"]/SizeSortConstructor/*'/>
        public SizeSort(T p) : base(p) {
            parent.sortString += "size";
        }
    }

    /// <include file = "SpecificSort.xml" path='docs/members[@name="generalSort"]/ExpireAtSort/*'/>
    public class ExpireAtSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        /// <include file = "SpecificSort.xml" path='docs/members[@name="generalSort"]/ExpireAtSortConstructor/*'/>
        public ExpireAtSort(T p) : base(p) {
            parent.sortString += "expireAt";
        }
    }

    /// <include file = "SpecificSort.xml" path='docs/members[@name="generalSort"]/CreatedAtSort/*'/>
    public class CreatedAtSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        /// <include file = "SpecificSort.xml" path='docs/members[@name="generalSort"]/CreatedAtSortConstructor/*'/>
        public CreatedAtSort(T p) : base(p) {
            parent.sortString += "createdAt";
        }
    }

    /// <include file = "SpecificSort.xml" path='docs/members[@name="generalSort"]/NameSort/*'/>
    public class NameSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        /// <include file = "SpecificSort.xml" path='docs/members[@name="generalSort"]/NameSortConstructor/*'/>
        public NameSort(T p) : base(p) {
            parent.sortString += "name";
        }
    }

    public class CountUsersSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public CountUsersSort(T p) : base(p) {
            parent.sortString += "cntUsers";
        }
    }

    public class KeySort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public KeySort(T p) : base(p) {
            parent.sortString += "key";
        }
    }

    public class ValueSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public ValueSort(T p) : base(p) {
            parent.sortString += "value";
        }
    }

    public class UserNameSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public UserNameSort(T p) : base(p) {
            parent.sortString += "userName";
        }
    }

    public class EmailSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public EmailSort(T p) : base(p) {
            parent.sortString += "email";
        }
    }

    public class LoginSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public LoginSort(T p) : base(p) {
            parent.sortString += "login";
        }
    }

    public class FirstNameSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public FirstNameSort(T p) : base(p) {
            parent.sortString += "firstName";
        }
    }

    public class LastNameSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public LastNameSort(T p) : base(p) {
            parent.sortString += "lastName";
        }
    }

    public class IsLockedSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public IsLockedSort(T p) : base(p) {
            parent.sortString += "isLocked";
        }
    }

    public class LastLoginSuccessAtSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public LastLoginSuccessAtSort(T p) : base(p) {
            parent.sortString += "lastLoginSuccessAt";
        }
    }

    public class NodeIdSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public NodeIdSort(T p) : base(p) {
            parent.sortString += "nodeId";
        }
    }

    public class NodeNameSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public NodeNameSort(T p) : base(p) {
            parent.sortString += "nodeName";
        }
    }

    public class NodeParentIdSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public NodeParentIdSort(T p) : base(p) {
            parent.sortString += "nodeParentId";
        }
    }

    public class NodeSizeSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public NodeSizeSort(T p) : base(p) {
            parent.sortString += "nodeSize";
        }
    }

    public class NodeQuotaSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public NodeQuotaSort(T p) : base(p) {
            parent.sortString += "nodeQuota";
        }
    }

    public class TimeSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public TimeSort(T p) : base(p) {
            parent.sortString += "time";
        }
    }

    public class UserIdSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public UserIdSort(T p) : base(p) {
            parent.sortString += "userId";
        }
    }

    public class GroupIdSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public GroupIdSort(T p) : base(p) {
            parent.sortString += "groupId";
        }
    }

    public class RoomIdSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public RoomIdSort(T p) : base(p) {
            parent.sortString += "roomId";
        }
    }

    public class AssignmentStateSort<T> : DracoonSortOrder<T> where T : DracoonSort {

        public AssignmentStateSort(T p) : base(p) {
            parent.sortString += "state";
        }
    }
}
