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
            get; private set;
        }


        public void SetBasicAuth(string password, bool mustChangePassword = true) {
            AuthData = new UserAuthDataUpdateRequest {
                Method = UserAuthMethod.Basic,
                Login = UserName,
                OIDConfigId = null,
                ADConfigId = null,
            };
        }

        public void SetOpenIDAuth(string openIdLogin, int openIDConfigId) {
            AuthData = new UserAuthDataUpdateRequest {

                Method = UserAuthMethod.OpenID,
                Login = openIdLogin,
                OIDConfigId = openIDConfigId,
                ADConfigId = null,
            };
        }

        public void SetActiveDirectoryAuth(string adLogin, int adConfigId) {
            AuthData = new UserAuthDataUpdateRequest {
                Method = UserAuthMethod.ActiveDirectory,
                Login = adLogin,
                OIDConfigId = null,
                ADConfigId = adConfigId
            };
        }

    }
}
