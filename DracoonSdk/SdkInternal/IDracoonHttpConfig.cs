using System.Net;

namespace Dracoon.Sdk.SdkInternal {
    internal interface IDracoonHttpConfig {

        bool RetryEnabled { get; set; }

        int MaxRetriesPerRequest { get; set; }

        int ConnectionTimeout { get; set; }

        IWebProxy WebProxy { get; set; }

        string UserAgent { get; set; }

        int ChunkSize { get; set; }
    }
}
