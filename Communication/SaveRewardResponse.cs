using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Communication
{
    public class SaveRewardResponse:BaseResponse
    {
        public Reward Reward { get; private set; }

        private SaveRewardResponse(bool success, string message, Reward _reward) : base(success, message)
        {
            Reward = _reward;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Performance">Saved Performance.</param>
        /// <returns>Response.</returns>
        public SaveRewardResponse(Reward reward) : this(true, string.Empty, reward)
        {
            Reward = reward;
        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveRewardResponse(string message) : this(false, message, null)
        { }
    }
}
