using System;
using System.Collections.Generic;
using System.Text;

namespace Dracoon.Sdk.Model {
    public class PublicUploadedFileData {
        public string Name { get; internal set; }

        public long Size { get; internal set; }

        public DateTime CreatedAt { get; internal set; }

        public string Hash { get; internal set; }
    }
}
