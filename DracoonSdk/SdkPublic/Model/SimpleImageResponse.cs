using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public class SimpleImageResponse {

        public string Type { get; internal set; }

        public IEnumerable<ImageFileResponse> Files { get; internal set; }
    }
}
