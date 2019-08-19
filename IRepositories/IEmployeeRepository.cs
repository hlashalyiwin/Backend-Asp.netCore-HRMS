using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Domain.IRepositories
{  //interface IEmployeeRepository for EmployeeRepository
    public interface IEmployeeRepository
    {   //implement methods
        Task<IEnumerable<Employee>> ListAsync();    //return all employee items
        Task AddAsync(Employee employee);           //add employee items
        
        Task<Employee> FindByIdAsync(int id);       //find by id for existing employee items
	    void Update(Employee employee);             //update employee items
        void Remove(Employee employee);             //delete employee items 
    }
}