
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace HR_MANAGEMENT.Communication
{
    //return a resource
    public class SaveCV_FormResponse : BaseResponse
    {
        public CV_Form CV_Form { get; private set; }

        private SaveCV_FormResponse(bool success, string message, CV_Form cv_form) : base(success, message)
        {
            CV_Form = cv_form;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="role">Saved Attendence.</param>
        /// <returns>Response.</returns>
        public SaveCV_FormResponse(CV_Form cv_form) : this(true, string.Empty, cv_form)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveCV_FormResponse(string message) : this(false, message, null)
        { }
    }
}