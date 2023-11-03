namespace Dracoon.Sdk.Model {
    public abstract class RangeListBase<T> : SimpleListBase<T> {

        /// <summary>
        ///     The index of the first returned item of the possible total list.
        /// </summary>
        public long Offset {
            get; internal set;
        }

        /// <summary>
        ///     The number of returned items.
        /// </summary>
        public long Limit {
            get; internal set;
        }

        /// <summary>
        ///     The total number of items which can be requested.
        /// </summary>
        public long Total {
            get; internal set;
        }
    }
}
