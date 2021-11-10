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

        public void SetBasicAuth(string password, bool mustChangePassword = true) {
            AuthData.Method = UserAuthMethod.Basic;
            AuthData.Login = UserName;
            AuthData.Password = password;
            AuthData.MustChangePassword = mustChangePassword;
            AuthData.OIDConfigId = null;
            AuthData.ADConfigId = null;
        }

        public void SetOpenIDAuth(string openIdLogin, int openIDConfigId) {
            AuthData.Method = UserAuthMethod.OpenID;
            AuthData.Login = openIdLogin;
            AuthData.Password = null;
            AuthData.MustChangePassword = null;
            AuthData.OIDConfigId = openIDConfigId;
            AuthData.ADConfigId = null;
        }

        public void SetActiveDirectoryAuth(string adLogin, int adConfigId) {
            AuthData.Method = UserAuthMethod.OpenID;
            AuthData.Login = adLogin;
            AuthData.Password = null;
            AuthData.MustChangePassword = null;
            AuthData.OIDConfigId = null;
            AuthData.ADConfigId = adConfigId;
        }


    }
}
