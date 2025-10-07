namespace Dracoon.Sdk.Model {
    /// <summary>
    /// Active Directory information
    /// </summary>
    public class ActiveDirectoryAuthProvider {

        /// <summary>
        /// ID
        /// </summary>
        public int Id {
            get; internal set;
        }

        /// <summary>
        /// Unique name for an Active Directory configuration
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
    }
}
