//Created by Soe Min Thu
//Created date is 21.6.2019


using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Communication {
    //This class is SaveShiftResponse class. SaveShiftResponse class is extends BaseResponse class
    public class SaveShiftResponse : BaseResponse {
        //Shift Method
        public Shift Shift { get; private set; }

        //BaseRSaveShiftResponseesponse class of Constructor, this constructor have three arguments success, message and shift
        private SaveShiftResponse (bool success, string message, Shift shift) : base (success, message) {
            Shift = shift;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="shift">Saved shift.</param>
        /// <returns>Response.</returns>
        public SaveShiftResponse (Shift shift) : this (true, string.Empty, shift) { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveShiftResponse (string message) : this (false, message, null) { }
    }
}