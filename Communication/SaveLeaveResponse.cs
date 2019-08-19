
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Communication
{
   //return a resource
          public class SaveLeaveResponse: BaseResponse
    {
         public Leave Leave{ get; private set; }

        private SaveLeaveResponse(bool success, string message, Leave leave) : base(success, message)
        {
           Leave = leave;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="leave">Saved shipping.</param>
        /// <returns>Response.</returns>
        public SaveLeaveResponse( Leave leave) : this(true, string.Empty, leave)
        { 
                  Leave = leave;
        }
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  SaveLeaveResponse(string message) : this(false, message, null)
        { }
    
    }
    }
