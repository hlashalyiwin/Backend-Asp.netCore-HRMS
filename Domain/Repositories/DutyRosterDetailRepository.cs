using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace Hr_Management_final_api.Domain.Repositories
{
    //to mange data from databases.
    public class DutyRosterDetailRepository : BaseRepository, IDutyRosterDetailRepository
    {
          public DutyRosterDetailRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(DutyRosterDetail dutyRosterDetail)
        {
            await _context.DutyRosterDetail.AddAsync(dutyRosterDetail);
        }

        public async Task<IEnumerable<DutyRosterDetail>> findByEmpId(int empId)
        {
           var shiftDetail= await _context.DutyRosterDetail.Where(d=>d.employee_id==empId)
           .Include(d=>d.DutyRosters.Shift)
           .ToListAsync();
           return shiftDetail;
        }

        public async Task<DutyRosterDetail> FindByIdAsync(int id)
        {
           var dutyRosterDetail= await _context.DutyRosterDetail.FindAsync(id);
           var employees=await _context.Employees.FindAsync(dutyRosterDetail.employee_id);
           var dutyRoster=await _context.DutyRoster.FindAsync(dutyRosterDetail.dutyRoster_id);
           var address=await _context.Addresses.FindAsync(employees.addressId);
           var shift=await _context.Shifts.FindAsync(dutyRoster.Shift_Id);
           dutyRoster.Shift=shift;
            employees.Addresses=address;
           dutyRosterDetail.Employees=employees;
           dutyRosterDetail.DutyRosters=dutyRoster;
           return dutyRosterDetail;
        }

        public async Task<IEnumerable<DutyRosterDetail>> ListAsync()
        {
                       
             await _context.DutyRosterDetail.Include(p=>p.Employees).ThenInclude(p=>p.Addresses)
            
                                      .ToListAsync();     
            return await _context.DutyRosterDetail.Include(p=>p.DutyRosters).ThenInclude(p=>p.Shift)
            
                                      .ToListAsync();      

        }

        public void Remove(DutyRosterDetail dutyRosterDetail)
        {
          _context.DutyRosterDetail.Remove(dutyRosterDetail); 

        }

        public void Update(DutyRosterDetail dutyRosterDetail)
        {
             _context.DutyRosterDetail.Update(dutyRosterDetail); 
        }
    }
}