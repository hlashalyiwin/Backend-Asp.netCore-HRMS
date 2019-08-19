using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Communication
{
    public class SaveUserResponse : BaseResponse 
    {
        //Shift Method
        public User User { get; private set; }

        //BaseRSaveShiftResponseesponse class of Constructor, this constructor have three arguments success, message and shift
        private SaveUserResponse (bool success, string message, User user) : base (success, message) {
            User=user;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="SignupForm">Saved shift.</param>
        /// <returns>Response.</returns>
        public SaveUserResponse ( User user) : this (true, string.Empty,  user) { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveUserResponse (string message) : this (false, message, null) { }
    
        
    }
    
}