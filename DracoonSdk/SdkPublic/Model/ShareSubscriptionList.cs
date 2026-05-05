
namespace Dracoon.Sdk.Model {
    /// <summary>
    ///     This model stores a list of upload or download share subscriptions. The list may be a paginated response. Implements the <see cref="RangeListBase{T}"/> collection base class.
    ///     <para>
    ///         <see cref="RangeListBase{T}.Offset"/> and <see cref="RangeListBase{T}.Limit"/> can be used to get the start and length of the page.
    ///     </para>
    /// </summary>
    public class ShareSubscriptionList : RangeListBase<ShareSubscription> {
    }
}
