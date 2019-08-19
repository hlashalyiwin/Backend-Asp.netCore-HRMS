using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace Hr_Management_final_api.Domain.Repositories
{
    public class RoleRepository : BaseRepository, IRoleRepository
    { //to manage data from databases.
        public RoleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Role>> ListAsync()
        {
            return await _context.Roles.ToListAsync();
             
                                          
        }
        public async Task<Role> GetByIdAsync(int id){
            return await _context.Roles.FindAsync(id);
        }


        public async Task AddAsync(Role role)
	    {
		    await _context.Roles.AddAsync(role);
        }


        public async Task<Role> FindByIdAsync(int id)
        {
            var role= await _context.Roles.FindAsync(id);

            
	        return role;
        }

        public void Update(Role role)
        {
            
	        _context.Roles.Update(role);
        }

        public void Remove(Role role)
        {
	        _context.Roles.Remove(role);

        }
    }
}