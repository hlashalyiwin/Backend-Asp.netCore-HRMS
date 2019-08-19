using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_final_api.Domain.Repositories
{
    public class RankRepository : BaseRepository, IRankRepository
    {
        public RankRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Rank rank)
        {
         await _context.Ranks.AddAsync(rank); 
        }

        public async Task<Rank> FindByIdAsync(int rankId)
        {
         return await _context.Ranks.FindAsync(rankId);    
        }

        public async Task<IEnumerable<Rank>> ListAsync()
        {
         return await _context.Ranks.ToListAsync();          
        }

        public void Remove(Rank rank)
        {
           _context.Ranks.Remove(rank); 
        }

        public void Update(Rank rank)
        {
           _context.Ranks.Update(rank);
        }
    }
}