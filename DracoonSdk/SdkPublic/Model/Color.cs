using System.Collections.Generic;

namespace Dracoon.Sdk.Model {
    public class Color {

        public IEnumerable<ColorDetails> ColorDetails { get; internal set; }

        public string Type { get; internal set; }
    }
}
