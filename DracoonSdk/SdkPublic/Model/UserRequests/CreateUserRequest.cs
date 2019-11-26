using System;
using System.Globalization;

namespace Dracoon.Sdk.Model {
    public class CreateUserRequest {

        public string FirstName {
            get; set;
        }

        public string LastName {
            get; set;
        }

        public string UserName {
            get; set;
        }

        public string Title {
            get; set;
        }

        public string Gender {
            get; set;
        }

        public string Phone {
            get; set;
        }

        public DateTime? ExpireAt {
            get; set;
        }

        public CultureInfo ReceiverLanguage {
            get; set;
        }

        public string Email {
            get; set;
        }

        public bool NotifyUser {
            get; set;
        }

        public UserAuthData AuthData {
            get; private set;
        } = new UserAuthData();

        public bool IsNonmemberViewer {
            get; set;
        }
    }
}
