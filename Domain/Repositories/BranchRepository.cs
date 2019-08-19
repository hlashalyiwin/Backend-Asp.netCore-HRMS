
using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;


namespace Hr_Management_final_api.Domain.Repositories
{ //to manage data from databases.
    public class BranchRepository : BaseRepository, IBranchRepository
    {
        public BranchRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Branch branch)
        {
            await _context.Branchs.AddAsync(branch);
        }

        public async Task<Branch> FindByIdAsync(int id)
        {
          var branch=await _context.Branchs.FindAsync(id);
          var address=await _context.Addresses.FindAsync(branch.addressId);
          branch.Addresses=address;
          return branch;
        }

        public async Task<IEnumerable<Branch>> ListAsync()
        {
            return await _context.Branchs  .Include(p=>p.Addresses)  
                                             .ToListAsync();    
        }

        public void Remove(Branch branch)
        {
          _context.Branchs.Remove(branch); 

        }
        public void Update(Branch branch)
        {
             _context.Branchs.Update(branch); 
        }
    }
}