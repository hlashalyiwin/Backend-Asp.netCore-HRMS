using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.IServices;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;

namespace Hr_Management_final_api.Domain.Services
{
    public class TownshipService : ITownshipService
    {
		private readonly ITownshipRepository _townshipRepository;
        private readonly IUnitOfWork _unitOfWork;

        //public ITownshipRepository TownshipRepository = _townshipRepository;
        public TownshipService(ITownshipRepository townshipRepository,IUnitOfWork unitofwork)
        {
            _townshipRepository = townshipRepository;
			_unitOfWork = unitofwork;
        }

        public async Task<SaveTownshipResponse> DeleteAsync(int id)
        {
            var existingTownship = await _townshipRepository.FindByIdAsync (id);

            if (existingTownship == null)
                return new SaveTownshipResponse ("Tasked not found.");

            try {
                _townshipRepository.Remove (existingTownship);
                await _unitOfWork.CompleteAsync ();

                return new SaveTownshipResponse (existingTownship);
            } catch (Exception ex) {
                // Do some logging stuff
                return new SaveTownshipResponse ($"An error occurred when deleting the tasked: {ex.Message}");
            }
        }

        public async Task<Township> GetByIdAsync(int id)
        {
            return await _townshipRepository.FindByIdAsync (id);
        }

        public async Task<IEnumerable<Township>> ListAsync()
        {
            return await _townshipRepository.ListAsync ();
        }
        

        public async Task<SaveTownshipResponse> SaveAsync(Township township)
        {
			try {
                await _townshipRepository.AddAsync (township);
                await _unitOfWork.CompleteAsync ();

                return new SaveTownshipResponse (township);
            } catch (Exception ex) {
                // Do some logging stuff
                return new SaveTownshipResponse ($"An error occurred when saving the tasked: {ex.Message}");
            }
        }

        public async Task<SaveTownshipResponse> UpdateAsync(int id, Township township)
        {
            //throw new NotImplementedException();
			var existingTownship = await _townshipRepository.FindByIdAsync (id);

            if (existingTownship == null)
                return new SaveTownshipResponse ("Tasked not found.");

            existingTownship.Name = township.Name;
            existingTownship.city.Name= township.city.Name;

            try {
                _townshipRepository.Update (existingTownship);
                await _unitOfWork.CompleteAsync ();
                return new SaveTownshipResponse (existingTownship);
            } catch (Exception ex) {
                // Do some logging stuff
                return new SaveTownshipResponse ($"An error occurred when updating the tasked: {ex.Message}");
            }
        }
    }
}