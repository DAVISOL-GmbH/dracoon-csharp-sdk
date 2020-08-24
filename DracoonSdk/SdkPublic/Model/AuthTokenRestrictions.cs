namespace Dracoon.Sdk.Model {
    /// <include file = "ModelDoc.xml" path='docs/members[@name="authTokenRestrictions"]/AuthTokenRestrictions/*'/>
    public class AuthTokenRestrictions {

        /// <include file = "ModelDoc.xml" path='docs/members[@name="authTokenRestrictions"]/RestrictionEnabled/*'/>
        public bool RestrictionEnabled {
            get; internal set;
        }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="authTokenRestrictions"]/AccessTokenValidity/*'/>
        public int AccessTokenValidity {
            get; internal set;
        }

        /// <include file = "ModelDoc.xml" path='docs/members[@name="authTokenRestrictions"]/RefreshTokenValidity/*'/>
        public int RefreshTokenValidity {
            get; internal set;
        }
    }
}
