
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace HR_MANAGEMENT.Communication
{
    public class BranchResponse : BaseResponse
    {
        public Branch branch { get; private set; }

        private BranchResponse(bool success, string message, Branch bbranch) : base(success, message)
        {
           branch = bbranch;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="mg mg">Saved Branch.</param>
        /// <returns>Response.</returns>
         public BranchResponse(Branch branch) : this(true, string.Empty, branch)
            { }
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
       public  BranchResponse(string message) : this(false, message, null)
        { }
    
    }
}