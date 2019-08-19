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
    public class AbsenceService : IAbsenceService
    {
    private readonly IAbsenceRepository _absenceRepository;
	private readonly IUnitOfWork _unitOfWork;

	public AbsenceService(IAbsenceRepository absenceRepository, IUnitOfWork unitOfWork)
	{
		_absenceRepository = absenceRepository;
		_unitOfWork = unitOfWork;
	}
        public async Task<SaveAbsenceResponse> DeleteAsync(int id)
        { 
            var existingAbsence = await _absenceRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingAbsence == null)
				return new SaveAbsenceResponse("Shipping not found.");
			
			try
			{
				_absenceRepository.Remove(existingAbsence);
				await _unitOfWork.CompleteAsync();

				return new SaveAbsenceResponse("Data Delete");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveAbsenceResponse($"An error occurred when deleting the shipping: {ex.Message}");
			}
          
        }
        public async Task<Absence> GetByIdAsync(int id)
        {
          return await _absenceRepository.FindByIdAsync(id); 
        }

        public async Task<IEnumerable<Absence>> ListAsync()
        {
            return await _absenceRepository.ListAsync() ;  

        }
        public async Task<SaveAbsenceResponse> SaveAsync(Absence absence)
        {
            try
			{
				await _absenceRepository.AddAsync(absence);
				await _unitOfWork.CompleteAsync();
			
				return new SaveAbsenceResponse(absence);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveAbsenceResponse($"An error occurred when saving the Department: {ex.Message}");
			}
        }

        public async Task<SaveAbsenceResponse> UpdateAsync(int id, Absence absence)
        {
            var existingAbsence = await _absenceRepository.FindByIdAsync(id);
			
			if (existingAbsence == null)
			return new SaveAbsenceResponse("Employee not found.");	
			
			//Authorized By NiNiWinMay(Table Joining) 23.6.2019	
            existingAbsence.date=absence.date;
			existingAbsence.Employees.employee_No = absence.Employees.employee_No;
			existingAbsence.Employees.employee_Name= absence.Employees.employee_Name;
            existingAbsence.Employees.email=absence.Employees.email;
            existingAbsence.Employees.dob=absence.Employees.dob;
            existingAbsence.Employees.nrc=absence.Employees.nrc;	
			existingAbsence.Employees.phone_no_work=absence.Employees.phone_no_work;
			existingAbsence.Employees.phone_no_personal=absence.Employees.phone_no_personal;
			existingAbsence.Employees.gender=absence.Employees.gender;
			existingAbsence.Employees.marital_status=absence.Employees.marital_status;
			existingAbsence.Employees.nationality=absence.Employees.nationality;
			existingAbsence.Employees.religion=absence.Employees.religion;
			existingAbsence.Employees.permanent_address=absence.Employees.permanent_address;
			existingAbsence.Employees.education_background=absence.Employees.education_background;
			//existingAbsence.Employees.addressId=absence.Employees.addressId;
			existingAbsence.Employees.joined_date=absence.Employees.joined_date;
			existingAbsence.Employees.employee_state=absence.Employees.employee_state;
			existingAbsence.Employees.Addresses.line_1= absence.Employees.Addresses.line_1;
			existingAbsence.Employees.Addresses.line_2= absence.Employees.Addresses.line_2;
			existingAbsence.Employees.Addresses.Township.Name= absence.Employees.Addresses.Township.Name;
			existingAbsence.Employees.Addresses.Township.city.Name= absence.Employees.Addresses.Township.city.Name;
			//existingAbsence.Employees.Addresses.Township.city.Name= absence.Employees.Addresses.Township.city.Name;
			existingAbsence.Employees.Addresses.region= absence.Employees.Addresses.region;
			existingAbsence.Employees.Addresses.country= absence.Employees.Addresses.country;
			existingAbsence.Rates.Name= absence.Rates.Name;
			existingAbsence.Rates.rate= absence.Rates.rate;
			existingAbsence.Rates.type= absence.Rates.type;
			existingAbsence.Rates.description= absence.Rates.description;
			try
			{
				_absenceRepository.Update(existingAbsence);
				await _unitOfWork.CompleteAsync();
               return new SaveAbsenceResponse(existingAbsence);
			
			}
			catch (Exception ex)
			{
				// Do some logging stuff
                return new SaveAbsenceResponse($"An error occurred when saving the Absence: {ex.Message}");
				
			}
        }
		   public async Task<IEnumerable<Absence>> FindByNameAsync(string name)
        {
           return await  _absenceRepository.FindByNameAsync(name);
        }
    }
}