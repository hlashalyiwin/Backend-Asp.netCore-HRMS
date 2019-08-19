using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IRepositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> ListAsync();    //return all department data
        Task AddAsync(Department department);           //add department item
        Task<IEnumerable<Department>> FindByBranchId(int branchId);
        
        Task<Department> FindByIdAsync(int id);       //find by id for existing department item
	    void Update(Department department);             //update department item
        void Remove(Department department); 
    }
}