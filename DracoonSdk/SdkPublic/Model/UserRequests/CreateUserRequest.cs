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
            get; private set;
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

        public CreateUserRequest(string userName, string firstName, string lastName, string email) {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
