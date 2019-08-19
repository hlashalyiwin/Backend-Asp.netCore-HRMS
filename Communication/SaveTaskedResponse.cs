//Created by Sai Nay Lynn
//Created date is 21.6.2019


using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Communication {
    //This class is SaveTaskedResponse class. SaveTaskedResponse class is extends BaseResponse class
    public class SaveTaskedResponse : BaseResponse {
        //Tasked Method
        public Tasked Tasked { get; private set; }

        //SaveTaskedResponse class of Constructor, this constructor have three arguments success, message and shift
        private SaveTaskedResponse (bool success, string message, Tasked tasked) : base (success, message) {
            Tasked = tasked;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="tasked">Saved tasked.</param>
        /// <returns>Response.</returns>
        public SaveTaskedResponse (Tasked tasked) : this (true, string.Empty, tasked) { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveTaskedResponse (string message) : this (false, message, null) { }
    }
}