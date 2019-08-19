using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Hr_Management_final_api.IServices;

namespace Hr_Management_final_api.Domain.Services
{
	 //to get the list of objects..
    //implement ITrainingService
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly IUnitOfWork _unitOfWork;
        public TrainingService(ITrainingRepository trainingRepository,IUnitOfWork unitofwork)
        {
            _trainingRepository = trainingRepository;
			_unitOfWork = unitofwork;
        }
        public async Task<Training> GetByIdAsync(int id)
        {
            return await _trainingRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Training>> ListAsync()
        {
            await _unitOfWork.CompleteAsync();
            return await _trainingRepository.ListAsync();
        }

		
		
        public async Task<SaveTrainingResponse> UpdateAsync(int id, Training Training)
        {
            var existingTraining = await _trainingRepository.FindByIdAsync(id);
			
			if (existingTraining == null)
			return new SaveTrainingResponse("Employee not found.");	
			
			existingTraining.training = Training.training;
			existingTraining.duration= Training.duration;
            existingTraining.pre_requestive=Training.pre_requestive;
            existingTraining.remark=Training.remark;
			
		

			try
			{
				_trainingRepository.Update(existingTraining);
				await _unitOfWork.CompleteAsync();

			  return new SaveTrainingResponse(existingTraining);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				 return new SaveTrainingResponse($"An error occurred when saving the Department: {ex.Message}");
				
			}
        }
        public async Task<SaveTrainingResponse> SaveAsync(Training Training)
		{
			try
			{
				await _trainingRepository.AddAsync(Training);
				await _unitOfWork.CompleteAsync();
			
				return new SaveTrainingResponse(Training);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveTrainingResponse($"An error occurred when saving the Training: {ex.Message}");
			}
		}


		public async Task<SaveTrainingResponse> DeleteAsync(int id)
		{
			var existingTraining = await _trainingRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingTraining == null)
				return new SaveTrainingResponse("Information not found.");
			try
			{
				_trainingRepository.Remove(existingTraining);
				
				await _unitOfWork.CompleteAsync();


				return new SaveTrainingResponse("Success");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveTrainingResponse($"An error occurred when deleting the Information: {ex.Message}");
			}
		}

        
    }
}