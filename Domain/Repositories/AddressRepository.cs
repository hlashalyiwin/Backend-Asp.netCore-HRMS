using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace Hr_Management_final_api.Domain.Repositories
{
    //to manage data from databases.
    public class AddressRepository : BaseRepository, IAddressRepository
    {
        public AddressRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task AddAsync(Address address)
        {
            await _context.Addresses.AddAsync(address);
            _context.SaveChanges();
        }

        public async Task<Address> FindByIdAsync(int id)
        {
           return await _context.Addresses.FindAsync(id);
        }

        public async Task<IEnumerable<Address>> ListAsync()
        {
            return await _context.Addresses.Include(a=>a.Township).ThenInclude(a=>a.city).ToListAsync();          

        }

        public void Remove(Address address)
        {
          _context.Addresses.Remove(address); 

        }

        public void Update(Address address)
        {
             _context.Addresses.Update(address); 
        }
   }
}