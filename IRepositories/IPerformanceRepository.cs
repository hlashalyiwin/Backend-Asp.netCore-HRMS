using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Domain.IRepositories
{
    public interface IPerformanceRepository
    {//interface IPerformanceRepository for PerformanceRepository
        Task<IEnumerable<Performance>> ListAsync();
        Task<Performance> FindByIdAsync(int id);

        Task AddAsync(Performance per);

        void Update(Performance per);
        void Remove(Performance per);
    }
}
