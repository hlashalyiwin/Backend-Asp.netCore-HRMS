using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.IServices;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Domain.Services
{
	//to get the list of objects.
    public class LeaveService : ILeaveService
    {

    private readonly ILeaveRepository _leaveRepository;
	private readonly IUnitOfWork _unitOfWork;

	public LeaveService(ILeaveRepository leaveRepository, IUnitOfWork unitOfWork)
	{
		_leaveRepository = leaveRepository;
		_unitOfWork = unitOfWork;
	}
        public async Task<SaveLeaveResponse> DeleteAsync(int id)
        { 
            var existingLeave = await _leaveRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingLeave == null)
				return new SaveLeaveResponse("Shipping not found.");
			
			try
			{
				_leaveRepository.Remove(existingLeave);
				await _unitOfWork.CompleteAsync();


				return new SaveLeaveResponse("Data Delete");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveLeaveResponse($"An error occurred when deleting the Leave: {ex.Message}");
			}
          
        }

        public async Task<Leave> GetByIdAsync(int id)
        {
          return await _leaveRepository.FindByIdAsync(id); 
        }

        public async Task<IEnumerable<Leave>> ListAsync()
        {
            return await _leaveRepository.ListAsync() ;  

        }

        public async Task<SaveLeaveResponse> SaveAsync(Leave leave)
        {
            try
			{
				await _leaveRepository.AddAsync(leave);
				await _unitOfWork.CompleteAsync();
			
				return new SaveLeaveResponse(leave);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveLeaveResponse($"An error occurred when saving the Department: {ex.Message}");
			}
        }

        public async Task<SaveLeaveResponse> UpdateAsync(int id, Leave leave)
        {
            var existingLeave = await _leaveRepository.FindByIdAsync(id);
			
			if (existingLeave == null)
			return new SaveLeaveResponse("Employee not found.");	
			
			///Authorized By NiNiWinMay(Table Joining) 23.6.2019
			//existingLeave.employee_id = leave.employee_id;
			existingLeave.Leave_type= leave.Leave_type;
            existingLeave.from_date=leave.from_date;
            existingLeave.to_date=leave.to_date;
			existingLeave.Employees.employee_No = leave.Employees.employee_No;
			existingLeave.Employees.employee_Name= leave.Employees.employee_Name;
            existingLeave.Employees.email=leave.Employees.email;
            existingLeave.Employees.dob=leave.Employees.dob;
            existingLeave.Employees.nrc=leave.Employees.nrc;	
			existingLeave.Employees.phone_no_work=leave.Employees.phone_no_work;
			existingLeave.Employees.phone_no_personal=leave.Employees.phone_no_personal;
			existingLeave.Employees.gender=leave.Employees.gender;
			existingLeave.Employees.marital_status=leave.Employees.marital_status;
			existingLeave.Employees.nationality=leave.Employees.nationality;
			existingLeave.Employees.religion=leave.Employees.religion;
			existingLeave.Employees.permanent_address=leave.Employees.permanent_address;
			existingLeave.Employees.education_background=leave.Employees.education_background;
			//existingLeave.Employees.addressId=leave.Employees.addressId;
			existingLeave.Employees.joined_date=leave.Employees.joined_date;
			existingLeave.Employees.employee_state=leave.Employees.employee_state;
			existingLeave.Employees.Addresses.line_1= leave.Employees.Addresses.line_1;
			existingLeave.Employees.Addresses.line_2= leave.Employees.Addresses.line_2;
			existingLeave.Employees.Addresses.region= leave.Employees.Addresses.region;
			existingLeave.Employees.Addresses.country= leave.Employees.Addresses.country;

			

			
			try
			{
				_leaveRepository.Update(existingLeave);
				await _unitOfWork.CompleteAsync();
               return new SaveLeaveResponse(existingLeave);
			
			}
			catch (Exception ex)
			{
				// Do some logging stuff
                return new SaveLeaveResponse($"An error occurred when saving the Department: {ex.Message}");
				
			}
        }
    }
}