
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace HR_MANAGEMENT.Communication
{
    public class SaveAbsenceResponse: BaseResponse
    {
         public Absence Absence { get; private set; }

        private SaveAbsenceResponse(bool success, string message, Absence absence) : base(success, message)
        {
           Absence = absence;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="address">Saved shipping.</param>
        /// <returns>Response.</returns>
        public SaveAbsenceResponse(Absence absence) : this(true, string.Empty,absence)
        { 
                  Absence = Absence;
        }
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  SaveAbsenceResponse(string message) : this(false, message, null)
        { }
    
    }
}