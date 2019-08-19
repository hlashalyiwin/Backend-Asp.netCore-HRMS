//Developed by Nang Ah: Mon(Lashio)


using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Communication
{//SaveProduct_Performance_Response class
    public class SaveProduct_Performance_Response : BaseResponse
    {
        public Product_Performance ProductPerformance { get; private set; }

        private SaveProduct_Performance_Response(bool success, string message, Product_Performance productPerformance) : base(success, message)
        {
           ProductPerformance = productPerformance;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="address">Saved address.</param>
        /// <returns>Response.</returns>
        public SaveProduct_Performance_Response( Product_Performance productPerformance) : this(true, string.Empty, productPerformance)
        { 
                  ProductPerformance = productPerformance;
        }
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  SaveProduct_Performance_Response(string message) : this(false, message, null)
        { }
    }
}