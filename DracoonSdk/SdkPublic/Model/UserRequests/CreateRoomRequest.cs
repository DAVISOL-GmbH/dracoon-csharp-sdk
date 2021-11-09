using System;
using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="createRoomRequest"]/CreateRoomRequest/*'/>
    public class CreateRoomRequest : CreateNodeRequestBase {
        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="createRoomRequest"]/ParentId/*'/>
        public long ParentId { get; set; }

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="createRoomRequest"]/Quota/*'/>
        public long? Quota { get; set; }

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="createRoomRequest"]/RecycleBinRetentionPeriod/*'/>
        public int? RecycleBinRetentionPeriod { get; set; }

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="createRoomRequest"]/HasInheritPermissions/*'/>
        public bool? HasInheritPermissions { get; set; }

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="createRoomRequest"]/AdminUserIds/*'/>
        public List<long> AdminUserIds { get; set; }

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="createRoomRequest"]/AdminGroupIds/*'/>
        public List<long> AdminGroupIds { get; set; }

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="createRoomRequest"]/NewGroupMemberAcceptance/*'/>
        public GroupMemberAcceptance NewGroupMemberAcceptance { get; set; }

        /// <include file = "UserRequestsDoc.xml" path='docs/members[@name="createRoomRequest"]/CreateRoomRequestConstructor/*'/>
        public CreateRoomRequest(string name, long parentId = 0, GroupMemberAcceptance newGroupMemberAcceptance = GroupMemberAcceptance.AutoAllow,
            long? quota = null, string notes = null, int? recycleBinRetentionPeriod = null, bool? hasInheritPermissions = null,
            List<long> adminUserIds = null, List<long> adminGroupIds = null,
            DateTime? creationTime = null, DateTime? modificationTime = null)
            : base(name, notes, creationTime, modificationTime) {
            ParentId = parentId;
            Quota = quota;
            RecycleBinRetentionPeriod = recycleBinRetentionPeriod;
            HasInheritPermissions = hasInheritPermissions;
            AdminUserIds = adminUserIds;
            AdminGroupIds = adminGroupIds;
            NewGroupMemberAcceptance = newGroupMemberAcceptance;
        }
    }
}
