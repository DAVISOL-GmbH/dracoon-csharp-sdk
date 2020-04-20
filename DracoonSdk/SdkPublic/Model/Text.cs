using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public class Text {

        public IEnumerable<Language> Languages { get; internal set; }

        public string Type { get; internal set; }
    }
}
