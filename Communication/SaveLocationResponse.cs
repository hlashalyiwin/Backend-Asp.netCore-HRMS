using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Communication
{
    public class SaveLocationResponse: BaseResponse
    {
         public Location Location{ get; private set; }

        private SaveLocationResponse(bool success, string message, Location location) : base(success, message)
        {
           Location = location;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="leave">Saved shipping.</param>
        /// <returns>Response.</returns>
        public SaveLocationResponse(Location location) : this(true, string.Empty, location)
        { 
                  Location = location;
        }
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  SaveLocationResponse(string message) : this(false, message, null)
        { }
    
    }
    }
