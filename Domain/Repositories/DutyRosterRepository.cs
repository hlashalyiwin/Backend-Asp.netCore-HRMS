using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_final_api.Domain.Repositories
{ //to manage data from databases.
    public class DutyRosterRepository: BaseRepository, IDutyRosterRepository
    {
        public DutyRosterRepository(AppDbContext context) : base(context)
        {
        }
         // add new DutyRoster Item
        public async Task AddAsync(DutyRoster dutyRoster)
        {
           await _context.DutyRoster.AddAsync(dutyRoster);
        }
        // return  DutyRoster Data by id 
        public async Task<DutyRoster> FindByIdAsync(int id)
        {
      
		var dutyRoster= await _context.DutyRoster.FindAsync(id);
        var shift= await _context.Shifts.FindAsync(dutyRoster.Shift_Id);

        dutyRoster.Shift=shift;
        return dutyRoster;   
                  
        
        }
        // return All DutyRoster Data
        public async Task<IEnumerable<DutyRoster>> ListAsync()
        { 
          return await _context.DutyRoster  .Include(p=>p.Shift)
                                             .ToListAsync();
        }

       

        public void Remove(DutyRoster dutyRoster)
        {
             _context.DutyRoster.Remove(dutyRoster);
        }

       

        public void Update(DutyRoster dutyRoster)
        {
            _context.DutyRoster.Update(dutyRoster);
        }
    }
}