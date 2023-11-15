using Dracoon.Sdk.SdkInternal;

namespace Dracoon.Sdk {
    /// <summary>
    /// The DracoonClientHelper static class provides helper functions for internal and external use.
    /// </summary>
    public static class DracoonClientHelper {

        /// <summary>
        /// Calculates the amount of time (in milliseconds) the internal client will wait after the n-th (indicated by <paramref name="indexOfRetry"/>) failed attempt of a single HTTP request.
        /// </summary>
        /// <param name="indexOfRetry">The current counter of retry attempts already taken to query a specific HTTP endpoint.</param>
        /// <returns>The default amount of time in milliseconds to wait before retrying the failed request.</returns>
        /// <remarks>
        /// The number of milliseconds is static for the first and second retry. For any further retry, the wait time is calculated using the Fibonacci sequence based on values for previous retries.
        /// </remarks>
        /// <example>
        /// <code>
        ///   var waitAfterFirstFailure = CalculateDefaultRetryWaitTime(0);
        ///   var waitAfterSecondFailure = CalculateDefaultRetryWaitTime(1);
        ///   // ...
        ///   var waitAfterSeventhFailure = CalculateDefaultRetryWaitTime(6);
        /// </code>
        /// </example>
        /// <seealso cref="SumDefaultRetryWaitTime(int)"/>
        public static int CalculateDefaultRetryWaitTime(int indexOfRetry) {
            if (indexOfRetry <= 0) {
                // first retry after 300 ms
                return InternalConstants.FirstClientRetryWaitTimeMs;
            } else if (indexOfRetry == 1) {
                // second retry after 500 ms
                return InternalConstants.SecondClientRetryWaitTimeMs;
            }

            // use Fibonacci for the third and any additional retry wait time (800ms, 1300ms, 2100ms, 3400ms, ...)
            return CalculateDefaultRetryWaitTime(indexOfRetry - 2) + CalculateDefaultRetryWaitTime(indexOfRetry - 1);
        }


        /// <summary>
        /// Sums the total wait time of the internal client (in milliseconds) applied for a single failed HTTP request with the specified <paramref name="numberOfRetries"/>.
        /// </summary>
        /// <param name="numberOfRetries">The total number of retries.</param>
        /// <returns>The total amount of milliseconds the internal client waited while retrying a failed request.</returns>
        /// <remarks>
        /// Instrumentates the <see cref="CalculateDefaultRetryWaitTime(int)"/> helper method to get the values to be summed.
        /// </remarks>
        /// <seealso cref="CalculateDefaultRetryWaitTime(int)"/>
        public static int SumDefaultRetryWaitTime(int numberOfRetries) {
            if (numberOfRetries <= 0) {
                return 0;
            }
            var totalWaitTime = 0;
            for (int i = 0; i < numberOfRetries; i++) {
                totalWaitTime += CalculateDefaultRetryWaitTime(i);
            }
            return totalWaitTime;
        }

    }
}
