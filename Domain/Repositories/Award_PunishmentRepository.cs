using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Repositories;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace Hr_Management_final_api.Domain.Repositories
{
    //to mange data from databases.
    public class Award_PunishmentRepository : BaseRepository, IAward_PunishmentRepository
    {
          public Award_PunishmentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Award_Punishment award_punishment)
        {
            await _context.Award_Punishment.AddAsync(award_punishment);
        }

        public async Task<Award_Punishment> FindByIdAsync(int id)
        {
          
           var award_punishment=await _context.Award_Punishment.FindAsync(id);
           var employee=await _context.Employees.FindAsync(award_punishment.employee_id);
           var address=await _context.Addresses.FindAsync(employee.addressId);
        
          award_punishment.Employees=employee;
          employee.Addresses=address;
          
          return award_punishment;
        }

        public async Task<IEnumerable<Award_Punishment>> ListAsync()
        {
          return await _context.Award_Punishment.Include(p=>p.Employees).ThenInclude(p=>p.Addresses)
                                             .ToListAsync();          

        }

        public void Remove(Award_Punishment award_punishment)
        {
          _context.Award_Punishment.Remove(award_punishment); 

        }

        public void Update(Award_Punishment award_punishment)
        {
             _context.Award_Punishment.Update(award_punishment); 
        }
    }
}