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
    public class EmployeeAttendenceService : IEmployeeAttendenceService
    {
        private readonly IEmployeeAttendenceRepository _employeeAttendenceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public  EmployeeAttendenceService (IEmployeeAttendenceRepository employeeAttendenceRepository,IUnitOfWork unitofwork)
        {
            _employeeAttendenceRepository = employeeAttendenceRepository;
			_unitOfWork = unitofwork;
        }

        public async Task<SaveEmployeeAttendenceResponse> DeleteAsync(int id)
        {
            var existingEmployeeAttendence= await _employeeAttendenceRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingEmployeeAttendence == null)
				return new SaveEmployeeAttendenceResponse("Departmentnot found.");
			
			try
			{
				_employeeAttendenceRepository.Remove(existingEmployeeAttendence);
				await _unitOfWork.CompleteAsync();


				return new SaveEmployeeAttendenceResponse("Data Delete");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveEmployeeAttendenceResponse($"An error occurred when deleting the department: {ex.Message}");
			}
        }

        public async Task<EmployeeAttendence> GetByIdAsync(int id)
        {
            return await _employeeAttendenceRepository.FindByIdAsync(id);        

        }

        public async Task<IEnumerable<EmployeeAttendence>> ListAsync()
        {
            await _unitOfWork.CompleteAsync();
            return await _employeeAttendenceRepository.ListAsync() ;
        }

        public async Task<SaveEmployeeAttendenceResponse> SaveAsync(EmployeeAttendence employeeAttendence)
        {
           try
			{
				await _employeeAttendenceRepository.AddAsync(employeeAttendence);
				await _unitOfWork.CompleteAsync();
			
				return new SaveEmployeeAttendenceResponse(employeeAttendence);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveEmployeeAttendenceResponse($"An error occurred when saving the Department: {ex.Message}");
			}
        }

        public async Task<SaveEmployeeAttendenceResponse> UpdateAsync(int id, EmployeeAttendence employeeAttendence)
        {
            var existingEmployeeAttendence = await _employeeAttendenceRepository.FindByIdAsync(id);
			
			if (existingEmployeeAttendence == null)
            	return new SaveEmployeeAttendenceResponse("Employee not found.");
			
			///Authorized By NiNiWinMay(Table Joining) 23.6.2019
			/// 
			
			existingEmployeeAttendence.Attendences.date=employeeAttendence.Attendences.date;
            existingEmployeeAttendence.Attendences.start_time=employeeAttendence.Attendences.start_time;
            existingEmployeeAttendence.Attendences.end_time = employeeAttendence.Attendences.end_time;
            existingEmployeeAttendence.Attendences.attendenceType=employeeAttendence.Attendences.attendenceType;
            existingEmployeeAttendence.Attendences.remark=employeeAttendence?.Attendences?.remark;
			existingEmployeeAttendence.Attendences.Employees.employee_No = employeeAttendence?.Attendences?.Employees.employee_No;
			existingEmployeeAttendence.Attendences.Employees.employee_Name= employeeAttendence?.Attendences?.Employees.employee_Name;
            existingEmployeeAttendence.Attendences.Employees.email=employeeAttendence?.Attendences?.Employees.email;
            existingEmployeeAttendence.Attendences.Employees.dob=employeeAttendence.Attendences.Employees.dob;
            existingEmployeeAttendence.Attendences.Employees.nrc=employeeAttendence?.Attendences?.Employees.nrc;	
			existingEmployeeAttendence.Attendences.Employees.phone_no_work=employeeAttendence?.Attendences?.Employees.phone_no_work;
			existingEmployeeAttendence.Attendences.Employees.phone_no_personal=employeeAttendence?.Attendences?.Employees.phone_no_personal;
			existingEmployeeAttendence.Attendences.Employees.gender=employeeAttendence?.Attendences?.Employees.gender;
			existingEmployeeAttendence.Attendences.Employees.marital_status=employeeAttendence?.Attendences?.Employees.marital_status;
			existingEmployeeAttendence.Attendences.Employees.nationality=employeeAttendence?.Attendences?.Employees.nationality;
			existingEmployeeAttendence.Attendences.Employees.religion=employeeAttendence?.Attendences?.Employees.religion;
			existingEmployeeAttendence.Attendences.Employees.permanent_address=employeeAttendence?.Attendences?.Employees.permanent_address;
			existingEmployeeAttendence.Attendences.Employees.education_background=employeeAttendence?.Attendences?.Employees.education_background;
			existingEmployeeAttendence.Attendences.Employees.joined_date=employeeAttendence.Attendences.Employees.joined_date;
			existingEmployeeAttendence.Attendences.Employees.employee_state=employeeAttendence?.Attendences?.Employees.employee_state;
			existingEmployeeAttendence.Attendences.Employees.Addresses.line_1= employeeAttendence?.Attendences?.Employees.Addresses.line_1;
			existingEmployeeAttendence.Attendences.Employees.Addresses.line_2= employeeAttendence?.Attendences?.Employees.Addresses.line_2;
			existingEmployeeAttendence.Attendences.Employees.Addresses.region= employeeAttendence?.Attendences?.Employees.Addresses.region;
			existingEmployeeAttendence.Attendences.Employees.Addresses.country= employeeAttendence?.Attendences?.Employees.Addresses.country;
			existingEmployeeAttendence.locations.lotitude=employeeAttendence.locations?.lotitude;
			existingEmployeeAttendence.locations.longitude=employeeAttendence.locations?.longitude;
			existingEmployeeAttendence.locations.remark=employeeAttendence.locations?.remark;
           
			
			try
			{
				_employeeAttendenceRepository.Update(existingEmployeeAttendence);
				await _unitOfWork.CompleteAsync();
                return new SaveEmployeeAttendenceResponse(existingEmployeeAttendence);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveEmployeeAttendenceResponse($"An error occurred when saving the Department: {ex.Message}");
			}
        }
    }
        
    }
