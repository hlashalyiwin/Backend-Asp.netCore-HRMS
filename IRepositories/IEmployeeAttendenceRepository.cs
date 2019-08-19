using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IRepositories
{
    public interface IEmployeeAttendenceRepository
    {//interface IEmployee_attendenceRepository for Employee_attendenceRepository
        Task<IEnumerable<EmployeeAttendence>> ListAsync();
          //return all  Employee_attendence data
        Task AddAsync(EmployeeAttendence employeeAttendence);           //add Employee_attendence item
        
        Task<EmployeeAttendence> FindByIdAsync(int id);       //find by id for existing Employee_attendence  item
	    void Update(EmployeeAttendence employeeAttendence);             //updateEmployee_attendence item
        void Remove(EmployeeAttendence employeeAttendence);   
    }
}