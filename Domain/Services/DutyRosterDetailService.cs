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
    public class DutyRosterDetailService : IDutyRosterDetailService
    {
        private readonly IDutyRosterDetailRepository _dutyRosterDetailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public  DutyRosterDetailService (IDutyRosterDetailRepository dutyRosterDetailRepository,IUnitOfWork unitofwork)
        {
            _dutyRosterDetailRepository = dutyRosterDetailRepository;
			_unitOfWork = unitofwork;
        }

        public async Task<SaveDutyRosterDetailResponse> DeleteAsync(int id)
        {
            var existingDepartment = await _dutyRosterDetailRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingDepartment == null)
				return new SaveDutyRosterDetailResponse("Departmentnot found.");
			
			try
			{
				_dutyRosterDetailRepository.Remove(existingDepartment);
				await _unitOfWork.CompleteAsync();


				return new SaveDutyRosterDetailResponse("Data Delete");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveDutyRosterDetailResponse($"An error occurred when deleting the department: {ex.Message}");
			}
        }

        public async Task<IEnumerable<DutyRosterDetail>> findByEmpId(int empId)
        {
             return await _dutyRosterDetailRepository.findByEmpId(empId);  
        }

        public async Task<DutyRosterDetail> GetByIdAsync(int id)
        {
            return await _dutyRosterDetailRepository.FindByIdAsync(id);        

        }

        public async Task<IEnumerable<DutyRosterDetail>> ListAsync()
        {
            await _unitOfWork.CompleteAsync();
            return await _dutyRosterDetailRepository.ListAsync() ;
        }

        public async Task<SaveDutyRosterDetailResponse> SaveAsync(DutyRosterDetail dutyRoster)
        {
           try
			{
				await _dutyRosterDetailRepository.AddAsync(dutyRoster);
				await _unitOfWork.CompleteAsync();
			
				return new SaveDutyRosterDetailResponse(dutyRoster);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveDutyRosterDetailResponse($"An error occurred when saving the Department: {ex.Message}");
			}
        }

        public async Task<SaveDutyRosterDetailResponse> UpdateAsync(int id, DutyRosterDetail dutyRoster)
        {
            var existingDutyRoster = await _dutyRosterDetailRepository.FindByIdAsync(id);
			
			if (existingDutyRoster == null)
            return new SaveDutyRosterDetailResponse("Duty Roster not found.");

			///Authorized By NiNiWinMay(Table Joining) 23.6.2019
			existingDutyRoster.Employees.employee_No = dutyRoster.Employees.employee_No;
			existingDutyRoster.Employees.employee_Name= dutyRoster.Employees.employee_Name;
            existingDutyRoster.Employees.email=dutyRoster.Employees.email;
            existingDutyRoster.Employees.dob=dutyRoster.Employees.dob;
            existingDutyRoster.Employees.nrc=dutyRoster.Employees.nrc;	
			existingDutyRoster.Employees.phone_no_work=dutyRoster.Employees.phone_no_work;
			existingDutyRoster.Employees.phone_no_personal=dutyRoster.Employees.phone_no_personal;
			existingDutyRoster.Employees.gender=dutyRoster.Employees.gender;
			existingDutyRoster.Employees.marital_status=dutyRoster.Employees.marital_status;
			existingDutyRoster.Employees.nationality=dutyRoster.Employees.nationality;
			existingDutyRoster.Employees.religion=dutyRoster.Employees.religion;
			existingDutyRoster.Employees.permanent_address=dutyRoster.Employees.permanent_address;
			existingDutyRoster.Employees.education_background=dutyRoster.Employees.education_background;
			//existingDutyRoster.Employees.addressId=dutyRoster.Employees.addressId;
			existingDutyRoster.Employees.joined_date=dutyRoster.Employees.joined_date;
			existingDutyRoster.Employees.employee_state=dutyRoster.Employees.employee_state;
			existingDutyRoster.Employees.Addresses.line_1= dutyRoster.Employees.Addresses.line_1;
			existingDutyRoster.Employees.Addresses.line_2= dutyRoster.Employees.Addresses.line_2;
			existingDutyRoster.Employees.Addresses.region= dutyRoster.Employees.Addresses.region;
			existingDutyRoster.Employees.Addresses.country= dutyRoster.Employees.Addresses.country;
			existingDutyRoster.DutyRosters.From_Date= dutyRoster.DutyRosters.From_Date;
			existingDutyRoster.DutyRosters.To_Date= dutyRoster.DutyRosters.To_Date;
			existingDutyRoster.DutyRosters.Shift.Name= dutyRoster.DutyRosters.Shift.Name;
			existingDutyRoster.DutyRosters.Shift.Start_Time= dutyRoster.DutyRosters.Shift.Start_Time;
			existingDutyRoster.DutyRosters.Shift.End_Time= dutyRoster.DutyRosters.Shift.End_Time;
			
         try
			{
				_dutyRosterDetailRepository.Update(existingDutyRoster);
				await _unitOfWork.CompleteAsync();
                return new SaveDutyRosterDetailResponse(existingDutyRoster);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveDutyRosterDetailResponse($"An error occurred when saving the Department: {ex.Message}");
			}
        }
    }
}