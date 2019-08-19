using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Communication
{
    public class SaveRoleResponse: BaseResponse
    {
         public Role Role{ get; private set; }

        private SaveRoleResponse(bool success, string message, Role role) : base(success, message)
        {
           Role = role;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="leave">Saved shipping.</param>
        /// <returns>Response.</returns>
        public SaveRoleResponse(Role role) : this(true, string.Empty, role)
        { 
                  Role = role;
        }
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  SaveRoleResponse(string message) : this(false, message, null)
        { }
    
    }
    }
