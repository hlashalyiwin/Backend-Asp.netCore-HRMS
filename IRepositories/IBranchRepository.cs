using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IRepositories
{
    public interface IBranchRepository
    {//interface IBranchRepository for BranchRepository
        Task<IEnumerable<Branch>> ListAsync();
	    Task AddAsync(Branch branch);

        Task<Branch> FindByIdAsync(int id);
	    void Update(Branch branch);
        void Remove(Branch branch);
    }
}