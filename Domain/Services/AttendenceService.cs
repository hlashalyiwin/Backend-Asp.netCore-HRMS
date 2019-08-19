using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_MANAGEMENT.Communication;
using HR_MANAGEMENT.IServices;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
namespace HR_MANAGEMENT.Domain.Services
{
	 //to get the list of objects.
    public class AttendenceService: IAttendenceService
    {
        private readonly IAttendenceRepository _attendenceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public  AttendenceService (IAttendenceRepository attendenceRepository,IUnitOfWork unitofwork)
        {
            _attendenceRepository = attendenceRepository;
			_unitOfWork = unitofwork;
        }
		public async Task<IEnumerable<Attendence>> FindByDay(int day,int month,int year){
			return await _attendenceRepository.FindByDayAsync(day,month,year);
		}

        public async Task<SaveAttendenceResponse> DeleteAsync(int id)
        {
            var existingAttendence = await _attendenceRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingAttendence == null)
				return new SaveAttendenceResponse("Attendence not found.");
			
			try
			{
				_attendenceRepository.Remove(existingAttendence);
				await _unitOfWork.CompleteAsync();


				return new SaveAttendenceResponse("Data Delete");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveAttendenceResponse($"An error occurred when deleting the attendence: {ex.Message}");
			}
        }

        public int FindAttendance(int month, int year)
        {
            throw new NotImplementedException();
        }

        public  async Task<IEnumerable<Attendence>> FindByName (int month, int year)
        {
           return await  _attendenceRepository.FindByNameAsync(month,year);
        }
		 public  async Task<IEnumerable<Attendence>> FindByEmpId(int empId)
		 {
			 return await  _attendenceRepository.FindByEmpId(empId);
		}

        public async Task<Attendence> GetByIdAsync(int id)
        {
            return await _attendenceRepository.FindByIdAsync(id);        

        }

        public async Task<IEnumerable<Attendence>> ListAsync()
        {
            await _unitOfWork.CompleteAsync();
            return await _attendenceRepository.ListAsync() ;
        }

        public async Task<SaveAttendenceResponse> SaveAsync(Attendence attendence)
        {
           try
			{
				await _attendenceRepository.AddAsync(attendence);
				await _unitOfWork.CompleteAsync();
			
				return new SaveAttendenceResponse(attendence);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveAttendenceResponse($"An error occurred when saving the attendence: {ex.Message}");
			}
        }

        public async Task<SaveAttendenceResponse> UpdateAsync(int id,Attendence attendence )
        {
            var existingAttendence = await _attendenceRepository.FindByIdAsync(id);
			
			if (existingAttendence == null)
            	return new SaveAttendenceResponse("Attendence not found.");
			
			//Authorized By NiNiWinMay(Table Joining) 23.6.2019
			existingAttendence.empId=attendence.empId;
			existingAttendence.Employees.employeeId=attendence.Employees.employeeId;
            existingAttendence.date=attendence.date;
            existingAttendence.start_time=attendence.start_time;
            existingAttendence.end_time = attendence.end_time;
            existingAttendence.attendenceType=attendence.attendenceType;
            existingAttendence.remark=attendence.remark;
			existingAttendence.Employees.employee_No = attendence.Employees.employee_No;
			existingAttendence.Employees.employee_Name= attendence.Employees.employee_Name;
            existingAttendence.Employees.email=attendence.Employees.email;
            existingAttendence.Employees.dob=attendence.Employees.dob;
            existingAttendence.Employees.nrc=attendence.Employees.nrc;	
			existingAttendence.Employees.phone_no_work=attendence.Employees.phone_no_work;
			existingAttendence.Employees.phone_no_personal=attendence.Employees.phone_no_personal;
			existingAttendence.Employees.gender=attendence.Employees.gender;
			existingAttendence.Employees.marital_status=attendence.Employees.marital_status;
			existingAttendence.Employees.nationality=attendence.Employees.nationality;
			existingAttendence.Employees.religion=attendence.Employees.religion;
			existingAttendence.Employees.permanent_address=attendence.Employees.permanent_address;
			existingAttendence.Employees.education_background=attendence.Employees.education_background;
			//existingAttendence.Employees.addressId=attendence.Employees.addressId;
			existingAttendence.Employees.joined_date=attendence.Employees.joined_date;
			existingAttendence.Employees.employee_state=attendence.Employees.employee_state;
			existingAttendence.Employees.Addresses.line_1= attendence.Employees.Addresses.line_1;
			existingAttendence.Employees.Addresses.line_2= attendence.Employees.Addresses.line_2;
			existingAttendence.Employees.Addresses.Township.Name= attendence.Employees.Addresses.Township.Name;
			existingAttendence.Employees.Addresses.Township.city.Name= attendence.Employees.Addresses.Township.city.Name;
			existingAttendence.Employees.Addresses.region= attendence.Employees.Addresses.region;
			existingAttendence.Employees.Addresses.country= attendence.Employees.Addresses.country;
			
			
			
           
			
			try
			{
				_attendenceRepository.Update(existingAttendence);
				await _unitOfWork.CompleteAsync();
                return new SaveAttendenceResponse(existingAttendence);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveAttendenceResponse($"An error occurred when saving the attendence: {ex.Message}");
			}
        }
    }
}