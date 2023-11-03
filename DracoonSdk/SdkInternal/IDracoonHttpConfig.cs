using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dracoon.Sdk.SdkInternal {
    internal interface IDracoonHttpConfig {
        bool RetryEnabled { get; set; }
        int ConnectionTimeout { get; set; }
        IWebProxy WebProxy { get; set; }
        string UserAgent { get; set; }
        int ChunkSize { get; set; }
    }
}
