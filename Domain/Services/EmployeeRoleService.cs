using System.Collections.Generic;
using System.Threading.Tasks;

using System;
using Hr_Management_final_api.IServices;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Communication;

//21.6.2019
//Authorized by NiNiWinMay
namespace Hr_Management_final_api.Domain.Services
{ //to get the list of objects..
    public class EmployeeRoleService : IEmployeeRoleService
    {

        private readonly IEmployeeRoleRepository _employeeRoleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeRoleService(IEmployeeRoleRepository employeeRoleRepository,IUnitOfWork unitofwork)
        {
            _employeeRoleRepository = employeeRoleRepository;
			_unitOfWork = unitofwork;
        }

		/// <summary>
		/// Getting data from employee role table
		/// </summary>
		/// <returns></returns>
        public async Task<IEnumerable<EmployeeRoles>> ListAsync()
        {
			await _unitOfWork.CompleteAsync();
            return await _employeeRoleRepository.ListAsync();
        }

		/// <summary>
		/// Getting data from employee role with specified id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<EmployeeRoles> GetByIdAsync(int id)
		{
			return await _employeeRoleRepository.FindByIdAsync(id);
			 
		}

		/// <summary>
		/// Save data to employee role table 
		/// </summary>
		/// <param name="employeeRoles"></param>
		/// <returns></returns>
        public async Task<SaveEmployeeRoleResponse> SaveAsync(EmployeeRoles employeeRoles)
		{
			try
			{
				await _employeeRoleRepository.AddAsync(employeeRoles);
				await _unitOfWork.CompleteAsync();
			
				return new SaveEmployeeRoleResponse(employeeRoles);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveEmployeeRoleResponse($"An error occurred when saving the EmployeeRoles: {ex.Message}");
			}
		}

