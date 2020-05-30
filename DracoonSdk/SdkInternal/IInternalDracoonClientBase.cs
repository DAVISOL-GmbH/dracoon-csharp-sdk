using System;
using Dracoon.Sdk.SdkInternal.OAuth;

namespace Dracoon.Sdk.SdkInternal {
    internal interface IInternalDracoonClientBase {
        Uri ServerUri { get; }
        IRequestBuilder Builder { get; }
        IRequestExecutor Executor { get; }
        IOAuth OAuth { get; }
        IDracoonHttpConfig HttpConfig { get; }
        ILog Log { get; }
    }
}
