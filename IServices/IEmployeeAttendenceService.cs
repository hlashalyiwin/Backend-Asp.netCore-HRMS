using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IServices
{
    public interface IEmployeeAttendenceService
    {
         Task<IEnumerable<EmployeeAttendence>> ListAsync();                    //return all Department data
         
        Task<EmployeeAttendence> GetByIdAsync(int id);                        //add Department item
        Task<SaveEmployeeAttendenceResponse> SaveAsync(EmployeeAttendence employeeAttendence);    //find by id for existing Department item
        Task<SaveEmployeeAttendenceResponse> UpdateAsync(int id,EmployeeAttendence employeeAttendence);        //update Department item
        Task<SaveEmployeeAttendenceResponse> DeleteAsync(int id);    
    }
}