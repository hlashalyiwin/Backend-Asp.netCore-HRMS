//Created by Soe Min Thu
//Created date is 21.6.2019

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Hr_Management_final_api.IServices;

namespace Hr_Management_final_api.Domain.Services {
     //to get the list of objects..
    //ShiftService class. This class is implements IShiftService interface
    public class ShiftService : IShiftService {
        private readonly IShiftRepository _shiftRepository;
        private readonly IUnitOfWork _unitOfWork;

        //ShiftService constructor. This constructor has one argument shiftRepository
        public ShiftService (IShiftRepository shiftRepository, IUnitOfWork unitOfWork) {
            _shiftRepository = shiftRepository;
            _unitOfWork = unitOfWork;
        }

        //ListAsync method
        public async Task<IEnumerable<Shift>> ListAsync () {
            return await _shiftRepository.ListAsync ();
        }

        //GetByIdAsync method
        public async Task<Shift> GetByIdAsync (int id) {
            return await _shiftRepository.FindByIdAsync (id);
        }

        //SaveAsync method
        public async Task<SaveShiftResponse> SaveAsync (Shift shift) {
            try {
                await _shiftRepository.AddAsync (shift);
                await _unitOfWork.CompleteAsync ();

                return new SaveShiftResponse (shift);
            } catch (Exception ex) {
                // Do some logging stuff
                return new SaveShiftResponse ($"An error occurred when saving the shift: {ex.Message}");
            }
        }

        //UpdateAsync method
        public async Task<SaveShiftResponse> UpdateAsync (int id, Shift shift) {
            var existingShift = await _shiftRepository.FindByIdAsync (id);

            if (existingShift == null)
                return new SaveShiftResponse ("Shift not found.");

            existingShift.Name = shift.Name;
            existingShift.Start_Time = shift.Start_Time;
            existingShift.End_Time = shift.End_Time;

            try {
                _shiftRepository.Update (existingShift);
                await _unitOfWork.CompleteAsync ();
                return new SaveShiftResponse (existingShift);
            } catch (Exception ex) {
                // Do some logging stuff
                return new SaveShiftResponse ($"An error occurred when updating the shift: {ex.Message}");
            }
        }

        //DeleteAsync method
        public async Task<SaveShiftResponse> DeleteAsync (int id) {
            var existingShift = await _shiftRepository.FindByIdAsync (id);

            if (existingShift == null)
                return new SaveShiftResponse ("Shift not found.");

            try {
                _shiftRepository.Remove (existingShift);
                await _unitOfWork.CompleteAsync ();

                return new SaveShiftResponse (existingShift);
            } catch (Exception ex) {
                // Do some logging stuff
                return new SaveShiftResponse ($"An error occurred when deleting the shift: {ex.Message}");
            }
        }
    }
}