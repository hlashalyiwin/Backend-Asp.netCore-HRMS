

using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Communication
{
    public class SaveRateResponse: BaseResponse
    {
         public Rate Rate { get; private set; }

        private SaveRateResponse(bool success, string message,Rate rate) : base(success, message)
        {
           Rate = rate;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="rate">Saved shipping.</param>
        /// <returns>Response.</returns>
        public SaveRateResponse(Rate rate) : this(true, string.Empty, rate)
        { 
            Rate = rate;
        }
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  SaveRateResponse(string message) : this(false, message, null)
        { }
    }
}