		/// <summary>
		/// Update data in the employee role table with user specified id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="employeeRoles"></param>
		/// <returns></returns>
		public async Task<SaveEmployeeRoleResponse> UpdateAsync(int id, EmployeeRoles employeeRoles)
		{
			var existingEmployeeRoles = await _employeeRoleRepository.FindByIdAsync(id);
			
			if (existingEmployeeRoles == null)
				return new SaveEmployeeRoleResponse("Employee not found.");
			
            existingEmployeeRoles.Department.dept_name= employeeRoles.Department.dept_name;
			existingEmployeeRoles.Department.priority= employeeRoles.Department.priority;
			existingEmployeeRoles.Department.phone_no= employeeRoles.Department.phone_no;
			existingEmployeeRoles.Department.remark= employeeRoles.Department.remark;
            existingEmployeeRoles.Role.Name= employeeRoles.Role.Name;
			existingEmployeeRoles.Role.Priority= employeeRoles.Role.Priority;
			existingEmployeeRoles.Role.Salary_range= employeeRoles.Role.Salary_range;
			existingEmployeeRoles.start_date = employeeRoles.start_date;
			existingEmployeeRoles.end_date= employeeRoles.end_date;
			existingEmployeeRoles.remark = employeeRoles.remark;
			existingEmployeeRoles.department_id=employeeRoles.department_id;
			existingEmployeeRoles.employee_id=employeeRoles.employee_id;
			existingEmployeeRoles.Employee.employeeId=existingEmployeeRoles.Employee.employeeId;
			existingEmployeeRoles.Department.dept_id=employeeRoles.Department.dept_id;
			existingEmployeeRoles.Department.branch_id=employeeRoles.Department.branch_id;
			existingEmployeeRoles.Department.Branches.name= employeeRoles.Department.Branches.name;
			existingEmployeeRoles.Department.Branches.phone_1= employeeRoles.Department.Branches.phone_1;
			existingEmployeeRoles.Department.Branches.phone_2= employeeRoles.Department.Branches.phone_2;
			existingEmployeeRoles.Department.Branches.Addresses.line_1= employeeRoles.Department.Branches.Addresses.line_1;
			existingEmployeeRoles.Department.Branches.Addresses.line_2= employeeRoles.Department.Branches.Addresses.line_2;
			existingEmployeeRoles.Department.Branches.Addresses.Township.Name= employeeRoles.Department.Branches.Addresses.Township.Name;
			existingEmployeeRoles.Department.Branches.Addresses.Township.city.Name= employeeRoles.Department.Branches.Addresses.Township.city.Name;
			existingEmployeeRoles.Department.Branches.Addresses.region= employeeRoles.Department.Branches.Addresses.region;
			existingEmployeeRoles.Department.Branches.Addresses.country= employeeRoles.Department.Branches.Addresses.country;
			existingEmployeeRoles.Employee.employee_No = employeeRoles.Employee.employee_No;
			existingEmployeeRoles.Employee.employee_Name= employeeRoles.Employee.employee_Name;
            existingEmployeeRoles.Employee.email=employeeRoles.Employee.email;
           existingEmployeeRoles.Employee.dob=employeeRoles.Employee.dob;
           existingEmployeeRoles.Employee.nrc=employeeRoles.Employee.nrc;	
			existingEmployeeRoles.Employee.phone_no_work=employeeRoles.Employee.phone_no_work;
		   existingEmployeeRoles.Employee.phone_no_personal=employeeRoles.Employee.phone_no_personal;
			existingEmployeeRoles.Employee.gender=employeeRoles.Employee.gender;
			existingEmployeeRoles.Employee.marital_status=employeeRoles.Employee.marital_status;
			existingEmployeeRoles.Employee.nationality=employeeRoles.Employee.nationality;
		    existingEmployeeRoles.Employee.religion=employeeRoles.Employee.religion;
		    existingEmployeeRoles.Employee.permanent_address=employeeRoles.Employee.permanent_address;
			existingEmployeeRoles.Employee.education_background=employeeRoles.Employee.education_background;
			existingEmployeeRoles.Employee.joined_date=employeeRoles.Employee.joined_date;
			existingEmployeeRoles.Employee.employee_state=employeeRoles.Employee.employee_state;
			existingEmployeeRoles.Employee.Addresses.line_1= employeeRoles.Employee.Addresses.line_1;
			existingEmployeeRoles.Employee.Addresses.line_2= employeeRoles.Employee.Addresses.line_2;
			existingEmployeeRoles.Employee.Addresses.region=employeeRoles.Employee.Addresses.region;
			existingEmployeeRoles.Employee.Addresses.country= employeeRoles.Employee.Addresses.country;
			existingEmployeeRoles.rankId=employeeRoles.rankId;
			existingEmployeeRoles.Ranks.Rank_Id=employeeRoles.Ranks.Rank_Id;
			existingEmployeeRoles.Ranks.Name=employeeRoles.Ranks.Name;


			try
			{
				_employeeRoleRepository.Update(existingEmployeeRoles);
				await _unitOfWork.CompleteAsync();

				 return new SaveEmployeeRoleResponse(existingEmployeeRoles);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveEmployeeRoleResponse($"An error occurred when saving the EmployeeRole: {ex.Message}");
			}
		}

		/// <summary>
		/// Delete data  from employee role table with user specified role
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<SaveEmployeeRoleResponse> DeleteAsync(int id)
		{
			var existingEmployeeRoles = await _employeeRoleRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingEmployeeRoles == null)
				return new SaveEmployeeRoleResponse("EmployeeRoles not found.");
			
			try
			{
				_employeeRoleRepository.Remove(existingEmployeeRoles);
				await _unitOfWork.CompleteAsync();


				return new SaveEmployeeRoleResponse("Success");
			}
			catch (Exception ex) 
			{
				// Do some logging stuff
				return new SaveEmployeeRoleResponse($"An error occurred when deleting the EmployeeRoles: {ex.Message}");
			}
		}

        public async Task<IEnumerable<EmployeeRoles>> FindByDeptIdAsync(int deptId)
        {
           return await  _employeeRoleRepository.FindByDeptId(deptId);
        }
		 public async Task<IEnumerable<EmployeeRoles>> FindByEmpId(int empId)
        {
           return await  _employeeRoleRepository.FindByEmpId(empId);
        }
    }
}