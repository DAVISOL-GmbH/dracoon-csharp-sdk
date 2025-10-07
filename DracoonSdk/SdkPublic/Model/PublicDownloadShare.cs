using System;
using System.Collections.Generic;
using System.Text;

namespace Dracoon.Sdk.Model {
    public class PublicDownloadShare {
        public bool IsProtected { get; internal set; }

        public string FileName { get; internal set; }

        public long Size { get; internal set; }

        public bool LimitReached { get; internal set; }

        public string CreatorName { get; internal set; }

        public DateTime CreatedAt { get; internal set; }

        public bool HasDownloadLimit { get; internal set; }

        public string MediaType { get; internal set; }

        public string Name { get; internal set; }

        public string CreatorUsername { get; internal set; }

        public DateTime? ExpireAt { get; internal set; }

        public string Notes { get; internal set; }

        public bool? IsEncrypted { get; internal set; }
    }
}
