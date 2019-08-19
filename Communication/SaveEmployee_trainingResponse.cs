using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;
namespace Hr_Management_final_api.Communication
{
    public class SaveEmployee_trainingResponse: BaseResponse
    {
        public Employee_training Employee_training { get; private set; }

        private SaveEmployee_trainingResponse(bool success, string message, Employee_training employee_training) : base(success, message)
        {
            Employee_training = employee_training;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Employee_training">Saved Employee_training.</param>
        /// <returns>Response.</returns>
        public SaveEmployee_trainingResponse(Employee_training employee_training) : this(true, string.Empty, employee_training)
        { 
            Employee_training=employee_training;
        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  SaveEmployee_trainingResponse(string message) : this(false, message, null)
        { }
    }
}