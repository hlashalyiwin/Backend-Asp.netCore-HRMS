using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Communication
{
    public class SaveRankResponse : BaseResponse
    {
        public Rank Rank { get; private set; }

        private SaveRankResponse(bool success, string message,Rank rank) : base(success, message)
        {
           Rank = rank;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="rate">Saved shipping.</param>
        /// <returns>Response.</returns>
        public SaveRankResponse(Rank rank) : this(true, string.Empty, rank)
        { 
            Rank = rank;
        }
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  SaveRankResponse(string message) : this(false, message, null)
        { } 
    }
}