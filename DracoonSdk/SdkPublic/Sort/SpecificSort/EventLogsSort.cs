namespace Dracoon.Sdk.Sort {
    public class EventLogsSort : DracoonSort {

        public static TimeSort<EventLogsSort> Time => new TimeSort<EventLogsSort>(new EventLogsSort());
    }
}
