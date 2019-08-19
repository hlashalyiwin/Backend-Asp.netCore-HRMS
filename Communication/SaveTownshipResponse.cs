using Hr_Management_final_api.Domain.Models;
namespace Hr_Management_final_api.Communication
{
    public class SaveTownshipResponse : BaseResponse
    {
        public Township TownShip { get; private set; }

        private SaveTownshipResponse(bool success, string message,Township townShip) : base(success, message)
        {
           TownShip = townShip;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="rate">Saved shipping.</param>
        /// <returns>Response.</returns>
        public SaveTownshipResponse(Township township) : this(true, string.Empty, township)
        { 
            TownShip = township;
        }
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  SaveTownshipResponse(string message) : this(false, message, null)
        { } 
    }
}