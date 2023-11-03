using System;
using Dracoon.Sdk.SdkInternal.OAuth;

namespace Dracoon.Sdk.SdkInternal {
    /// <summary>
    /// Describes the most common properties of a client which connects to a DRACOON API.
    /// </summary>
    internal interface IInternalDracoonClientBase {
        
        /// <summary>
        ///     The used target server URI.
        /// </summary>
        Uri ServerUri { get; }
        
        IRequestBuilder Builder { get; }
        
        IRequestExecutor Executor { get; }
        
        IOAuth OAuth { get; }
        
        IDracoonHttpConfig HttpConfig { get; }
        
        ILog Log { get; }
    }
}
