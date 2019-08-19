using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Domain.IRepositories
{
     //21.6.2019
    //Authorized by NiNiWinMay
    public interface IEmployeeRoleRepository
    {//interface IEmployee_roleRepository for Employee_roleRepository
        Task<IEnumerable<EmployeeRoles>> ListAsync();
        Task AddAsync(EmployeeRoles employeeRole);
        Task<IEnumerable<EmployeeRoles>> FindByDeptId(int deptId);
          Task<IEnumerable<EmployeeRoles>> FindByEmpId(int empId);
        Task<EmployeeRoles> FindByIdAsync(int id);
	    void Update(EmployeeRoles employeeRole);
        void Remove(EmployeeRoles employeeRole);
    }
}