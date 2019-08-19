using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Communication
{
    public class SaveDutyRosterDetailResponse: BaseResponse
    {
         public DutyRosterDetail DutyRosterDetail { get; private set; }

        private SaveDutyRosterDetailResponse(bool success, string message,DutyRosterDetail dutyRosterDetail) : base(success, message)
        {
           DutyRosterDetail = dutyRosterDetail;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="employee">Saved shipping.</param>
        /// <returns>Response.</returns>
        public SaveDutyRosterDetailResponse(DutyRosterDetail dutyRosterDetail) : this(true, string.Empty, dutyRosterDetail)
        { 
            DutyRosterDetail = dutyRosterDetail;
        }
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  SaveDutyRosterDetailResponse(string message) : this(false, message, null)
        { }
    }
        
    }
