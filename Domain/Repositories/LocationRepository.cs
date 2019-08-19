using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_final_api.Domain.Repositories
{ //to manage data from databases.
    public class LocationRepository: BaseRepository, ILocationRepositories
    {
          public LocationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Location location)
        {
            await _context.Locations.AddAsync(location);
        }

        public async Task<Location> FindByIdAsync(int id)
        {
          
          return await _context.Locations.FindAsync(id);
          
        }

        public async Task<IEnumerable<Location>> ListAsync()
        {
          return await _context.Locations.ToListAsync();          

        }

        public void Remove(Location location)
        {
          _context.Locations.Remove(location); 

        }

        public void Update(Location location)
        {
             _context.Locations.Update(location); 
        }
    }
    }