

using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace HR_MANAGEMENT.Communication
{
    public class SaveAddressResponse: BaseResponse
    {
         public Address Address { get; private set; }

        private SaveAddressResponse(bool success, string message, Address address) : base(success, message)
        {
           Address = address;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="address">Saved shipping.</param>
        /// <returns>Response.</returns>
        public SaveAddressResponse( Address address) : this(true, string.Empty, address)
        { 
                  Address = address;
        }
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  SaveAddressResponse(string message) : this(false, message, null)
        { }
    
    }
}