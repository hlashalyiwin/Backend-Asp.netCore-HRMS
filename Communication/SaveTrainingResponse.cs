using Hr_Management_final_api.Domain.Models;
namespace Hr_Management_final_api.Communication
{ 
    public class SaveTrainingResponse: BaseResponse
    {
        public Training Training { get; private set; }

        private SaveTrainingResponse(bool success, string message,Training training) : base(success, message)
        {
            Training = training;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="employee">Saved shipping.</param>
        /// <returns>Response.</returns>
        public SaveTrainingResponse(Training training) : this(true, string.Empty, training)
        { 
            Training = training;
        }
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  SaveTrainingResponse(string message) : this(false, message, null)
        { }
    }
    }
