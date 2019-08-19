using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IServices
{//return an enumeration of reward
    public interface IRewardService
    {
        Task<IEnumerable<Reward>> ListAsync();
        //Task<SaveService_performanceResponse>FindAsync(int id);
        Task<Reward> GetByIdAsync(int id);
        Task<SaveRewardResponse> SaveAsync(Reward reward);
        Task<SaveRewardResponse> UpdateAsync(int id, Reward reward);
        Task<SaveRewardResponse> DeleteAsync(int id);
    }
}
