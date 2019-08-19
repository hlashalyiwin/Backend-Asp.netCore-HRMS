using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_final_api.Domain.Repositories
{ //to manage data from databases.
    public class DepartmentRepository: BaseRepository, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context) : base(context)
        {
        }
         // add new Department Item
        public async Task AddAsync(Department department)
        {
           await _context.Departments.AddAsync(department);
        }

        public async Task<IEnumerable<Department>> FindByBranchId(int branchId)
        {
           var dep=await _context.Departments.Where(e=>e.Branches.Id==branchId)
           .Include(e=>e.Branches).ToListAsync();
           return dep;
        }

        // return  Department Data by id 
        public async Task<Department> FindByIdAsync(int id)
        {
      
		
          var department=await _context.Departments.FindAsync(id);
          var branch=await _context.Branchs.FindAsync(department.branch_id);
          var address=await _context.Addresses.FindAsync(branch.addressId);
          department.Branches=branch;
          branch.Addresses=address;
          return department;
           
                  
        
        }
        // return All Employee Data
        public async Task<IEnumerable<Department>> ListAsync()
        {
          return await _context.Departments  .Include(p=>p.Branches).ThenInclude(p=>p.Addresses)  
                                             .ToListAsync();
        }

        public void Remove(Department department)
        {
             _context.Departments.Remove(department);
        }

        public void Update(Department department)
        {
	        _context.Departments.Update(department);
        }
    }
}