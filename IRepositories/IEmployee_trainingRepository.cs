using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace  Hr_Management_final_api.IRepositories
{
    public interface IEmployee_trainingRepository
    {//interface IEmployee_trainingRepository for Employee_trainingRepository
       Task<IEnumerable<Employee_training>> ListAsync();
       Task AddAsync(Employee_training employee_training);
       Task<IEnumerable<Employee_training>> FindByMonth(int sdate,int smonth,int syear,int edate,int emonth,int eyear);  
       
       Task<IEnumerable<Employee_training>> FindByTrainingId( int trainingId);
       Task<IEnumerable<Employee_training>> FindByEmpId( int empId,int sdate,int smonth,int syear,int edate,int emonth,int eyear, string trainingName);

       Task<Employee_training> FindByIdAsync(int id);
	   void Update(Employee_training employee_training);
       void Remove(Employee_training employee_training);
    }
}
