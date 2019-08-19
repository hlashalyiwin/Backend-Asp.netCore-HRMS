
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace HR_MANAGEMENT.Communication
{
    public class SaveAnnouncementResponse : BaseResponse
    {
         public Announcement Announcement { get; private set; }

        private SaveAnnouncementResponse(bool success, string message, Announcement announcement) : base(success, message)
        {
           Announcement = announcement;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="address">Saved address.</param>
        /// <returns>Response.</returns>
        public SaveAnnouncementResponse( Announcement announcement) : this(true, string.Empty, announcement)
        { 
                  Announcement = announcement;
        }
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  SaveAnnouncementResponse(string message) : this(false, message, null)
        { }   
    }
}