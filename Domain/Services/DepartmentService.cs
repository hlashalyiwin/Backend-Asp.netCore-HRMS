using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HR_MANAGEMENT.IServices;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;

namespace HR_MANAGEMENT.Domain.Services
{ //to get the list of objects..
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public  DepartmentService (IDepartmentRepository departmentRepository,IUnitOfWork unitofwork)
        {
            _departmentRepository = departmentRepository;
			_unitOfWork = unitofwork;
        }

        public async Task<SaveDepartmentResponse> DeleteAsync(int id)
        {
            var existingDepartment = await _departmentRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingDepartment == null)
				return new SaveDepartmentResponse("Departmentnot found.");
			
			try
			{
				_departmentRepository.Remove(existingDepartment);
				await _unitOfWork.CompleteAsync();


				return new SaveDepartmentResponse("Data Delete");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveDepartmentResponse($"An error occurred when deleting the department: {ex.Message}");
			}
        }

        public async Task<IEnumerable<Department>> FindByBranchsId(int branchId)
        {
            return await  _departmentRepository.FindByBranchId(branchId);
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _departmentRepository.FindByIdAsync(id);        

        }

        public async Task<IEnumerable<Department>> ListAsync()
        {
            await _unitOfWork.CompleteAsync();
            return await _departmentRepository.ListAsync() ;
        }

        public async Task<SaveDepartmentResponse> SaveAsync(Department department)
        {
           try
			{
				await _departmentRepository.AddAsync(department);
				await _unitOfWork.CompleteAsync();
			
				return new SaveDepartmentResponse(department);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveDepartmentResponse($"An error occurred when saving the Department: {ex.Message}");
			}
        }

        public async Task<SaveDepartmentResponse> UpdateAsync(int id, Department department)
        {
            var existingDepartment = await _departmentRepository.FindByIdAsync(id);
			
			if (existingDepartment == null)
            	return new SaveDepartmentResponse("Employee not found.");
			
			///Authorized By NiNiWinMay(Table Joining) 23.6.2019
			existingDepartment.dept_name = department.dept_name;
			existingDepartment.priority= department.priority;
			
			existingDepartment.phone_no=department.phone_no;
		    existingDepartment.remark=department.remark;
			existingDepartment.Branches.name= department.Branches.name;
			existingDepartment.Branches.phone_1= department.Branches.phone_1;
			existingDepartment.Branches.phone_2= department.Branches.phone_2;
			existingDepartment.Branches.Addresses.line_1= department.Branches.Addresses.line_1;
		
			existingDepartment.Branches.Addresses.region= department.Branches.Addresses.region;
			existingDepartment.Branches.Addresses.country= department.Branches.Addresses.country;
           
			
			try
			{
				_departmentRepository.Update(existingDepartment);
				await _unitOfWork.CompleteAsync();
                return new SaveDepartmentResponse(existingDepartment);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveDepartmentResponse($"An error occurred when saving the Department: {ex.Message}");
			}
        }
    }
}