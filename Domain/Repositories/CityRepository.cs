using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_final_api.Domain.Repositories
{
    public class CityRepository : BaseRepository, ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(City city)
        {
            await _context.Cities.AddAsync(city);
        }

        public async Task<City> FindByIdAsync(int id)
        {
          var city=await _context.Cities.FindAsync(id);
          return city;
        }

        public async Task<IEnumerable<City>> ListAsync()
        {
            return await _context.Cities.ToListAsync();    
        }

        public void Remove(City branch)
        {
          _context.Cities.Remove(branch); 

        }
        public void Update(City branch)
        {
             _context.Cities.Update(branch); 
        }
    }
}