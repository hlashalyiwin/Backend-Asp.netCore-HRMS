using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Microsoft.EntityFrameworkCore;

 //to manage data from databases.
namespace Hr_Management_final_api.Domain.Repositories
{
    //implements IEmployeeRepository ,extends BaseRepository
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }

        
        // return All Employee Data
        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return await _context.Employees .Where(e=>e.employee_state=="exist") .Include(p=>p.Addresses)  
                                             .ToListAsync();
        }

        // return  Employee Data by id 
        public async Task<Employee> GetByIdAsync(int id)
        {            
            return await _context.Employees.FindAsync(id);
        }

        // add new Employee Item
        public async Task AddAsync(Employee employee)
	    {
		    await _context.Employees.AddAsync(employee);
        }

        // find by employee id
        public async Task<Employee> FindByIdAsync(int id)
        { 
          var employee=await _context.Employees.FindAsync(id);
          var address=await _context.Addresses.FindAsync(employee.addressId);
          employee.Addresses=address;
          return employee;

        }

        // update existing Employee data
        public void Update(Employee employee)
        {
            
	        _context.Employees.Update(employee);
        }

        // delete existing employee data
        public void Remove(Employee employee)
        {
	        _context.Employees.Remove(employee);

        }  
    }
}