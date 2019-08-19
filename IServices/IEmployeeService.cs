using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Domain.IServices
{  //interface IEmployeeService for EmployeeService
    public interface IEmployeeService
    {
         //implement methods
        Task<IEnumerable<Employee>> ListAsync();                    //return all employee data
         
        Task<Employee> GetByIdAsync(int id);                        //add employee item
        Task<SaveEmployeeResponse> SaveAsync(Employee Employee);    //find by id for existing employee item
        Task<SaveEmployeeResponse> UpdateAsync(int id, Employee employee);        //update employee item
        Task<SaveEmployeeResponse> DeleteAsync(int id);     //delete employee item
    }
}