using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HR_MANAGEMENT.Communication;
using HR_MANAGEMENT.IServices;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;

namespace  HR_MANAGEMENT.Domain.Services
{
	 //to get the list of objects..
    public class AddressService : IAddressService
    {

    private readonly IAddressRepository _addressRepository;
	private readonly IUnitOfWork _unitOfWork;

	public AddressService(IAddressRepository addressRepository, IUnitOfWork unitOfWork)
	{
		_addressRepository = addressRepository;
		_unitOfWork = unitOfWork;
	}
        public async Task<SaveAddressResponse> DeleteAsync(int id)
        { 
            var existingAddress = await _addressRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingAddress == null)
				return new SaveAddressResponse("Address not found.");
			
			try
			{
				_addressRepository.Remove(existingAddress);
				await _unitOfWork.CompleteAsync();


				return new SaveAddressResponse("Data Delete");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveAddressResponse($"An error occurred when deleting the address: {ex.Message}");
			}
          
        }

        public async Task<Address> GetByIdAsync(int id)
        {
          return await _addressRepository.FindByIdAsync(id); 
        }

        public async Task<IEnumerable<Address>> ListAsync()
        {
            return await _addressRepository.ListAsync() ;  

        }

        public async Task<SaveAddressResponse> SaveAsync(Address address)
        {
            try
			{
				await _addressRepository.AddAsync(address);
				await _unitOfWork.CompleteAsync();
			
				return new SaveAddressResponse(address);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveAddressResponse($"An error occurred when saving the address: {ex.Message}");
			}
        }

        public async Task<SaveAddressResponse> UpdateAsync(int id, Address address)
        {
            var existingAddress = await _addressRepository.FindByIdAsync(id);
			
			if (existingAddress == null)
			return new SaveAddressResponse("Address not found.");	
			
			existingAddress.line_1 = address.line_1;
			existingAddress.line_2= address.line_2;
            //existingAddress.township=address.township;
            //existingAddress.city=address.city;
			existingAddress.township_Id=address.township_Id;
			existingAddress.Township.townshipId=address.Township.townshipId;
			existingAddress.Township.Name=address.Township.Name;
            existingAddress.Township.city_Id=address.Township.city_Id;
			existingAddress.Township.city.cityId=address.Township.city.cityId;
			 existingAddress.Township.city.Name=address.Township.city.Name;
            existingAddress.region=address.region;
            existingAddress.country=address.country;	
			try
			{
				_addressRepository.Update(existingAddress);
				await _unitOfWork.CompleteAsync();
               return new SaveAddressResponse(existingAddress);
			
			}
			catch (Exception ex)
			{
				// Do some logging stuff
                return new SaveAddressResponse($"An error occurred when saving the address: {ex.Message}");
				
			}
        }
}
}