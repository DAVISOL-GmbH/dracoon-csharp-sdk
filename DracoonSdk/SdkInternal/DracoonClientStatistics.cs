using Dracoon.Sdk.Error;
using Dracoon.Sdk.SdkPublic.SdkPublicInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dracoon.Sdk.SdkInternal {
    internal class DracoonClientStatistics : IDracoonClientStatistics {

        public int UniqueRequests => UniqueRequestsSucceeded + UniqueRequestsFailed;

        public int UniqueRequestsSucceeded { get; internal set; }

        public int UniqueRequestsFailed { get; internal set; }

        public int EffectiveApiRequests { get; internal set; }

        public int FailedUnavailable { get; internal set; }

        public int FailedBadGateway { get; internal set; }

        public int FailedGatewayTimeout { get; internal set; }

        public int FailedMaintenance { get; internal set; }

        public int FailedUnknownReason { get; internal set; }

        public int TotalFailures => FailedUnavailable + FailedBadGateway + FailedGatewayTimeout + FailedMaintenance + FailedUnknownReason;

        public int TotalRetries { get; internal set; }

        public int MaxRetryCountPerRequest { get; internal set; }

        public long TotalRequestExecutionTimeMs { get; internal set; }

        public long TotalRetryWaitTimeMs { get; internal set; }

        public void ResetStatistics() {
            UniqueRequestsSucceeded = 0;
            UniqueRequestsFailed = 0;
            EffectiveApiRequests = 0;
            FailedUnavailable = 0;
            FailedBadGateway = 0;
            FailedGatewayTimeout = 0;
            FailedMaintenance = 0;
            FailedUnknownReason = 0;
            TotalRetries = 0;
            MaxRetryCountPerRequest = 0;
            TotalRequestExecutionTimeMs = 0;
            TotalRetryWaitTimeMs = 0;
        }

        internal void UpdateFromException(DracoonApiException dae) {
            if (dae is null) {
                return;
            }
            if (dae.ErrorCode != null) {
                if (dae.ErrorCode.Code == DracoonApiCode.SERVER_UNAVAILABLE.Code) {
                    FailedUnavailable++;
                    return;
                }
                if (dae.ErrorCode.Code == DracoonApiCode.SERVER_BAD_GATEWAY.Code) {
                    FailedBadGateway++;
                    return;
                }
                if (dae.ErrorCode.Code == DracoonApiCode.SERVER_GATEWAY_TIMEOUT.Code) {
                    FailedGatewayTimeout++;
                    return;
                }
                if (dae.ErrorCode.Code == DracoonApiCode.SERVER_MAINTENANCE.Code) {
                    FailedMaintenance++;
                    return;
                }
            }

            FailedUnknownReason++;
        }

        internal void UpdateForRetry(int sendTry, int retryAfter) {
            TotalRetries++;
            MaxRetryCountPerRequest = Math.Max(MaxRetryCountPerRequest, sendTry + 1);
            TotalRetryWaitTimeMs += retryAfter;
        }
    }
}
