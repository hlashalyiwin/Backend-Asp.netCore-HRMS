using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
namespace Hr_Management_final_api.Domain.Repositories
{
    //to mange data from databases.
    public class LeaveRepository : BaseRepository, ILeaveRepository
    {
          public LeaveRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Leave leave)
        {
            await _context.Leave.AddAsync(leave);
        }

        public async Task<Leave> FindByIdAsync(int id)
        {
          
           var leave=await _context.Leave.FindAsync(id);
           var employee=await _context.Employees.FindAsync(leave.employee_id);
           var address=await _context.Addresses.FindAsync(employee.addressId);
            employee.Addresses=address;
            leave.Employees=employee;
          
          return leave;
        }

        public async Task<IEnumerable<Leave>> ListAsync()
        {
          return await _context.Leave.Include(p=>p.Employees).ThenInclude(p=>p.Addresses)  
                                             .ToListAsync();          

        }

        public void Remove(Leave leave)
        {
          _context.Leave.Remove(leave); 

        }

        public void Update(Leave leave)
        {
             _context.Leave.Update(leave); 
        }
    }
}