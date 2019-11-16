
using System;

namespace Dracoon.Sdk.Model {
    /// <include file = "ModelDoc.xml" path='docs/members[@name="userInfo"]/UserInfo/*'/>
    public class UserInfo {

        /// <include file = "ModelDoc.xml" path='docs/members[@name="userInfo"]/Id/*'/>
        public long Id {
            get; internal set;
        }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="userInfo"]/DisplayName/*'/>
        [Obsolete("Deprecated since version 4.11.0, use other fields from UserInfo instead to combine a display name")]
        public string DisplayName {
            get; internal set;
        }

        public UserType? UserType {
            get; set;
        }

        public string AvatarUuid {
            get; set;
        }

        public string UserName {
            get; set;
        }

        public string FirstName {
            get; set;
        }

        public string LastName {
            get; set;
        }

        public string Email {
            get; set;
        }

        public string Title {
            get; set;
        }
    }
}
