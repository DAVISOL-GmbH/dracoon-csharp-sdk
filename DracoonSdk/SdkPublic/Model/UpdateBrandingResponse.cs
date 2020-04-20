using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public class UpdateBrandingResponse {

        public string AppearanceLoginBox { get; internal set; }

        public bool ColorizeHeader { get; internal set; }

        public IEnumerable<Color> Colors { get; internal set; }

        public string EmailContact { get; internal set; }

        public string EmailSender { get; internal set; }

        public IEnumerable<SimpleImageResponse> Images { get; internal set; }

        public string ImprintUrl { get; internal set; }

        public int PositionLoginBox { get; internal set; }

        public string PrivacyUrl { get; internal set; }

        public string ProductName { get; internal set; }

        public string SupportUrl { get; internal set; }

        public IEnumerable<Text> Texts { get; internal set; }
    }
}
