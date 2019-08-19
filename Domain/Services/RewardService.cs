using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IServices;

namespace Hr_Management_final_api.Domain.Services
{ //to get the list of objects..
    public class RewardService : IRewardService
    {
        private readonly IRewardRepository rewardRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RewardService(IRewardRepository rewardRepository, IUnitOfWork unitofwork)
        {
            this.rewardRepository = rewardRepository;
            _unitOfWork = unitofwork;
        }

        //ListAsync Method
        public async Task<IEnumerable<Reward>> ListAsync()//List all the data
        {
            await _unitOfWork.CompleteAsync();
            return await rewardRepository.ListAsync();
        }
        public async Task<Reward> GetByIdAsync(int id)//get by id
        {
            return await rewardRepository.FindByIdAsync(id);

        }

        //SaveAsyn Method
        public async Task<SaveRewardResponse> SaveAsync(Reward reward)//save data
        {
            try
            {
                await rewardRepository.AddAsync(reward);
                await _unitOfWork.CompleteAsync();

                return new SaveRewardResponse(reward);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveRewardResponse($"An error occurred when saving the Service_performance: {ex.Message}");
            }
        }

        //UpdateAsyn Method
        public async Task<SaveRewardResponse> UpdateAsync(int id, Reward reward)//update by id
        {
            var existing_reward = await rewardRepository.FindByIdAsync(id);

            if (existing_reward == null)
			 return new SaveRewardResponse("Category not found.");

          
            existing_reward.name = reward.name;
            existing_reward.qty = reward.qty;
            existing_reward.payment = reward.payment;
            existing_reward.remark = reward.remark;

            try
            {
                rewardRepository.Update(existing_reward);
                await _unitOfWork.CompleteAsync();
               return new SaveRewardResponse(existing_reward);
                
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveRewardResponse($"An error occurred when saving the Department: {ex.Message}");
            }
        }

        //DeleteAsyn Method
        public async Task<SaveRewardResponse> DeleteAsync(int id)//delete by id
        {
            var existing_performance = await rewardRepository.FindByIdAsync(id);
            await _unitOfWork.CompleteAsync();

            if (existing_performance == null)
                return new SaveRewardResponse("Reward not found.");
            //existingService_performance=await Service_performance.Transport;
            try
            {
                rewardRepository.Remove(existing_performance);
                //_service_performanceRepository.Remove(Transport);
                await _unitOfWork.CompleteAsync();


                return new SaveRewardResponse("Success");
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveRewardResponse($"An error occurred when deleting the Service_performance: {ex.Message}");
            }
        }
    }
}
