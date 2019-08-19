using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IServices;

namespace Hr_Management_final_api.Domain.Services
{ //to get the list of objects..
    public class PerformanceService : IPerformanceService
    {
        private readonly IPerformanceRepository performanceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PerformanceService(IPerformanceRepository performanceRepository, IUnitOfWork unitofwork)
        {
            this.performanceRepository = performanceRepository;
            _unitOfWork = unitofwork;
        }

        //ListAsync Method
        public async Task<IEnumerable<Performance>> ListAsync()//List all the data
        {
            await _unitOfWork.CompleteAsync();
            return await performanceRepository.ListAsync();
        }
        public async Task<Performance> GetByIdAsync(int id)//get by id
        {
            return await performanceRepository.FindByIdAsync(id);

        }

        //SaveAsyn Method
        public async Task<SavePerformanceResponse> SaveAsync(Performance performance)//save data
        {
            try
            {
                await performanceRepository.AddAsync(performance);
                await _unitOfWork.CompleteAsync();

                return new SavePerformanceResponse(performance);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SavePerformanceResponse($"An error occurred when saving the Service_performance: {ex.Message}");
            }
        }

        //UpdateAsyn Method
        public async Task<SavePerformanceResponse> UpdateAsync(int id, Performance performance)//update by id
        {
            var existing_performance = await performanceRepository.FindByIdAsync(id);

            if (existing_performance == null)
			return new SavePerformanceResponse("Employee not found.");	

         
            ///Authorized By NiNiWinMay(Table Joining) 23.6.2019
            existing_performance.remark = performance.remark;
            existing_performance.Employee.employee_No = performance.Employee.employee_No;
	        existing_performance.Employee.employee_Name= performance.Employee.employee_Name;
            existing_performance.Employee.email=performance.Employee.email;
            existing_performance.Employee.dob=performance.Employee.dob;
            existing_performance.Employee.nrc=performance.Employee.nrc;	
	        existing_performance.Employee.phone_no_work=performance.Employee.phone_no_work;
	        existing_performance.Employee.phone_no_personal=performance.Employee.phone_no_personal;
	        existing_performance.Employee.gender=performance.Employee.gender;
	        existing_performance.Employee.marital_status=performance.Employee.marital_status;
	        existing_performance.Employee.nationality=performance.Employee.nationality;
	        existing_performance.Employee.religion=performance.Employee.religion;
	        existing_performance.Employee.permanent_address=performance.Employee.permanent_address;
	        existing_performance.Employee.education_background=performance.Employee.education_background;
	        //existing_performance.Employee.addressId=performance.Employee.addressId;
	        existing_performance.Employee.joined_date=performance.Employee.joined_date;
	        existing_performance.Employee.employee_state=performance.Employee.employee_state;
	        existing_performance.Employee.Addresses.line_1= performance.Employee.Addresses.line_1;
	        existing_performance.Employee.Addresses.line_2= performance.Employee.Addresses.line_2;
	        existing_performance.Employee.Addresses.region= performance.Employee.Addresses.region;
	        existing_performance.Employee.Addresses.country= performance.Employee.Addresses.country;
            existing_performance.Task.Name= performance.Task.Name;
            existing_performance.Task.Start_Time= performance.Task.Start_Time;
            existing_performance.Task.End_Time= performance.Task.End_Time;
            existing_performance.Task.Status= performance.Task.Status;
            existing_performance.Task.Remark= performance.Task.Remark;
            existing_performance.Reward.name= performance.Reward.name;
            existing_performance.Reward.qty= performance.Reward.qty;
            existing_performance.Reward.payment= performance.Reward.payment;
            existing_performance.Reward.remark= performance.Reward.remark;

            try
            {
                performanceRepository.Update(existing_performance);
                await _unitOfWork.CompleteAsync();

               return new SavePerformanceResponse(existing_performance);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SavePerformanceResponse($"An error occurred when saving the Department: {ex.Message}");
				
            }
        }

        //DeleteAsyn Method
        public async Task<SavePerformanceResponse> DeleteAsync(int id)//delete by id
        {
            var existing_performance = await performanceRepository.FindByIdAsync(id);
            await _unitOfWork.CompleteAsync();

            if (existing_performance == null)
                return new SavePerformanceResponse("Performance not found.");
            
            try
            {
                performanceRepository.Remove(existing_performance);

                await _unitOfWork.CompleteAsync();


                return new SavePerformanceResponse("Success");
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SavePerformanceResponse($"An error occurred when deleting the Service_performance: {ex.Message}");
            }
        }
    }
}
