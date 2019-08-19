using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;



namespace Hr_Management_final_api.IServices
{
        //return an enumeration of ServicePerformance

    public interface IServicePerformanceService
    {
                          
        Task<IEnumerable<ServicePerformance>> ListAsync();//return all ServicePerformance data                   

        Task<ServicePerformance> GetByIdAsync(int id);          //find by id for existing ServicePerformance item              
        Task<SaveServicePerformanceResponse> SaveAsync(ServicePerformance servicePerformance);    //add ServicePerformance  item
        Task<SaveServicePerformanceResponse> UpdateAsync(int id, ServicePerformance servicePerformance);     //update ServicePerformance  item  
        Task<SaveServicePerformanceResponse> DeleteAsync(int id);
    }
}