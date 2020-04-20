using System.Globalization;

namespace Dracoon.Sdk.Model {
    public class Language {

        public string Content { get; internal set; }

        public CultureInfo LanguageTag { get; internal set; }
    }
}
