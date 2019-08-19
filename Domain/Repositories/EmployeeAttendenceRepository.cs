using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_final_api.Domain.Repositories
{ //to manage data from databases.
    public class EmployeeAttendenceRepository: BaseRepository, IEmployeeAttendenceRepository
    {
        public EmployeeAttendenceRepository(AppDbContext context) : base(context)
        {
        }
         // add new Department Item
        public async Task AddAsync(EmployeeAttendence employeeAttendence)
        {
           await _context.EmployeeAttendences.AddAsync(employeeAttendence);
        }
        // return  Department Data by id 
        public async Task<EmployeeAttendence> FindByIdAsync(int id)
        {
      
		
          var employeeAttendences=await _context.EmployeeAttendences.FindAsync(id);
          var attendence=await _context.Attendences.FindAsync(employeeAttendences.attendence_Id);
          var employee=await _context.Employees.FindAsync(attendence.empId);
          var address=await _context.Addresses.FindAsync(employee.addressId);
          var location=await _context.Locations.FindAsync(employeeAttendences.location_Id);
          attendence.Employees=employee;
          employee.Addresses=address;
          employeeAttendences.Attendences=attendence;
          employeeAttendences.locations=location;
         
          
          return employeeAttendences;
           
                  
        
        }
        // return All Employee Data
        public async Task<IEnumerable<EmployeeAttendence>> ListAsync()
        {
          return await _context.EmployeeAttendences .Include(p=>p.Attendences).ThenInclude(p=>p.Employees).ThenInclude(p=>p.Addresses) 
                                                    .Include(p=>p.locations) 
                                             .ToListAsync();
        }

        public void Remove(EmployeeAttendence employeeAttendence)
        {
             _context.EmployeeAttendences.Remove(employeeAttendence);
        }

        public void Update(EmployeeAttendence employeeAttendence)
        {
	        _context.EmployeeAttendences.Update(employeeAttendence);
        }
    }
        
    }
