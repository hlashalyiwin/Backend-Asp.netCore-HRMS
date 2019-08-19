using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Hr_Management_final_api.IServices;

namespace Hr_Management_final_api.Domain.Services
{ //to get the list of objects..
    public class RoleService: IRoleService
    {

    private readonly IRoleRepository _roleRepository;
	private readonly IUnitOfWork _unitOfWork;

	public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
	{
		_roleRepository = roleRepository;
		_unitOfWork = unitOfWork;
	}
        public async Task<SaveRoleResponse> DeleteAsync(int id)
        { 
            var existingRole = await _roleRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingRole == null)
				return new SaveRoleResponse("Shipping not found.");
			
			try
			{
				_roleRepository.Remove(existingRole);
				await _unitOfWork.CompleteAsync();


				return new SaveRoleResponse("Data Delete");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveRoleResponse($"An error occurred when deleting the Leave: {ex.Message}");
			}
          
        }

        public async Task<Role> GetByIdAsync(int id)
        {
          return await _roleRepository.FindByIdAsync(id); 
        }

        public async Task<IEnumerable<Role>> ListAsync()
        {
            return await _roleRepository.ListAsync() ;  

        }

        public async Task<SaveRoleResponse> SaveAsync(Role role)
        {
            try
			{
				await _roleRepository.AddAsync(role);
				await _unitOfWork.CompleteAsync();
			
				return new SaveRoleResponse(role);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveRoleResponse($"An error occurred when saving the Department: {ex.Message}");
			}
        }

        public async Task<SaveRoleResponse> UpdateAsync(int id, Role role)
        {
            var existingRole= await _roleRepository.FindByIdAsync(id);
			
			if (existingRole == null)
			return new SaveRoleResponse("Employee not found.");	
			
			existingRole.Name = role.Name;
			existingRole.Priority= role.Priority;
            existingRole.Salary_range=role.Salary_range;
            
			

			
			try
			{
				_roleRepository.Update(existingRole);
				await _unitOfWork.CompleteAsync();
               return new SaveRoleResponse(existingRole);
			
			}
			catch (Exception ex)
			{
				// Do some logging stuff
                return new SaveRoleResponse($"An error occurred when saving the Department: {ex.Message}");
				
			}
        }

       
    }
}