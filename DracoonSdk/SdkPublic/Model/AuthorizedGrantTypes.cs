using System;

namespace Dracoon.Sdk.Model {
    /// <summary>
    /// <seealso href="https://tools.ietf.org/html/rfc6749"/>
    /// </summary>
    [Flags]
    public enum AuthorizedGrantTypes : int {
        None = 0,

        AuthorizationCode = 1 << 0,

        Implicit = 1 << 1,

        Password = 1 << 2,

        ClientCredentials = 1 << 3,

        RefreshToken = 1 << 4,
    }
}
