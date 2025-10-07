using System;
using System.Collections.Generic;
using System.Text;

namespace Dracoon.Sdk.Model {
    /// <summary>
    /// Used to update the policies of a room.
    /// </summary>
    public class RoomPoliciesRequest {

        /// <summary>
        /// Default policy room expiration period in seconds. All files in a room will have their expiration date set to this period after their respective upload.
        /// Existing files can be set to expire earlier afterwards.
        /// <para />
        /// <c>0</c> means no default expiration policy is set. This removes all expiration dates from existing files.
        /// </summary>
        public int DefaultExpirationPeriod { get; private set; }

        /// <summary>
        /// Status of room policy for virus-protection. Can be activated for unencrypted data rooms. If enabled, the files are sent to the German IT security company G DATA CyberDefense for verification.
        /// </summary>
        public bool VirusProtectionEnabled { get; private set; }

        /// <summary>
        /// Constructs a room policies request object. See documentation of properties for enhanced information.
        /// </summary>
        /// <param name="defaultExpirationPeriod">Default policy room expiration period in seconds, <c>0</c> means no default expiration policy and removes all expiration dates from existing files.</param>
        /// <param name="virusProtectionEnabled">Defines whether virus protection is enabled for room.</param>
        public RoomPoliciesRequest(int defaultExpirationPeriod, bool virusProtectionEnabled) {
            DefaultExpirationPeriod = defaultExpirationPeriod;
            VirusProtectionEnabled = virusProtectionEnabled;
        }
    }
}
