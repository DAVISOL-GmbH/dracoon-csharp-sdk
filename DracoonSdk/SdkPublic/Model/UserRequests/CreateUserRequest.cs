using System;
using System.Globalization;

namespace Dracoon.Sdk.Model {
    /// <summary>
    /// Describes the data to create an user in DRACOON.
    /// </summary>
    public class CreateUserRequest {

        /// <summary>
        /// The first name of the user.
        /// </summary>
        public string FirstName {
            get; private set;
        }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        public string LastName {
            get; private set;
        }

        /// <summary>
        /// The unique user name (e.g. login name) of the user.
        /// </summary>
        public string UserName {
            get; private set;
        }

        /// <summary>
        /// Deprecated. The job title of the user.
        /// </summary>
        [Obsolete("Deprecated since v4.18.0")]
        public string Title {
            get; set;
        }

        /// <summary>
        /// The phone number of the user. Might be used to receive one-time passwords, e.g. when accessing shares.
        /// </summary>
        public string Phone {
            get; set;
        }

        /// <summary>
        /// The optional date when the user should expire (and will be deleted from DRACOON).
        /// </summary>
        public DateTime? ExpireAt {
            get; set;
        }

        /// <summary>
        /// The optional language of notifications the user will receive.
        /// </summary>
        public CultureInfo ReceiverLanguage {
            get; set;
        }

        /// <summary>
        /// The (unique) email address of the user.
        /// </summary>
        public string Email {
            get; private set;
        }

        /// <summary>
        /// Set to <c>true</c> to send an initial welcome mail to the user.
        /// </summary>
        public bool NotifyUser {
            get; set;
        }

        /// <summary>
        /// The information how the user will authenticate against DRACOON.
        /// </summary>
        public UserAuthData AuthData {
            get; private set;
        } = new UserAuthData();

        /// <summary>
        /// Optional flag to check whether the user has the non-member-viewer role by default.
        /// </summary>
        public bool IsNonmemberViewer {
            get; set;
        }

        /// <summary>
        /// Initialize request to create a new user in DRACOON.
        /// </summary>
        /// <param name="userName"><see cref="UserName"/></param>
        /// <param name="firstName"><see cref="FirstName"/></param>
        /// <param name="lastName"><see cref="LastName"/></param>
        /// <param name="email"><see cref="Email"/></param>
        public CreateUserRequest(string userName, string firstName, string lastName, string email) {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        /// <summary>
        /// Set basic authentication information for the new user.
        /// </summary>
        /// <param name="password">The user's initial password.</param>
        /// <param name="mustChangePassword">Set to <c>true</c> to force the user to change its password after first login.</param>
        /// <remarks>Mutually exclusive to <see cref="SetOpenIDAuth(string, int)"/> and <see cref="SetActiveDirectoryAuth(string, int)"/>.</remarks>
        public void SetBasicAuth(string password, bool mustChangePassword = true) {
            AuthData.Method = UserAuthMethod.Basic;
            AuthData.Login = null;
            AuthData.Password = password;
            AuthData.MustChangePassword = mustChangePassword;
            AuthData.OIDConfigId = null;
            AuthData.ADConfigId = null;
        }

        /// <summary>
        /// Set OpenID authentication information for the new user.
        /// </summary>
        /// <param name="openIdLogin">The user's OpenID username.</param>
        /// <param name="openIDConfigId">The internal ID of the OpenID configuration in DRACOON that should be used for authentication.</param>
        /// <remarks>Mutually exclusive to <see cref="SetBasicAuth(string, bool)"/> and <see cref="SetActiveDirectoryAuth(string, int)"/>.</remarks>
        public void SetOpenIDAuth(string openIdLogin, int openIDConfigId) {
            AuthData.Method = UserAuthMethod.OpenID;
            AuthData.Login = openIdLogin;
            AuthData.Password = null;
            AuthData.MustChangePassword = false;
            AuthData.OIDConfigId = openIDConfigId;
            AuthData.ADConfigId = null;
        }

        /// <summary>
        /// Set Active Directory authentication information for the new user.
        /// </summary>
        /// <param name="adLogin">The user's AD username.</param>
        /// <param name="adConfigId">The internal ID of the Active Directory configuration in DRACOON that should be used for authentication.</param>
        /// <remarks>Mutualy exclusive to <see cref="SetBasicAuth(string, bool)"/> and <see cref="SetOpenIDAuth(string, int)"/>.</remarks>
        public void SetActiveDirectoryAuth(string adLogin, int adConfigId) {
            AuthData.Method = UserAuthMethod.ActiveDirectory;
            AuthData.Login = adLogin;
            AuthData.Password = null;
            AuthData.MustChangePassword = false;
            AuthData.OIDConfigId = null;
            AuthData.ADConfigId = adConfigId;
        }


    }
}
