using Dracoon.Sdk.Filter;
using Dracoon.Sdk.Model;

namespace Dracoon.Sdk {
    public interface ISystemConfig {

        ServerGeneralConfiguration GetGeneralConfiguration();

        ServerGeneralConfiguration UpdateGeneralConfiguration(UpdateSystemGeneralConfigRequest updateRequest);


        //ServerInfrastructureSettings GetInfrastructure();

        ///// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iServerSettings"]/GetDefault/*'/>
        //ServerDefaultSettings GetDefault();

        ///// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iServerSettings"]/GetPasswordPolicies/*'/>
        //PasswordPolicies GetPasswordPolicies();

        ///// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iServerSettings"]/GetAvailableUserKeyPairAlgorithms/*'/>
        //List<UserKeyPairAlgorithmData> GetAvailableUserKeyPairAlgorithms();

        ///// <include file = "SdkPublicInterfacesDoc.xml" path='docs/members[@name="iServerSettings"]/GetAvailableFileKeyAlgorithms/*'/>
        //List<FileKeyAlgorithmData> GetAvailableFileKeyAlgorithms();

        #region Authentication related configuration

        ServerAuthenticationConfiguration GetAuthConfiguration();

        ActiveDirectoryConfigList GetAuthActiveDirectoryConfigurations();

        OpenIdIdpConfigList GetAuthOpenIdIdpConfigurations();

        RadiusConfig GetAuthRadiusConfiguration();

        #region OAuth Clients

        OAuthClientConfigList GetOAuthClientConfigurations(GetOAuthClientsFilter filter = null);

        OAuthClientConfiguration GetOAuthClientConfiguration(string clientId);

        OAuthClientConfiguration CreateOAuthClientConfiguration(CreateOAuthClientRequest createRequest);

        OAuthClientConfiguration UpdateOAuthClientConfiguration(string clientId, UpdateOAuthClientRequest updateRequest);

        void DeleteOAuthClientConfiguration(string clientId);

        #endregion

        #endregion

    }
}
