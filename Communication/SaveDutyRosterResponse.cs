
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Communication {
    public class SaveDutyRosterResponse : BaseResponse {
        public DutyRoster DutyRoster { get; private set; }

        private SaveDutyRosterResponse (bool success, string message, DutyRoster dutyRoster) : base (success, message) {
            DutyRoster = dutyRoster;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="point">Saved dutyRoster.</param>
        /// <returns>Response.</returns>
        public SaveDutyRosterResponse (DutyRoster dutyRoster) : this (true, string.Empty, dutyRoster) { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveDutyRosterResponse (string message) : this (false, message, null) { }
    }
}