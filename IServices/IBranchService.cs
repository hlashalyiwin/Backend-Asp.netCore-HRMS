using System.Collections.Generic;
using System.Threading.Tasks;
using HR_MANAGEMENT.Communication;
using Hr_Management_final_api.Domain.Models;

namespace HR_MANAGEMENT.IServices
{//return an enumeration of branch
    public interface IBranchService
    {
        Task<IEnumerable<Branch>> ListAsync();//return all branch data

        Task<Branch> GetByIdAsync(int id); //find by id for existing branch item                       
        Task<BranchResponse> SaveAsync(Branch branch); //add branch item   
        Task<BranchResponse> UpdateAsync(int id,Branch branch); //update branch item
        Task<BranchResponse> DeleteAsync(int id);  //delete branch item
    }
}