using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync ();
        Task<User> GetByIdAsync (int id);
        Task<SaveUserResponse> SaveAsync (User user);
        Task<SaveUserResponse> UpdateAsync (int id, User user);
        Task<SaveUserResponse> DeleteAsync (int id); 
    }
}