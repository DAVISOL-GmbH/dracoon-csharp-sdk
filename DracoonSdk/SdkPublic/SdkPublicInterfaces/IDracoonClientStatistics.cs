using System;
using System.Collections.Generic;
using System.Text;

namespace Dracoon.Sdk.SdkPublic.SdkPublicInterfaces {
    
    /// <summary>
    /// Describes the DRACOON client statistics module which counts successful and failed requests against the API.
    /// </summary>
    public interface IDracoonClientStatistics {

        /// <summary>
        /// The number of unique requests (all requests excluding retries). Sum of <see cref="UniqueRequestsSucceeded"/> and <see cref="UniqueRequestsFailed"/>.
        /// </summary>
        int UniqueRequests { get; }

        /// <summary>
        /// The number of finally succeeded unique requests (including requests which have failed but retried successfully).
        /// </summary>
        int UniqueRequestsSucceeded { get; }

        /// <summary>
        /// The number of finally failed unique requests (not retried successfully).
        /// </summary>
        int UniqueRequestsFailed { get; }

        /// <summary>
        /// The total number of requests send to the API. Might be larger than <see cref="UniqueRequests"/> if failed requests are retried internally.
        /// </summary>
        int EffectiveApiRequests { get; }

        /// <summary>
        /// The number of requests (incl. retries) that failed with a 5091 SERVER_UNAVAILABLE error.
        /// </summary>
        int FailedUnavailable { get; }

        /// <summary>
        /// The number of requests (incl. retries) that failed with a 5092 SERVER_BAD_GATEWAY error.
        /// </summary>
        int FailedBadGateway { get; }

        /// <summary>
        /// The number of requests (incl. retries) that failed with a 5093 SERVER_GATEWAY_TIMEOUT error.
        /// </summary>
        int FailedGatewayTimeout { get; }

        /// <summary>
        /// The number of requests (incl. retries) that failed with a 5094 SERVER_MAINTENANCE error.
        /// </summary>
        int FailedMaintenance { get; }

        /// <summary>
        /// The number of requests (incl. retries) that failed with an unknown reason.
        /// </summary>
        int FailedUnknownReason { get; }

        /// <summary>
        /// The total number of failed requests (incl. retries). Represents the sum of <see cref="FailedUnavailable"/>, <see cref="FailedBadGateway"/>, <see cref="FailedGatewayTimeout"/>, <see cref="FailedMaintenance"/> and <see cref="FailedUnknownReason"/>.
        /// </summary>
        int TotalFailures { get; }

        /// <summary>
        /// The total number of internal retries.
        /// </summary>
        int TotalRetries { get; }

        /// <summary>
        /// The highest number of retries taken for a unique request.
        /// </summary>
        int MaxRetryCountPerRequest { get; }

        /// <summary>
        /// The total amount of milliseconds taken to perform the HTTP requests (incl. retries, excluding any client side processing or wait time).
        /// </summary>
        long TotalRequestExecutionTimeMs { get; }

        /// <summary>
        /// The total amount of milliseconds the client has waited before retrying failed requests.
        /// </summary>
        long TotalRetryWaitTimeMs { get; }

        /// <summary>
        /// Reset all counters.
        /// </summary>
        void ResetStatistics();
    }
}
