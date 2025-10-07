using System;
using System.Collections.Generic;
using System.Text;

namespace Dracoon.Sdk.Model {
    public class PublicUploadShare {
        public bool IsProtected { get; internal set; }

        public DateTime CreatedAt { get; internal set; }

        public string Name { get; internal set; }

        public bool? IsEncrypted { get; internal set; }

        public DateTime? ExpireAt { get; internal set; }

        public string Notes { get; internal set; }

        public bool ShowUploadedFiles { get; internal set; }

        public long? RemainingSize { get; internal set; }

        public int? RemainingSlots { get; internal set; }

        public string CreatorName { get; internal set; }

        public string CreatorUsername { get; internal set; }

        public IEnumerable<PublicUploadedFileData> UploadedFiles { get; internal set; }
    }
}
