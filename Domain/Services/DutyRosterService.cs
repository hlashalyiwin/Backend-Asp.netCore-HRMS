using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HR_MANAGEMENT.IServicess;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;

namespace Hr_Management_final_api.Domain.Services
{ //to get the list of objects..
    public class DutyRosterService: IDutyRosterService
    {
        private readonly IDutyRosterRepository _dutyRosterRepository;
        private readonly IUnitOfWork _unitOfWork;

        public  DutyRosterService (IDutyRosterRepository dutyRosterRepository,IUnitOfWork unitofwork)
        {
            _dutyRosterRepository = dutyRosterRepository;
			_unitOfWork = unitofwork;
        }

        public async Task<SaveDutyRosterResponse> DeleteAsync(int id)
        {
            var existingDepartment = await _dutyRosterRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingDepartment == null)
				return new SaveDutyRosterResponse("Departmentnot found.");
			
			try
			{
				_dutyRosterRepository.Remove(existingDepartment);
				await _unitOfWork.CompleteAsync();


				return new SaveDutyRosterResponse("Data Delete");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveDutyRosterResponse($"An error occurred when deleting the department: {ex.Message}");
			}
        }

        public async Task<DutyRoster> GetByIdAsync(int id)
        {
            return await _dutyRosterRepository.FindByIdAsync(id);        

        }

        public async Task<IEnumerable<DutyRoster>> ListAsync()
        {
            await _unitOfWork.CompleteAsync();
            return await _dutyRosterRepository.ListAsync() ;
        }

        public async Task<SaveDutyRosterResponse> SaveAsync(DutyRoster dutyRoster)
        {
           try
			{
				await _dutyRosterRepository.AddAsync(dutyRoster);
				await _unitOfWork.CompleteAsync();
			
				return new SaveDutyRosterResponse(dutyRoster);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveDutyRosterResponse($"An error occurred when saving the Department: {ex.Message}");
			}
        }

        public async Task<SaveDutyRosterResponse> UpdateAsync(int id, DutyRoster dutyRoster)
        {
            var existingDutyRoster = await _dutyRosterRepository.FindByIdAsync(id);
			
			if (existingDutyRoster == null)
            return new SaveDutyRosterResponse("Duty Roster not found.");

			//existingDutyRoster.Shift_Id=dutyRoster.Shift_Id;
            existingDutyRoster.From_Date=dutyRoster.From_Date;
            existingDutyRoster.To_Date=dutyRoster.To_Date;
            existingDutyRoster.Shift.Name=dutyRoster.Shift.Name;
            existingDutyRoster.Shift.Start_Time=dutyRoster.Shift.Start_Time;
            existingDutyRoster.Shift.End_Time=dutyRoster.Shift.End_Time;

         try
			{
				_dutyRosterRepository.Update(existingDutyRoster);
				await _unitOfWork.CompleteAsync();
                return new SaveDutyRosterResponse(existingDutyRoster);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveDutyRosterResponse($"An error occurred when saving the Department: {ex.Message}");
			}
        }
    }
    }
