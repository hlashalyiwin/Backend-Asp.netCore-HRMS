using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IRepositories
{
    public interface IRoleRepository
    {//interface IRoleRepository for RoleRepository
        Task<IEnumerable<Role>> ListAsync();
        Task AddAsync(Role role);
        
        Task<Role> FindByIdAsync(int id);
	    void Update(Role role);
        void Remove(Role role);  
    }
}