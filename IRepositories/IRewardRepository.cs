using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;


namespace Hr_Management_final_api.Domain.IRepositories
{
    public interface IRewardRepository
    {//interface IRewardRepository for RewardRepository
        Task<IEnumerable<Reward>> ListAsync();
        Task<Reward> FindByIdAsync(int id);

        Task AddAsync(Reward reward);

        void Update(Reward reward);
        void Remove(Reward reward);
    }
}
