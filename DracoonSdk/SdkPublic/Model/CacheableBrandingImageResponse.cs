using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public class CacheableBrandingImageResponse {

        public string Type { get; internal set; }

        public IEnumerable<CacheableBrandingFileResponse> Files { get; internal set; }
    }
}
