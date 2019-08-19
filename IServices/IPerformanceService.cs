using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IServices
{//return an enumeration of performance
    public interface IPerformanceService
    {
        Task<IEnumerable<Performance>> ListAsync();
        //Task<SaveService_performanceResponse>FindAsync(int id);
        Task<Performance> GetByIdAsync(int id);
        Task<SavePerformanceResponse> SaveAsync(Performance performance);
        Task<SavePerformanceResponse> UpdateAsync(int id, Performance performance);
        Task<SavePerformanceResponse> DeleteAsync(int id);
    }
}
