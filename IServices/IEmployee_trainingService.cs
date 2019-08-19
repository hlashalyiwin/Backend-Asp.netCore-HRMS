using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Communication;

namespace HR_MANAGEMENT.IServices
{
    public interface IEmployee_trainingService
    {
        
          Task<IEnumerable<Employee_training>> ListAsync();
     
          Task<Employee_training> GetByIdAsync(int id);
          Task<IEnumerable<Employee_training>> FindByMonth(int sdate,int smonth,int syear,int edate,int emonth,int eyear);  
          Task<IEnumerable<Employee_training>> FindByTrainingId( int  trainingId);
          Task<IEnumerable<Employee_training>> FindByEmpId( int empId,int sdate,int smonth,int syear,int edate,int emonth,int eyear, string trainingName);
          Task<SaveEmployee_trainingResponse> SaveAsync(Employee_training Employee_training);
          Task<SaveEmployee_trainingResponse> UpdateAsync(int id, Employee_training Employee_training);
          Task<SaveEmployee_trainingResponse> DeleteAsync(int id);
    }
}
