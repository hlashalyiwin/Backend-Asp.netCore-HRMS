using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HR_MANAGEMENT.IServices;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;

namespace Hr_Management_final_api.Domain.Services
{ //to get the list of objects..
    public class RateService: IRateService
    {
     private readonly IRateRepository _rateRepository;
	private readonly IUnitOfWork _unitOfWork;

	public RateService(IRateRepository rateRepository, IUnitOfWork unitOfWork)
	{
		_rateRepository = rateRepository;
		_unitOfWork = unitOfWork;
	}

        public async Task<SaveRateResponse> DeleteAsync(int id)
        {
            var existingrate = await _rateRepository .FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingrate == null)
				return new SaveRateResponse("Shipping not found.");
			
			try
			{
				_rateRepository.Remove(existingrate);
				await _unitOfWork.CompleteAsync();


				return new SaveRateResponse("Data Delete");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveRateResponse($"An error occurred when deleting the department: {ex.Message}");
			}
        }

        public async Task<Rate> GetByIdAsync(int rateId)
        {
            return await _rateRepository.FindByIdAsync(rateId); 
        }

        public async Task<IEnumerable<Rate>> ListAsync()
        {
          // await _unitOfWork.CompleteAsync();
            return await _rateRepository.ListAsync() ;  
        }

        public async Task<SaveRateResponse> SaveAsync(Rate Rate)
        {
             try
			{
				await _rateRepository.AddAsync(Rate);
				await _unitOfWork.CompleteAsync();
			
				return new SaveRateResponse(Rate);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveRateResponse($"An error occurred when saving the Department: {ex.Message}");
			}
        }

        public async Task<SaveRateResponse> UpdateAsync(int rateId, Rate Rate)
        {
            var existingrate= await _rateRepository.FindByIdAsync(rateId);
			
			if (existingrate == null)
			 return new SaveRateResponse("Category not found.");
			
					existingrate.Name = Rate.Name;
					existingrate.rate=Rate.rate;
					existingrate.type=Rate.type;
					existingrate.description=Rate.description;
					
            
	     	try
		     	{
					_rateRepository.Update(existingrate);
					await _unitOfWork.CompleteAsync();
					return new SaveRateResponse(existingrate);

				//return "Success";
		  	}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveRateResponse($"An error occurred when saving the Department: {ex.Message}");
			}
        }
    }
}