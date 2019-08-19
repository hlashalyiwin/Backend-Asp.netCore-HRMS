
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;
namespace HR_MANAGEMENT.Communication
{
    //return a resource
    public class SaveAttendenceResponse : BaseResponse
    {
        public Attendence attendence { get; private set; }

        private SaveAttendenceResponse(bool success, string message, Attendence attend) : base(success, message)
        {
            attendence = attend;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="role">Saved Attendence.</param>
        /// <returns>Response.</returns>
        public SaveAttendenceResponse(Attendence attendence) : this(true, string.Empty, attendence)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveAttendenceResponse(string message) : this(false, message, null)
        { }
    
    
        
    }
}