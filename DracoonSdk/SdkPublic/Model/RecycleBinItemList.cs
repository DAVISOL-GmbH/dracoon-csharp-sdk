
namespace Dracoon.Sdk.Model {
    /// <summary>
    ///     This model stores a list of all nodes in the recycle bin of a room. The list may be a paginated response.
    ///     <para>
    ///         <see cref = "RecycleBinItemList.Offset" /> and <see cref="RecycleBinItemList.Limit"/> can be used to get the start and length of the page.
    ///     </para>
    /// </summary>
    public class RecycleBinItemList : RangeListBase<RecycleBinItem> {
    }
}