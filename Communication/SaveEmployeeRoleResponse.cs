
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Communication

//21.6.2019
//authorized by Ni Ni Win May
{
    public class SaveEmployeeRoleResponse : BaseResponse
    {
        public EmployeeRoles EmployeeRole { get; private set; }

        private SaveEmployeeRoleResponse(bool success, string message, EmployeeRoles employeeRole) : base(success, message)
        {
            EmployeeRole = employeeRole;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="EmployeeRole">Saved EmplpoyeeRole.</param>
        /// <returns>Response.</returns>
        public SaveEmployeeRoleResponse(EmployeeRoles employeeRole) : this(true, string.Empty, employeeRole)
        { 
            EmployeeRole=employeeRole;
        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  SaveEmployeeRoleResponse(string message) : this(false, message, null)
        { }
    
    }
}