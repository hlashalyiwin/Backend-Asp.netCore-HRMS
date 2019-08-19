using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace Hr_Management_final_api.Domain.Repositories
{
     //to manage data from databases.
    public class AbsenceRepository : BaseRepository, IAbsenceRepository
    {
        public AbsenceRepository(AppDbContext context) : base(context)
        {
        }
        public async Task AddAsync(Absence absence)
        {
            await _context.Absences.AddAsync(absence);
        }

        public async Task<Absence> FindByIdAsync(int id)
        { 
          var absence=await _context.Absences.FindAsync(id);
          var employee=await _context.Employees.FindAsync(absence.employee_id);
          var rates=await _context.Rates.FindAsync(absence.rate_id);
          var address=await _context.Addresses.FindAsync(employee.addressId);
          absence.Employees=employee;
          absence.Rates=rates;
          employee.Addresses=address;
          return absence;   
        }
        public async Task<IEnumerable<Absence>> ListAsync()
        {
            return await _context.Absences.Include(p=>p.Employees).ThenInclude(p=>p.Addresses)
            .Include(p=>p.Rates)
            .ToListAsync();          

        }
        public void Remove(Absence absence)
        {
          _context.Absences.Remove(absence); 

        }

        public void Update(Absence absence)
        {
             _context.Absences.Update(absence); 
        }
         public async Task<IEnumerable<Absence>> FindByNameAsync(string name)
        {
           var absence= await _context.Absences
                                          .Where(e => e.Employees.employee_Name ==name)
                                        //   .Include(s => s.Employee)
                                        //           .ThenInclude(s=>s.Addresses)
                                        //   .Include(d=>d.Department)
                                          .Include(r=>r.Rates)

                           .ToListAsync();
            return absence;
        }
    }
} 