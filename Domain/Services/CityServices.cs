using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Hr_Management_final_api.IServices;
namespace HR_MANAGEMENT.Domain.Services
{
    public class CityServices: ICityService
    {
        private readonly ICityRepository _cityRepository;
	    private readonly IUnitOfWork _unitOfWork;

	public CityServices(ICityRepository cityRepository, IUnitOfWork unitOfWork)
	{
		_cityRepository = cityRepository;
		_unitOfWork = unitOfWork;
	}
        public async Task<SaveCityResponse> DeleteAsync(int id)
        { 
            var existingCity = await _cityRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingCity == null)
				return new SaveCityResponse("City not found.");
			
			try
			{
				_cityRepository.Remove(existingCity);
				await _unitOfWork.CompleteAsync();


				return new SaveCityResponse("Data Delete");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveCityResponse($"An error occurred when deleting the city: {ex.Message}");
			}
          
        }
        public async Task<City> GetByIdAsync(int id)
        {
            return await _cityRepository.FindByIdAsync(id); 
        }

        public async Task<IEnumerable<City>> ListAsync()
        {
            return await _cityRepository.ListAsync() ;  

        }

        public async Task<SaveCityResponse> SaveAsync(City city)
        {
            try
			{
				await _cityRepository.AddAsync(city);
				await _unitOfWork.CompleteAsync();
			
				return new SaveCityResponse(city);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveCityResponse($"An error occurred when saving theb{ex.Message}");
			}
        }

        public async Task<SaveCityResponse> UpdateAsync(int id, City city)
        {
            var existingCity = await _cityRepository.FindByIdAsync(id);
			if (existingCity == null)
			return new SaveCityResponse("City not found.");	
			existingCity.Name= city.Name;
			
			try
			{
				_cityRepository.Update(existingCity);
				await _unitOfWork.CompleteAsync();
                return new SaveCityResponse(existingCity);
			
			}
			catch (Exception ex)
			{
				// Do some logging stuff
                return new SaveCityResponse($"An error occurred when saving the Branch: {ex.Message}");
				
			}
        }
    }
}