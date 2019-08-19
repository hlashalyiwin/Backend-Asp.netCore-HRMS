using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;


namespace Hr_Management_final_api.IRepositories
{
    public interface IServicePerformanceRepository
    {//interface IServicePerformanceRepository for ServicePerformanceRepository
    Task<IEnumerable<ServicePerformance>> ListAsync();   
	 Task AddAsync(ServicePerformance servicePerformance);               
     Task<ServicePerformance> FindByIdAsync(int id);              
	 void Update(ServicePerformance servicePerformance);                    
     void Remove(ServicePerformance servicePerformance);             
    }
}