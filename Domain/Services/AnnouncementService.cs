using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HR_MANAGEMENT.Communication;
using HR_MANAGEMENT.IServices;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;

namespace HR_MANAGEMENT.Domain.Services
{
	//to get the list of objects..
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _addressRepository;
	    private readonly IUnitOfWork _unitOfWork;

	public AnnouncementService(IAnnouncementRepository addressRepository, IUnitOfWork unitOfWork)
	{
		_addressRepository = addressRepository;
		_unitOfWork = unitOfWork;
	}
        public async Task<SaveAnnouncementResponse> DeleteAsync(int id)
        { 
            var existingAddress = await _addressRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingAddress == null)
				return new SaveAnnouncementResponse("Address not found.");
			
			try
			{
				_addressRepository.Remove(existingAddress);
				await _unitOfWork.CompleteAsync();


				return new SaveAnnouncementResponse("Data Delete");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveAnnouncementResponse($"An error occurred when deleting the address: {ex.Message}");
			}
          
        }

        public async Task<Announcement> GetByIdAsync(int id)
        {
          return await _addressRepository.FindByIdAsync(id); 
        }

        public async Task<IEnumerable<Announcement>> ListAsync()
        {
            return await _addressRepository.ListAsync() ;  

        }

        public async Task<SaveAnnouncementResponse> SaveAsync(Announcement address)
        {
            try
			{
				await _addressRepository.AddAsync(address);
				await _unitOfWork.CompleteAsync();
			
				return new SaveAnnouncementResponse(address);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveAnnouncementResponse($"An error occurred when saving the address: {ex.Message}");
			}
        }

        public async Task<SaveAnnouncementResponse> UpdateAsync(int id, Announcement address)
        {
            var existingAddress = await _addressRepository.FindByIdAsync(id);
			
			if (existingAddress == null)
			return new SaveAnnouncementResponse("Address not found.");	
			        //announcement(id , description , title , date) 

			//existingAddress.id = address.id;
			existingAddress.description= address.description;
            existingAddress.title=address.title;
            existingAddress.date=address.date;			
			try
			{
				_addressRepository.Update(existingAddress);
				await _unitOfWork.CompleteAsync();
               return new SaveAnnouncementResponse(existingAddress);
			
			}
			catch (Exception ex)
			{
				// Do some logging stuff
                return new SaveAnnouncementResponse($"An error occurred when saving the address: {ex.Message}");
				
			}
        }
    }
}