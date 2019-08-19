using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
namespace EmployeeRole
{ //to manage data from databases.
     //21.6.2019
    //Authorized by NiNiWinMay
    public class EmployeeRoleRepository : BaseRepository, IEmployeeRoleRepository
    {
        public EmployeeRoleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EmployeeRoles>> ListAsync()
        {
              //
                                          
           // )
                                          
            return await _context.EmployeeRole.Include(p => p.Department).ThenInclude(p=>p.Branches).ThenInclude(p=>p.Addresses)  
                                              .Include(p => p.Role)
                                              .Include(p=>p.Employee).ThenInclude(p=>p.Addresses)
                                              .Include(p=>p.Ranks)
                                          .ToListAsync();
             
                                          
        }
        public async Task<EmployeeRoles> GetByIdAsync(int id){
            
            return await _context.EmployeeRole.FindAsync(id);
        }


        public async Task AddAsync(EmployeeRoles EmployeeRole)
	    {
		    await _context.EmployeeRole.AddAsync(EmployeeRole);
        }


        public async Task<EmployeeRoles> FindByIdAsync(int id)
        {
            var employeeRole= await _context.EmployeeRole.FindAsync(id);
            var role=await _context.Roles.FindAsync(employeeRole.roleid);
            var department=await _context.Departments.FindAsync(employeeRole.department_id);
            var employee=await _context.Employees.FindAsync(employeeRole.employee_id);
            var empAddress=await _context.Addresses.FindAsync(employee.addressId);
            var township=await _context.Townships.FindAsync(empAddress.township_Id);
            var city=await _context.Cities.FindAsync(township.city_Id);
           var rank=await _context.Ranks.FindAsync(employeeRole.rankId);
            var branch=await _context.Branchs.FindAsync(department.branch_id);
            var address=await _context.Addresses.FindAsync(branch.addressId);
        

             employeeRole.Role=role;
             employeeRole.Department=department;
             employeeRole.Ranks=rank;
             employeeRole.Employee=employee;
             employee.Addresses=empAddress;
            department.Branches=branch;
            branch.Addresses=address;

	        return employeeRole;
        }

        public void Update(EmployeeRoles EmployeeRole)
        {
            
	        _context.EmployeeRole.Update(EmployeeRole);
        }

        public void Remove(EmployeeRoles EmployeeRole)
        {
	        _context.EmployeeRole.Remove(EmployeeRole);

        }

        public async Task<IEnumerable<EmployeeRoles>> FindByDeptId(int deptId)
        {
           var empRole= await _context.EmployeeRole
                                          .Where(e=>e.end_date=="null")
                                          .Where(e => e.Department.dept_id ==deptId)
                                          .Where(e=>e.Employee.employee_state=="exist")
                                          .Include(d=>d.Employee)
                                          .Include(r=>r.Role)
                                          .Include(e=>e.Ranks)

                           .ToListAsync();
            return empRole;
        }
          public async Task<IEnumerable<EmployeeRoles>> FindByEmpId(int empId)
        {
           var empRole= await _context.EmployeeRole
                                          .Where(e=>e.end_date=="null")
                                          .Where(e => e.Employee.employeeId ==empId)
                                          .Where(e=>e.Employee.employee_state=="exist")
                                          .Include(e=>e.Department).ThenInclude(e=>e.Branches)
                                          .Include(d=>d.Employee)
                                          .Include(r=>r.Role)

                           .ToListAsync();
            return empRole;
        }
    }
}