using System;
using System.Globalization;

namespace Dracoon.Sdk.Model {
    public class CreateUserRequest {

        public string FirstName {
            get; private set;
        }

        public string LastName {
            get; private set;
        }

        public string UserName {
            get; private set;
        }

        public string Title {
            get; private set;
        }

        public string Gender {
            get; private set;
        }

        public string Phone {
            get; private set;
        }

        public DateTime? ExpireAt {
            get; private set;
        }

        public CultureInfo ReceiverLanguage {
            get; private set;
        }

        public string Email {
            get; private set;
        }

        public bool NotifyUser {
            get; private set;
        }

        public UserAuthData AuthData {
            get; private set;
        }

        public bool IsNonmemberViewer {
            get; private set;
        }
    }
}
