namespace Dracoon.Sdk.Model {
    /// <summary>
    /// Determines whether client is a confidential or public client.
    /// </summary>
    public enum OAuthClientType : int {
        Unknown = 0,

        Confidential = 1,

        Public = 2
    }
}
