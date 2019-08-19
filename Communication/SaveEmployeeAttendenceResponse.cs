using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Communication
{
    public class SaveEmployeeAttendenceResponse : BaseResponse
    {
    
        public EmployeeAttendence EmployeeAttendence { get; private set; }

        private SaveEmployeeAttendenceResponse(bool success, string message,EmployeeAttendence employeeAttendence) : base(success, message)
        {
           EmployeeAttendence = employeeAttendence;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="employee">Saved shipping.</param>
        /// <returns>Response.</returns>
        public SaveEmployeeAttendenceResponse(EmployeeAttendence employeeAttendence) : this(true, string.Empty, employeeAttendence)
        { 
               EmployeeAttendence = employeeAttendence;
        }
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  SaveEmployeeAttendenceResponse(string message) : this(false, message, null)
        { }
    }
    }
