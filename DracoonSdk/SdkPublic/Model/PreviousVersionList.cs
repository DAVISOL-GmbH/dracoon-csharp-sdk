namespace Dracoon.Sdk.Model {

    /// <summary>
    ///     This model stores a list of versioned nodes. The list may be a paginated response.
    ///     <para>
    ///         <see cref = "PreviousVersionList.Offset" /> and <see cref="PreviousVersionList.Limit"/> can be used to get the start and length of the page.
    ///     </para>
    /// </summary>
    public class PreviousVersionList : RangeListBase<PreviousVersion> {

    }
}