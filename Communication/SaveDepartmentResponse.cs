using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Communication
{//
     public class SaveDepartmentResponse: BaseResponse
    {
         public Department Department { get; private set; }

        private SaveDepartmentResponse(bool success, string message,Department department) : base(success, message)
        {
           Department = department;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="employee">Saved shipping.</param>
        /// <returns>Response.</returns>
        public SaveDepartmentResponse(Department department) : this(true, string.Empty, department)
        { 
             Department = department;
        }
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  SaveDepartmentResponse(string message) : this(false, message, null)
        { }
    }
}