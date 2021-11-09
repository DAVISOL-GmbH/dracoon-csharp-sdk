using System.Globalization;

namespace Dracoon.Sdk.Model {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class Language {

        public string Content { get; internal set; }

        public CultureInfo LanguageTag { get; internal set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
