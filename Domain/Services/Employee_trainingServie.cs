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
    public class Employee_trainingServie : IEmployee_trainingService
    {

        private readonly IEmployee_trainingRepository _employee_trainingRepository;
        private readonly IUnitOfWork _unitOfWork;
        public Employee_trainingServie(IEmployee_trainingRepository employee_trainingRepository,IUnitOfWork unitofwork)
        {
            _employee_trainingRepository = employee_trainingRepository;
			_unitOfWork = unitofwork;
        }


        public async Task<IEnumerable<Employee_training>> ListAsync()
        {
			await _unitOfWork.CompleteAsync();
            return await _employee_trainingRepository.ListAsync();
        }
		public async Task<Employee_training> GetByIdAsync(int id)
		{
			return await _employee_trainingRepository.FindByIdAsync(id);
			 
		}


        public async Task<SaveEmployee_trainingResponse> SaveAsync(Employee_training Employee_training)
		{
			try
			{
				await _employee_trainingRepository.AddAsync(Employee_training);
				await _unitOfWork.CompleteAsync();
			
				return new SaveEmployee_trainingResponse(Employee_training);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveEmployee_trainingResponse($"An error occurred when saving the Information: {ex.Message}");
			}
		}

		public async Task<SaveEmployee_trainingResponse> UpdateAsync(int id, Employee_training Employee_training)
		{
			var existingEmployee_training = await _employee_trainingRepository.FindByIdAsync(id);
			
			if (existingEmployee_training == null)
					return new SaveEmployee_trainingResponse("Employee Training not found.");
			
			///Authorized By NiNiWinMay(Table Joining) 23.6.2019
			existingEmployee_training.from_date = Employee_training.from_date;
			existingEmployee_training.to_date= Employee_training.to_date;
            existingEmployee_training.remark= Employee_training.remark;
			existingEmployee_training.Employees.employee_No = Employee_training.Employees.employee_No;
			existingEmployee_training.Employees.employee_Name= Employee_training.Employees.employee_Name;
            existingEmployee_training.Employees.email=Employee_training.Employees.email;
            existingEmployee_training.Employees.dob=Employee_training.Employees.dob;
            existingEmployee_training.Employees.nrc=Employee_training.Employees.nrc;	
			existingEmployee_training.Employees.phone_no_work=Employee_training.Employees.phone_no_work;
			existingEmployee_training.Employees.phone_no_personal=Employee_training.Employees.phone_no_personal;
			existingEmployee_training.Employees.gender=Employee_training.Employees.gender;
			existingEmployee_training.Employees.marital_status=Employee_training.Employees.marital_status;
			existingEmployee_training.Employees.nationality=Employee_training.Employees.nationality;
			existingEmployee_training.Employees.religion=Employee_training.Employees.religion;
			existingEmployee_training.Employees.permanent_address=Employee_training.Employees.permanent_address;
			existingEmployee_training.Employees.education_background=Employee_training.Employees.education_background;
			//existingEmployee_training.Employees.addressId=Employee_training.Employees.addressId;
			existingEmployee_training.Employees.joined_date=Employee_training.Employees.joined_date;
			existingEmployee_training.Employees.employee_state=Employee_training.Employees.employee_state;
			existingEmployee_training.Employees.Addresses.line_1= Employee_training.Employees.Addresses.line_1;
			existingEmployee_training.Employees.Addresses.line_2= Employee_training.Employees.Addresses.line_2;
			existingEmployee_training.Employees.Addresses.region= Employee_training.Employees.Addresses.region;
			existingEmployee_training.Employees.Addresses.country= Employee_training.Employees.Addresses.country;
			existingEmployee_training.Trainings.training=Employee_training.Trainings.training;
			existingEmployee_training.Trainings.duration=Employee_training.Trainings.duration;
			existingEmployee_training.Trainings.pre_requestive=Employee_training.Trainings.pre_requestive;
			existingEmployee_training.Trainings.remark=Employee_training.Trainings.remark;

            try
			{
				_employee_trainingRepository.Update(existingEmployee_training);
				await _unitOfWork.CompleteAsync();

				 return new SaveEmployee_trainingResponse(existingEmployee_training);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveEmployee_trainingResponse($"An error occurred when saving the Department: {ex.Message}");
			}
		}

		public async Task<SaveEmployee_trainingResponse> DeleteAsync(int id)
		{
			var existingEmployee_training = await _employee_trainingRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingEmployee_training == null)
				return new SaveEmployee_trainingResponse("Employee_training not found.");
			//existingEmployee_training=await Email.Transport;
			try
			{
				_employee_trainingRepository.Remove(existingEmployee_training);
				//_eamilRepository.Remove(Transport);
				await _unitOfWork.CompleteAsync();


				return new SaveEmployee_trainingResponse("Success");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveEmployee_trainingResponse($"An error occurred when deleting the Information: {ex.Message}");
			}
		}

        public async Task<IEnumerable<Employee_training>> FindByMonth(int sdate, int smonth, int syear, int edate, int emonth, int eyear)
        {
          return await  _employee_trainingRepository.FindByMonth(sdate,smonth,syear,edate,emonth,eyear);
        }

        public async Task<IEnumerable<Employee_training>> FindByTrainingId(int trainingId)
        {
          return await  _employee_trainingRepository.FindByTrainingId(trainingId);
        }

        public async Task<IEnumerable<Employee_training>> FindByEmpId(int empId,int sdate, int smonth, int syear, int edate, int emonth, int eyear,string trainingName)
        {
            return await  _employee_trainingRepository.FindByEmpId(empId,sdate,smonth,syear,edate,emonth,eyear,trainingName);
        }
    }
}
