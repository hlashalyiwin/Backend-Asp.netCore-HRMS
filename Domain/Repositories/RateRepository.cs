
using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_final_api.Domain.Repositories
{ //to manage data from databases.
    public class RateRepository : BaseRepository, IRateRepository
    {
        public RateRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Rate rate)
        {
         await _context.Rates.AddAsync(rate); 
        }

        public async Task<Rate> FindByIdAsync(int rateId)
        {
         return await _context.Rates.FindAsync(rateId);    
        }

        public async Task<IEnumerable<Rate>> ListAsync()
        {
         return await _context.Rates.ToListAsync();          
        }

        public void Remove(Rate rate)
        {
           _context.Rates.Remove(rate); 
        }

        public void Update(Rate rate)
        {
           _context.Rates.Update(rate);
        }
    }
}