using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_final_api.Domain.Repositories
{ //to manage data from databases.
    public class PerformanceRepository : BaseRepository,IPerformanceRepository
    {
        public PerformanceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Performance>> ListAsync()
        {
            await _context.Performance.Include(p=>p.Employee).ThenInclude(p=>p.Addresses)
                                                 .ToListAsync(); 
            await _context.Performance.Include(p=>p.Task)
                                            .ToListAsync();
            return  await _context.Performance.Include(p=>p.Reward)
                                                 .ToListAsync();                             
        

        }
        public async Task<Performance> GetByIdAsync(int id)
        {
            return await _context.Performance.FindAsync(id);
        }


        public async Task AddAsync(Performance per)
        {
            await _context.Performance.AddAsync(per);
        }
        

        public void Update(Performance per)
        {

            _context.Performance.Update(per);
        }

        public void Remove(Performance per)
        {
            _context.Performance.Remove(per);

        }

        public async Task<Performance> FindByIdAsync(int id)
        {
            var performance= await _context.Performance.FindAsync(id);
            var employee=await _context.Employees.FindAsync(performance.employee_id);
          var tasked=await _context.Tasked.FindAsync(performance.task_id);
          var reward=await _context.Reward.FindAsync(performance.reward_id);
          var address=await _context.Addresses.FindAsync(employee.addressId);
          employee.Addresses=address;
          performance.Employee=employee;
          performance.Task=tasked;
          performance.Reward=reward;
          return performance;
        }
    }
}
