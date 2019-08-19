using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IServices;

namespace Hr_Management_final_api.Domain.Services {
     //to get the list of objects..
    public class PointService : IPointService {

        private readonly IPointRepository _pointRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PointService (IPointRepository pointRepository, IUnitOfWork unitOfWork) {
            _pointRepository = pointRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Point>> ListAsync () {
            return await _pointRepository.ListAsync ();
        }

        public async Task<Point> GetByIdAsync (int id) {
            return await _pointRepository.FindByIdAsync (id);
        }

        public async Task<SavePointResponse> SaveAsync (Point point) {
            try {
                await _pointRepository.AddAsync (point);
                await _unitOfWork.CompleteAsync ();

                return new SavePointResponse (point);
            } catch (Exception ex) {
                // Do some logging stuff
                return new SavePointResponse ($"An error occurred when saving the point: {ex.Message}");
            }
        }

        public async Task<SavePointResponse> UpdateAsync (int id, Point point) {
            var existingPoint = await _pointRepository.FindByIdAsync (id);

            if (existingPoint == null)
                return new SavePointResponse ("Point not found.");

            existingPoint.Name = point.Name;
            existingPoint.Price = point.Price;
            existingPoint.Remark = point.Remark;

            try {
                _pointRepository.Update (existingPoint);
                await _unitOfWork.CompleteAsync ();

                return new SavePointResponse (existingPoint);
            } catch (Exception ex) {
                // Do some logging stuff
                return new SavePointResponse ($"An error occurred when updating the point: {ex.Message}");
            }
        }

        public async Task<SavePointResponse> DeleteAsync (int id) {
            var existingPoint = await _pointRepository.FindByIdAsync (id);

            if (existingPoint == null)
                return new SavePointResponse ("Point not found.");

            try {
                _pointRepository.Remove (existingPoint);
                await _unitOfWork.CompleteAsync ();

                return new SavePointResponse (existingPoint);
            } catch (Exception ex) {
                // Do some logging stuff
                return new SavePointResponse ($"An error occurred when deleting the point: {ex.Message}");
            }
        }
    }
}