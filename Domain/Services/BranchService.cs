using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HR_MANAGEMENT.Communication;
using HR_MANAGEMENT.IServices;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;

namespace HR_MANAGEMENT.Domain.Services
{ //to get the list of objects..
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
	    private readonly IUnitOfWork _unitOfWork;

	public BranchService(IBranchRepository branchRepository, IUnitOfWork unitOfWork)
	{
		_branchRepository = branchRepository;
		_unitOfWork = unitOfWork;
	}
        public async Task<BranchResponse> DeleteAsync(int id)
        { 
            var existingBranch = await _branchRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingBranch == null)
				return new BranchResponse("Branch not found.");
			
			try
			{
				_branchRepository.Remove(existingBranch);
				await _unitOfWork.CompleteAsync();


				return new BranchResponse("Data Delete");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new BranchResponse($"An error occurred when deleting the branch: {ex.Message}");
			}
          
        }

        public async Task<Branch> GetByIdAsync(int id)
        {
            return await _branchRepository.FindByIdAsync(id); 
        }

        public async Task<IEnumerable<Branch>> ListAsync()
        {
            return await _branchRepository.ListAsync() ;  

        }

        public async Task<BranchResponse> SaveAsync(Branch branch)
        {
            try
			{
				await _branchRepository.AddAsync(branch);
				await _unitOfWork.CompleteAsync();
			
				return new BranchResponse(branch);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new BranchResponse($"An error occurred when saving theb{ex.Message}");
			}
        }

        public async Task<BranchResponse> UpdateAsync(int id, Branch branch)
        {
            var existingBranch = await _branchRepository.FindByIdAsync(id);
			
			if (existingBranch == null)
			return new BranchResponse("Branch not found.");	
			//Authorized By NiNiWinMay(Table Joining) 24.6.2019
			existingBranch.name= branch.name;
            existingBranch.phone_1=branch.phone_1;
			existingBranch.phone_2=branch.phone_2;
			existingBranch.Addresses.line_1=branch.Addresses.line_1;
			existingBranch.Addresses.line_2=branch.Addresses.line_2;
			existingBranch.Addresses.Township.Name=branch.Addresses.Township.Name;
			existingBranch.Addresses.Township.city.Name=branch.Addresses.Township.city.Name;
			existingBranch.Addresses.region=branch.Addresses.region;
			existingBranch.Addresses.country=branch.Addresses.country;	
			try
			{
				_branchRepository.Update(existingBranch);
				await _unitOfWork.CompleteAsync();
                return new BranchResponse(existingBranch);
			
			}
			catch (Exception ex)
			{
				// Do some logging stuff
                return new BranchResponse($"An error occurred when saving the Branch: {ex.Message}");
				
			}
        }
    }
}