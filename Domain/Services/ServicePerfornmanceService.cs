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
    public class ServicePerfornmanceService : IServicePerformanceService
    {
        private readonly IServicePerformanceRepository _serviceRepository;
		private readonly IUnitOfWork _unitOfWork;
	public ServicePerfornmanceService(IServicePerformanceRepository addressRepository, IUnitOfWork unitOfWork)
	{
		_serviceRepository = addressRepository;
		_unitOfWork = unitOfWork;
	}
        public async Task<SaveServicePerformanceResponse> DeleteAsync(int id)
        { 
            var existingAddress = await _serviceRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingAddress == null)
				return new SaveServicePerformanceResponse("Address not found.");
			
			try
			{
				_serviceRepository.Remove(existingAddress);
				await _unitOfWork.CompleteAsync();


				return new SaveServicePerformanceResponse("Data Delete");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveServicePerformanceResponse($"An error occurred when deleting the address: {ex.Message}");
			}
          
        }

        public async Task<ServicePerformance> GetByIdAsync(int id)
        {
			
          return await _serviceRepository.FindByIdAsync(id); 
        }

        public async Task<IEnumerable<ServicePerformance>> ListAsync()
        {
			await _unitOfWork.CompleteAsync();
            return await _serviceRepository.ListAsync() ;  

        }

        public async Task<SaveServicePerformanceResponse> SaveAsync(ServicePerformance service)
        {
            try
			{
				await _serviceRepository.AddAsync(service);
				await _unitOfWork.CompleteAsync();
			
				return new SaveServicePerformanceResponse(service);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveServicePerformanceResponse($"An error occurred when saving the address: {ex.Message}");
			}
        }

        public async Task<SaveServicePerformanceResponse> UpdateAsync(int id, ServicePerformance service)
        {
            var existingServicePerformance = await _serviceRepository.FindByIdAsync(id);
			
			if (existingServicePerformance == null)
			return new SaveServicePerformanceResponse("ServicePerformance");	
			
			///Authorized By NiNiWinMay(Table Joining) 23.6.2019
			existingServicePerformance.work_done= service.work_done;
            existingServicePerformance.remark=service.remark;
			existingServicePerformance.Attendence.date=service.Attendence.date;
            existingServicePerformance.Attendence.start_time=service.Attendence.start_time;
            existingServicePerformance.Attendence.end_time = service.Attendence.end_time;
            existingServicePerformance.Attendence.attendenceType=service.Attendence.attendenceType;
            existingServicePerformance.Attendence.remark=service.Attendence.remark;
			existingServicePerformance.Attendence.Employees.employee_No = service.Attendence.Employees.employee_No;
			existingServicePerformance.Attendence.Employees.employee_Name= service.Attendence.Employees.employee_Name;
            existingServicePerformance.Attendence.Employees.email=service.Attendence.Employees.email;
            existingServicePerformance.Attendence.Employees.dob=service.Attendence.Employees.dob;
            existingServicePerformance.Attendence.Employees.nrc=service.Attendence.Employees.nrc;	
			existingServicePerformance.Attendence.Employees.phone_no_work=service.Attendence.Employees.phone_no_work;
			existingServicePerformance.Attendence.Employees.phone_no_personal=service.Attendence.Employees.phone_no_personal;
			existingServicePerformance.Attendence.Employees.gender=service.Attendence.Employees.gender;
			existingServicePerformance.Attendence.Employees.marital_status=service.Attendence.Employees.marital_status;
			existingServicePerformance.Attendence.Employees.nationality=service.Attendence.Employees.nationality;
			existingServicePerformance.Attendence.Employees.religion=service.Attendence.Employees.religion;
			existingServicePerformance.Attendence.Employees.permanent_address=service.Attendence.Employees.permanent_address;
			existingServicePerformance.Attendence.Employees.education_background=service.Attendence.Employees.education_background;
			//existingServicePerformance.Attendence.Employees.addressId=service.Attendence.Employees.addressId;
			existingServicePerformance.Attendence.Employees.joined_date=service.Attendence.Employees.joined_date;
			existingServicePerformance.Attendence.Employees.employee_state=service.Attendence.Employees.employee_state;
			existingServicePerformance.Attendence.Employees.Addresses.line_1= service.Attendence.Employees.Addresses.line_1;
			existingServicePerformance.Attendence.Employees.Addresses.line_2= service.Attendence.Employees.Addresses.line_2;
			existingServicePerformance.Attendence.Employees.Addresses.region= service.Attendence.Employees.Addresses.region;
			existingServicePerformance.Attendence.Employees.Addresses.country= service.Attendence.Employees.Addresses.country;	
			try
			{
				_serviceRepository.Update(existingServicePerformance);
				await _unitOfWork.CompleteAsync();
               return new SaveServicePerformanceResponse(existingServicePerformance);
			
			}
			catch (Exception ex)
			{
				// Do some logging stuff
                return new SaveServicePerformanceResponse($"An error occurred when saving the address: {ex.Message}");
				
			}
        }
    }
}