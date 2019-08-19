using Hr_Management_final_api.Domain.Models;
namespace Hr_Management_final_api.Communication
{
    public class SaveCityResponse: BaseResponse
    {
         public City City { get; private set; }

        private SaveCityResponse(bool success, string message, City city) : base(success, message)
        {
           City = city;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="address">Saved address.</param>
        /// <returns>Response.</returns>
        public SaveCityResponse(  City city) : this(true, string.Empty, city)
        { 
                  City = city;
        }
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  SaveCityResponse(string message) : this(false, message, null)
        { }   
    }
}