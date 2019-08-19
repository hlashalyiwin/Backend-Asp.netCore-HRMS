using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IServices
{
     //21.6.2019
    //Authorized by NiNiWinMay
    public interface IEmployeeRoleService
    {
          Task<IEnumerable<EmployeeRoles>> ListAsync();
         
         Task<EmployeeRoles> GetByIdAsync(int id);
         Task<IEnumerable<EmployeeRoles>> FindByDeptIdAsync(int deptId);
          Task<IEnumerable<EmployeeRoles>> FindByEmpId(int empId); 
         Task<SaveEmployeeRoleResponse> SaveAsync(EmployeeRoles EmployeeRole);
         Task<SaveEmployeeRoleResponse> UpdateAsync(int id, EmployeeRoles EmployeeRole);
         Task<SaveEmployeeRoleResponse> DeleteAsync(int id);
    }
}