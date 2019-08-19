using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.IServices;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Domain.Services
{ //to get the list of objects..
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IEmployeeRepository employeeRepository,IUnitOfWork unitofwork)
        {
            _employeeRepository = employeeRepository;
			_unitOfWork = unitofwork;
        }

        public async Task<SaveEmployeeResponse> DeleteAsync(int id)
        {
            var existingEmployee = await _employeeRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingEmployee == null)
				return new SaveEmployeeResponse("Employee not found.");
			
			try
			{
				_employeeRepository.Remove(existingEmployee);
				await _unitOfWork.CompleteAsync();


				return new SaveEmployeeResponse("Data Delete");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveEmployeeResponse($"An error occurred when deleting the Employee: {ex.Message}");
			}
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
         return await _employeeRepository.FindByIdAsync(id);        }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            await _unitOfWork.CompleteAsync();
            return await _employeeRepository.ListAsync() ;      
             }

        public async Task<SaveEmployeeResponse> SaveAsync(Employee employee)
        {
             try
			{
				await _employeeRepository.AddAsync(employee);
				await _unitOfWork.CompleteAsync();
			
				return new SaveEmployeeResponse(employee);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveEmployeeResponse($"An error occurred when saving the employeesage{ex}");
			}
         }

        public async Task<SaveEmployeeResponse> UpdateAsync(int id,Employee employee)
        {
           var existingEmployee = await _employeeRepository.FindByIdAsync(id);
			
			if (existingEmployee == null)
			return new SaveEmployeeResponse("Employee not found.");
			
			//Authorized By NiNiWinMay(Table Joining) 24.6.2019
			existingEmployee.employee_No = employee.employee_No;
			existingEmployee.employee_Name= employee.employee_Name;
            existingEmployee.email=employee.email;
            existingEmployee.dob=employee.dob;
            existingEmployee.nrc=employee.nrc;	
			existingEmployee.phone_no_work=employee.phone_no_work;
			existingEmployee.phone_no_personal=employee.phone_no_personal;
			existingEmployee.gender=employee.gender;
			existingEmployee.marital_status=employee.marital_status;
			existingEmployee.nationality=employee.nationality;
			existingEmployee.religion=employee.religion;
			existingEmployee.permanent_address=employee.permanent_address;
			existingEmployee.education_background=employee.education_background;
			existingEmployee.joined_date=employee.joined_date;
			existingEmployee.employee_state=employee.employee_state;
			existingEmployee.Addresses.line_1= employee.Addresses.line_1;
			existingEmployee.Addresses.line_2= employee.Addresses.line_2;
			
			existingEmployee.Addresses.region= employee.Addresses.region;
			existingEmployee.Addresses.country= employee.Addresses.country;
			try
			{
				_employeeRepository.Update(existingEmployee);
				await _unitOfWork.CompleteAsync();
				 return new SaveEmployeeResponse(existingEmployee);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveEmployeeResponse($"An error occurred when saving the employeesage{ex}");
			}
        }
    }
}