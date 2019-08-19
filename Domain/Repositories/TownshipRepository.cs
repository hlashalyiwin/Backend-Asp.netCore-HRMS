using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_final_api.Domain.Repositories
{
    public class TownshipRepository : BaseRepository, ITownshipRepository
    {
         public TownshipRepository (AppDbContext context) : base (context) { }

        public async Task AddAsync(Township township)
        {
             await _context.Townships.AddAsync (township);
        }

        public async Task<Township> FindByIdAsync(int id)
        {
            return await _context.Townships.FindAsync (id);
        }

        public async Task<IEnumerable<Township>> ListAsync()
        {
            return await _context.Townships.Include(p=>p.city).ToListAsync ();
        }

        public void Remove(Township township)
        {
             _context.Townships.Remove (township);
        }

        public void Update(Township township)
        {
         _context.Townships.Update (township);
        }
    }
}