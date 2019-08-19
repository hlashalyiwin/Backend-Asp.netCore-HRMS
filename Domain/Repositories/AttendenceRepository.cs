using System;
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
   public class AttendenceRepository: BaseRepository, IAttendenceRepository
    {
        public AttendenceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Attendence attendence)
        {
           await _context.Attendences.AddAsync(attendence);
        }

      
        public async Task<Attendence> FindByIdAsync(int id)
        {
             
          var attendence=await _context.Attendences.FindAsync(id);
          var employee=await _context.Employees.FindAsync(attendence.empId);
          var address=await _context.Addresses.FindAsync(employee.addressId);
           attendence.Employees=employee;
           employee.Addresses=address;
           return attendence;
        
        }

        public async Task<IEnumerable<Attendence>> FindByNameAsync(int month, int year)
        {
            int m = month;
            int y = year;
            var mm= await _context.Attendences.Where(s => s.date.Month>=month)
                                              .Where(s=>s.date.Year==year)
                                                  .Include(s => s.Employees)
                                                  .ThenInclude(s=>s.Addresses)
                           .ToListAsync();
          return mm; 

           
        }


        public async Task<IEnumerable<Attendence>> ListAsync()
        {
           return await _context.Attendences.Include(p =>p.Employees).ThenInclude(p => p.Addresses)
           
                                            .ToListAsync();
        }

        public void Remove(Attendence attendence)
        {
             _context.Attendences.Remove(attendence);
        }

        public void Update(Attendence attendence)
        {
	        _context.Attendences.Update(attendence);
        }

         public async Task<IEnumerable<Attendence>> FindByDayAsync(int day,int month,int year){
            int m = month;
            int y = year;
            int d=day;
            var mm=await _context.Attendences.Where(s => s.date.Day==day)
                                                .Where(s=>s.date.Month==month)
                                                .Where(s=>s.date.Year==year)
                                                .Include(s=>s.Employees)
                                                .ThenInclude(s=>s.Addresses).ToListAsync();
            return mm;
            
        }
          public async   Task<IEnumerable<Attendence>> FindByEmpId(int empId)
           {

            var mm=await _context.Attendences.Where(s=>s.Employees.employeeId==empId)
                                                .Include(s=>s.Employees)
                                                .ThenInclude(s=>s.Addresses).ToListAsync();
            return mm;
            
        }


    }  
}