using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace HR_MANAGEMENT.IServices
{
    public interface IDepartmentService
    {
         Task<IEnumerable<Department>> ListAsync();                    //return all Department data
         
        Task<Department> GetByIdAsync(int id); 
        Task<IEnumerable<Department>> FindByBranchsId(int branchId);                        //add Department item
        Task<SaveDepartmentResponse> SaveAsync(Department department);    //find by id for existing Department item
        Task<SaveDepartmentResponse> UpdateAsync(int id,Department department);        //update Department item
        Task<SaveDepartmentResponse> DeleteAsync(int id);  
    }
}