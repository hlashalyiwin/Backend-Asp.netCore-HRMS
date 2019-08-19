using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_final_api.Domain.Repositories
{ //to manage data from databases.
    public class RewardRepository:BaseRepository,IRewardRepository
    {
        public RewardRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Reward>> ListAsync()//List all the data
        {
            return await _context.Reward.ToListAsync();


        }
        public async Task<Reward> GetByIdAsync(int id)//Get by id
        {
            return await _context.Reward.FindAsync(id);
        }


        public async Task AddAsync(Reward reward)// add data
        {
            await _context.Reward.AddAsync(reward);
        }


        public async Task<Reward> FindByIdAsync(int id)//find by id
        {
            return await _context.Reward.FindAsync(id);

            
        }

        public void Update(Reward reward)//update data
        {

            _context.Reward.Update(reward);
        }

        public void Remove(Reward reward)//remove data
        {
            _context.Reward.Remove(reward);

        }
    }
}
