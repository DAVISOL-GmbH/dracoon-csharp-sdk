using System;
using System.Globalization;

namespace Dracoon.Sdk.Model {
    public class UpdateUserRequest {

        public string Title {
            get; set;
        }

        public string FirstName {
            get; set;
        }

        public string LastName {
            get; set;
        }

        public string UserName {
            get; set;
        }

        public string Email {
            get; set;
        }

        public bool IsLocked {
            get; set;
        }

        public string Phone {
            get; set;
        }

        public CultureInfo ReceiverLanguage {
            get; set;
        }

        public DateTime? ExpireAt {
            get; set;
        }

        public UserAuthDataUpdateRequest AuthData {
            get; set;
        }
    }
}
