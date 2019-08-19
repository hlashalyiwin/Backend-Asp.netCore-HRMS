using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Hr_Management_final_api.IServices;

namespace Hr_Management_final_api.Domain.Services
{ //to get the list of objects..
    public class LocationService: ILocationService
    {

    private readonly ILocationRepositories _locationRepository;
	private readonly IUnitOfWork _unitOfWork;

	public LocationService(ILocationRepositories locationRepository, IUnitOfWork unitOfWork)
	{
		_locationRepository = locationRepository;
		_unitOfWork = unitOfWork;
	}
        public async Task<SaveLocationResponse> DeleteAsync(int id)
        { 
            var existingLocation = await _locationRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingLocation == null)
				return new SaveLocationResponse("Shipping not found.");
			
			try
			{
				_locationRepository.Remove(existingLocation);
				await _unitOfWork.CompleteAsync();


				return new SaveLocationResponse("Data Delete");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveLocationResponse($"An error occurred when deleting the Leave: {ex.Message}");
			}
          
        }

        public async Task<Location> GetByIdAsync(int id)
        {
          return await _locationRepository.FindByIdAsync(id); 
        }

        public async Task<IEnumerable<Location>> ListAsync()
        {
            return await _locationRepository.ListAsync() ;  

        }

        public async Task<SaveLocationResponse> SaveAsync(Location location)
        {
            try
			{
				await _locationRepository.AddAsync(location);
				await _unitOfWork.CompleteAsync();
			
				return new SaveLocationResponse(location);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveLocationResponse($"An error occurred when saving the Department: {ex.Message}");
			}
        }

        public async Task<SaveLocationResponse> UpdateAsync(int id, Location location)
        {
            var existingLocation = await _locationRepository.FindByIdAsync(id);
			
			if (existingLocation == null)
			return new SaveLocationResponse("Employee not found.");	
			
			existingLocation.lotitude= location.lotitude;
            existingLocation.longitude=location.longitude;
            existingLocation.remark=location.remark;
			

			
			try
			{
				_locationRepository.Update(existingLocation);
				await _unitOfWork.CompleteAsync();
               return new SaveLocationResponse(existingLocation);
			
			}
			catch (Exception ex)
			{
				// Do some logging stuff
                return new SaveLocationResponse($"An error occurred when saving the Department: {ex.Message}");
				
			}
        }
    }
}