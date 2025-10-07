using System;
using System.Collections.Generic;
using System.Text;

namespace Dracoon.Sdk.Model {
    /// <summary>
    /// Transports information about the policies of a room.
    /// </summary>
    public class RoomPolicies {

        /// <summary>
        /// The default policy room expiration period in seconds. All files in a room will have their expiration date set to this period after their respective upload.
        /// Existing files can be set to expire earlier afterwards.
        /// <para />
        /// <c>0</c> means no default expiration policy is set. This removes all expiration dates from existing files.
        /// </summary>
        public int DefaultExpirationPeriod { get; internal set; }

        /// <summary>
        /// Determines the status of room policy for virus-protection. Can be activated for unencrypted data rooms. If enabled, the files are sent to the German IT security company G DATA CyberDefense for verification.
        /// </summary>
        public bool VirusProtectionEnabled { get; internal set; }
    }
}
