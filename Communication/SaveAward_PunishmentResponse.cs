
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace HR_MANAGEMENT.Communication
{
    public class SaveAward_PunishmentResponse : BaseResponse
    {
        public Award_Punishment Award_Punishment { get; private set; }

        private SaveAward_PunishmentResponse(bool success, string message, Award_Punishment award_punishment) : base(success, message)
        {
            Award_Punishment = award_punishment;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="award_punishment">Saved award_punishment.</param>
        /// <returns>Response.</returns>
        public SaveAward_PunishmentResponse(Award_Punishment award_punishment) : this(true, string.Empty, award_punishment)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveAward_PunishmentResponse(string message) : this(false, message, null)
        { }
    }
}
