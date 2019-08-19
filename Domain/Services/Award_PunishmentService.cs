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
public class Award_PunishmentService : IAward_PunishmentService
{
	private readonly IAward_PunishmentRepository _award_punishmentRepository;
	private readonly IUnitOfWork _unitOfWork;

	public Award_PunishmentService(IAward_PunishmentRepository award_punishmentRepository, IUnitOfWork unitOfWork)
	{
		_award_punishmentRepository = award_punishmentRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Award_Punishment> GetByIdAsync(int id)
        {
            return await _award_punishmentRepository.FindByIdAsync(id); 
        }

	public async Task<IEnumerable<Award_Punishment>> ListAsync()
	{
		await _unitOfWork.CompleteAsync();
		return await _award_punishmentRepository.ListAsync();
	}

	public async Task<SaveAward_PunishmentResponse> SaveAsync(Award_Punishment award_punishment)
	{
		try
		{
			await  _award_punishmentRepository.AddAsync(award_punishment);
			await _unitOfWork.CompleteAsync();
			
			return new SaveAward_PunishmentResponse(award_punishment);
		}
		catch (Exception ex)
		{
			// Do some logging stuff
			return new SaveAward_PunishmentResponse($"An error occurred when saving the award_punishment: {ex.Message}");
		}
	}
	public async Task<SaveAward_PunishmentResponse> UpdateAsync(int id, Award_Punishment award_punishment)
{
	var existingAward_Punishment = await _award_punishmentRepository.FindByIdAsync(id);

	if (existingAward_Punishment == null)
		return new SaveAward_PunishmentResponse("Award_Punishment not found.");

	//Authorized By NiNiWinMay(Joining Tables) 23.6.2019
	existingAward_Punishment.award_punishment=award_punishment.award_punishment;
	existingAward_Punishment.date=award_punishment.date;
	existingAward_Punishment.description=award_punishment.description;
	existingAward_Punishment.remark=award_punishment.remark;
	existingAward_Punishment.Employees.employee_No = award_punishment.Employees.employee_No;
	existingAward_Punishment.Employees.employee_Name= award_punishment.Employees.employee_Name;
    existingAward_Punishment.Employees.email=award_punishment.Employees.email;
    existingAward_Punishment.Employees.dob=award_punishment.Employees.dob;
    existingAward_Punishment.Employees.nrc=award_punishment.Employees.nrc;	
	existingAward_Punishment.Employees.phone_no_work=award_punishment.Employees.phone_no_work;
	existingAward_Punishment.Employees.phone_no_personal=award_punishment.Employees.phone_no_personal;
	existingAward_Punishment.Employees.gender=award_punishment.Employees.gender;
	existingAward_Punishment.Employees.marital_status=award_punishment.Employees.marital_status;
	existingAward_Punishment.Employees.nationality=award_punishment.Employees.nationality;
	existingAward_Punishment.Employees.religion=award_punishment.Employees.religion;
	existingAward_Punishment.Employees.permanent_address=award_punishment.Employees.permanent_address;
	existingAward_Punishment.Employees.education_background=award_punishment.Employees.education_background;
	//existingAward_Punishment.Employees.addressId=award_punishment.Employees.addressId;
	existingAward_Punishment.Employees.joined_date=award_punishment.Employees.joined_date;
	existingAward_Punishment.Employees.employee_state=award_punishment.Employees.employee_state;
	existingAward_Punishment.Employees.Addresses.line_1= award_punishment.Employees.Addresses.line_1;
	existingAward_Punishment.Employees.Addresses.line_2= award_punishment.Employees.Addresses.line_2;
	


	try
	{
		_award_punishmentRepository.Update(existingAward_Punishment);
		await _unitOfWork.CompleteAsync();

		return new SaveAward_PunishmentResponse(existingAward_Punishment);
	}
	catch (Exception ex)
	{
		// Do some logging stuff
		return new SaveAward_PunishmentResponse($"An error occurred when updating the award_punishment: {ex.Message}");
	}
}
public async Task<SaveAward_PunishmentResponse> DeleteAsync(int id)
{
	var existingAward_Punishment = await _award_punishmentRepository.FindByIdAsync(id);

	if (existingAward_Punishment == null)
		return new SaveAward_PunishmentResponse("Award_Punishment not found.");

	try
	{
		_award_punishmentRepository.Remove(existingAward_Punishment);
		await _unitOfWork.CompleteAsync();

		return new SaveAward_PunishmentResponse(existingAward_Punishment);
	}
	catch (Exception ex)
	{
		// Do some logging stuff
		return new SaveAward_PunishmentResponse($"An error occurred when deleting the award_punishment: {ex.Message}");
	}
}
}
}
