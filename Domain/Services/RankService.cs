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
    public class RankService : IRankService
    {
    private readonly IRankRepository _rankRepository;
	private readonly IUnitOfWork _unitOfWork;

	public RankService(IRankRepository rankRepository, IUnitOfWork unitOfWork)
	{
		_rankRepository = rankRepository;
		_unitOfWork = unitOfWork;
	}

        public async Task<SaveRankResponse> DeleteAsync(int id)
        {
            var existingrate = await _rankRepository .FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingrate == null)
				return new SaveRankResponse("Shipping not found.");
			
			try
			{
				_rankRepository.Remove(existingrate);
				await _unitOfWork.CompleteAsync();


				return new SaveRankResponse("Data Delete");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveRankResponse($"An error occurred when deleting the department: {ex.Message}");
			}
        }

        public async Task<Rank> GetByIdAsync(int rankId)
        {
            return await _rankRepository.FindByIdAsync(rankId); 
        }

        public async Task<IEnumerable<Rank>> ListAsync()
        {
          // await _unitOfWork.CompleteAsync();
            return await _rankRepository.ListAsync() ;  
        }

        public async Task<SaveRankResponse> SaveAsync(Rank rank)
        {
             try
			{
				await _rankRepository.AddAsync(rank);
				await _unitOfWork.CompleteAsync();
			
				return new SaveRankResponse(rank);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveRankResponse($"An error occurred when saving the Department: {ex.Message}");
			}
        }

        public async Task<SaveRankResponse> UpdateAsync(int rankId, Rank Rank)
        {
            var existingrate= await _rankRepository.FindByIdAsync(rankId);
			
			if (existingrate == null)
			 return new SaveRankResponse("Category not found.");
			
					existingrate.Name = Rank.Name;
				
					
            
	     	try
		     	{
					_rankRepository.Update(existingrate);
					await _unitOfWork.CompleteAsync();
					return new SaveRankResponse(existingrate);

				//return "Success";
		  	}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveRankResponse($"An error occurred when saving the Department: {ex.Message}");
			}
        }

       
    }
}