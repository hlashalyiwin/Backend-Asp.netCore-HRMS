using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;
namespace Hr_Management_final_api.IServices
{
    public interface IRoleService
    {
                 Task<IEnumerable<Role>> ListAsync();                    //return all role data

        Task<Role> GetByIdAsync(int id);                       //find by id for existing role item
        Task<SaveRoleResponse> SaveAsync(Role role);    //add role item
        Task<SaveRoleResponse> UpdateAsync(int id,Role role);        //update role item
        Task<SaveRoleResponse> DeleteAsync(int id); //delete role item 
    }
}