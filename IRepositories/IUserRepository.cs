using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IRepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync ();
        Task AddAsync (User user);
        Task<User> FindByIdAsync (int id);
        void Update (User user);
        void Remove (User user); 
    }
}