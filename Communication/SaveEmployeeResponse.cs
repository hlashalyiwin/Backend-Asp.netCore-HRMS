

using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Communication
{//
    public class SaveEmployeeResponse: BaseResponse
    {
        public Employee Employee { get; private set; }

        private SaveEmployeeResponse(bool success, string message,Employee employee) : base(success, message)
        {
            Employee = employee;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="employee">Saved shipping.</param>
        /// <returns>Response.</returns>
        public SaveEmployeeResponse(Employee employee) : this(true, string.Empty, employee)
        { 
            Employee = employee;
        }
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  SaveEmployeeResponse(string message) : this(false, message, null)
        { }
    }
}