//Created by Sai Nay Lynn
//Created date is 21.6.2019

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IServices;

namespace Hr_Management_final_api.Domain.Services {
     //to get the list of objects..
    //TaskedService class. This class is implements ITaskedService interface
    public class TaskedService : ITaskedService {
        private readonly ITaskedRepository _taskedRepository;
        private readonly IUnitOfWork _unitOfWork;

        //TaskedService constructor. This constructor has one argument shiftRepository
        public TaskedService (ITaskedRepository taskedRepository, IUnitOfWork unitOfWork) {
            _taskedRepository = taskedRepository;
            _unitOfWork = unitOfWork;
        }

        //ListAsync method
        public async Task<IEnumerable<Tasked>> ListAsync () {
            return await _taskedRepository.ListAsync ();
        }

        //GetByIdAsync method
        public async Task<Tasked> GetByIdAsync (int id) {
            return await _taskedRepository.FindByIdAsync (id);
        }

        //SaveAsync method
        public async Task<SaveTaskedResponse> SaveAsync (Tasked tasked) {
            try {
                await _taskedRepository.AddAsync (tasked);
                await _unitOfWork.CompleteAsync ();

                return new SaveTaskedResponse (tasked);
            } catch (Exception ex) {
                // Do some logging stuff
                return new SaveTaskedResponse ($"An error occurred when saving the tasked: {ex.Message}");
            }
        }

        //UpdateAsync method
        public async Task<SaveTaskedResponse> UpdateAsync (int id, Tasked tasked) {
            var existingTasked = await _taskedRepository.FindByIdAsync (id);

            if (existingTasked == null)
                return new SaveTaskedResponse ("Tasked not found.");

            existingTasked.Name = tasked.Name;
            existingTasked.Start_Time = tasked.Start_Time;
            existingTasked.End_Time = tasked.End_Time;
            existingTasked.Status = tasked.Status;
            existingTasked.Remark = tasked.Remark;

            try {
                _taskedRepository.Update (existingTasked);
                await _unitOfWork.CompleteAsync ();
                return new SaveTaskedResponse (existingTasked);
            } catch (Exception ex) {
                // Do some logging stuff
                return new SaveTaskedResponse ($"An error occurred when updating the tasked: {ex.Message}");
            }
        }

        //DeleteAsync method
        public async Task<SaveTaskedResponse> DeleteAsync (int id) {
            var existingTasked = await _taskedRepository.FindByIdAsync (id);

            if (existingTasked == null)
                return new SaveTaskedResponse ("Tasked not found.");

            try {
                _taskedRepository.Remove (existingTasked);
                await _unitOfWork.CompleteAsync ();

                return new SaveTaskedResponse (existingTasked);
            } catch (Exception ex) {
                // Do some logging stuff
                return new SaveTaskedResponse ($"An error occurred when deleting the tasked: {ex.Message}");
            }
        }
    }
}