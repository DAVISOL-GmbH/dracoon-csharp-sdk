using System;
using System.Globalization;

namespace Dracoon.Sdk.Model {
    public class UpdateUserRequest {

        public string Title {
            get; private set;
        }

        public string FirstName {
            get; private set;
        }

        public string LastName {
            get; private set;
        }

        public string UserName {
            get; private set;
        }

        public string Email {
            get; private set;
        }

        public string Gender {
            get; private set;
        }

        public bool IsLocked {
            get; private set;
        }

        public string Phone {
            get; private set;
        }

        public CultureInfo ReceiverLanguage {
            get; private set;
        }

        public DateTime? ExpireAt {
            get; private set;
        }

        public UserAuthDataUpdateRequest AuthData {
            get; private set;
        }
    }
}
