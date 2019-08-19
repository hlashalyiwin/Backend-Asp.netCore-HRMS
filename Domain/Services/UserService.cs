using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Hr_Management_final_api.IServices;

namespace Hr_Management_final_api.Domain.Services
{
    public class UserService : IUserService
 {
         private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        //ShiftService constructor. This constructor has one argument shiftRepository
        public UserService (IUserRepository userRepository, IUnitOfWork unitOfWork) {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<SaveUserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindByIdAsync (id);

            if (existingUser == null)
                return new SaveUserResponse ("Shift not found.");

            try {
                _userRepository.Remove (existingUser);
                await _unitOfWork.CompleteAsync ();

                return new SaveUserResponse (existingUser);
            } catch (Exception ex) {
                // Do some logging stuff
                return new SaveUserResponse ($"An error occurred when deleting the shift: {ex.Message}");
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
              return await _userRepository.FindByIdAsync (id);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync ();
        }

        public async Task<SaveUserResponse> SaveAsync(User user)
        {
            try {
                await _userRepository.AddAsync (user);
                await _unitOfWork.CompleteAsync ();

                return new SaveUserResponse (user);
            } catch (Exception ex) {
                // Do some logging stuff
                return new SaveUserResponse ($"An error occurred when saving the shift: {ex.Message}");
            }
        }

        public async Task<SaveUserResponse> UpdateAsync(int id, User user)
        {
            var existingUser = await _userRepository.FindByIdAsync (id);

            if (existingUser == null)
                return new SaveUserResponse ("User not found.");

            existingUser.firstName = user.firstName;
            existingUser.lastName = user.lastName;
            existingUser.userName = user.userName;
            existingUser.email = user.email;
            existingUser.password = user.password;
            existingUser.phone = user.phone;
           existingUser.position = user.position;

            try {
                _userRepository.Update (existingUser);
                await _unitOfWork.CompleteAsync ();
                return new SaveUserResponse (existingUser);
            } catch (Exception ex) {
                // Do some logging stuff
                return new SaveUserResponse ($"An error occurred when updating the shift: {ex.Message}");
            }
        }
    }
}