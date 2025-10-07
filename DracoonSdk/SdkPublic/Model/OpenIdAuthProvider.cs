namespace Dracoon.Sdk.Model {
    /// <summary>
    /// OpenID Connect provider information
    /// </summary>
    public class OpenIdAuthProvider {

        /// <summary>
        /// ID
        /// </summary>
        public int Id {
            get; internal set;
        }

        /// <summary>
        /// Name of the IDP
        /// </summary>
        public string Name {
            get; internal set;
        }

        /// <summary>
        /// Is available for all customers
        /// </summary>
        public bool IsGlobalAvailable {
            get; internal set;
        }

        /// <summary>
        /// Issuer identifier of the IDP
        /// The value is a case sensitive URL.
        /// </summary>
        public string Issuer {
            get; internal set;
        }

        /// <summary>
        /// Name of the claim which is used for the user mapping.
        /// </summary>
        public string MappingClaim {
            get; internal set;
        }

        /// <summary>
        /// URL of the user management UI.
        /// Use empty string to remove.
        /// </summary>
        public string UserManagementUrl {
            get; internal set;
        }
    }
}
