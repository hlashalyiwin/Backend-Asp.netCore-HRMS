
using Hr_Management_final_api.Domain.Models;


namespace Hr_Management_final_api.Communication
{
    //return a resource
    public class SaveServicePerformanceResponse: BaseResponse
    {
         public ServicePerformance ServicePerformance { get; private set; }

        private SaveServicePerformanceResponse(bool success, string message, ServicePerformance address) : base(success, message)
        {
           ServicePerformance = address;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="address">Saved address.</param>
        /// <returns>Response.</returns>
        public SaveServicePerformanceResponse(ServicePerformance address) : this(true, string.Empty, address)
        { 
                  ServicePerformance = address;
        }
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  SaveServicePerformanceResponse(string message) : this(false, message, null)
                
        { }
    
    }
}