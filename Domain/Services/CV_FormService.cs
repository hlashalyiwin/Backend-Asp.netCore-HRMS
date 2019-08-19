using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HR_MANAGEMENT.Communication;
using HR_MANAGEMENT.IServices;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;

namespace HR_MANAGEMENT.Domain.Services
{
	 //to get the list of objects.
    public class CV_FormService : ICV_FormService
    {
        private readonly ICV_FormRepository _cvRepository;
        private readonly IUnitOfWork _unitOfWork;

        public  CV_FormService (ICV_FormRepository attendenceRepository,IUnitOfWork unitofwork)
        {
            _cvRepository = attendenceRepository;
			_unitOfWork = unitofwork;
        }

        public async Task<SaveCV_FormResponse> DeleteAsync(int id)
        {
            var existingAttendence = await _cvRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingAttendence == null)
				return new SaveCV_FormResponse("Attendence not found.");
			
			try
			{
				_cvRepository.Remove(existingAttendence);
				await _unitOfWork.CompleteAsync();


				return new SaveCV_FormResponse("Data Delete");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveCV_FormResponse($"An error occurred when deleting the attendence: {ex.Message}");
			}
        }

        public async Task<IEnumerable<CV_Form>> FindByAnnouncementDate(int day, int month, int year)
        {
              return await  _cvRepository.FindByAnnouncementDate(day,month,year);
        }

        public async Task<IEnumerable<CV_Form>> FindByAnnouncementId(int announcementId)
        {
            return await  _cvRepository.FindByAnnouncementId(announcementId);
        }

        public async Task<CV_Form> GetByIdAsync(int id)
        {
            return await _cvRepository.FindByIdAsync(id);        

        }

        public async Task<IEnumerable<CV_Form>> ListAsync()
        {
            await _unitOfWork.CompleteAsync();
            return await _cvRepository.ListAsync() ;
        }

        public async Task<SaveCV_FormResponse> SaveAsync(CV_Form cv)
        {
           try
			{
				await _cvRepository.AddAsync(cv);
				await _unitOfWork.CompleteAsync();
			
				return new SaveCV_FormResponse(cv);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveCV_FormResponse($"An error occurred when saving the CV_form: {ex.Message}");
			}
        }

        public async Task<SaveCV_FormResponse> UpdateAsync(int id,CV_Form cv )
        {
            var existingCV = await _cvRepository.FindByIdAsync(id);
			
			if (_cvRepository == null)
            	return new SaveCV_FormResponse("CV_Form not found.");
			
			//existingCV.announcement_id = cv.announcement_id;
			existingCV.date= cv.date;
			existingCV.name = cv.name;
			existingCV.date= cv.date;
			existingCV.email = cv.email;
			existingCV.date= cv.date;
			existingCV.dob = cv.dob;
			existingCV.nrc= cv.nrc;
			existingCV.ph_no_work = cv.ph_no_work;
			existingCV.ph_no_personal= cv.ph_no_personal;
			existingCV.gender = cv.gender;
			existingCV.marital_status= cv.marital_status;
			existingCV.nationality = cv.nationality;
			existingCV.religion= cv.religion;
			existingCV.permanent_address = cv.permanent_address;
			existingCV.qualification= cv.qualification;
			existingCV.address_id= cv.address_id;
			existingCV.joined_date= cv.joined_date;
			existingCV.status= cv.status;
			existingCV.Addresses.line_1= cv.Addresses.line_1;
			existingCV.Addresses.line_2= cv.Addresses.line_2;
			existingCV.Addresses.Township.Name= cv.Addresses.Township.Name;
			existingCV.Addresses.Township.city.Name= cv.Addresses.Township.city.Name;
			existingCV.Addresses.region= cv.Addresses.region;
			existingCV.Addresses.country= cv.Addresses.country;
			existingCV.Announcement.description= cv.Announcement.description;
			existingCV.Announcement.title= cv.Announcement.title;
			existingCV.Announcement.date= cv.Announcement.date;
			
           
			
			try
			{
				_cvRepository.Update(existingCV);
				await _unitOfWork.CompleteAsync();
                return new SaveCV_FormResponse(existingCV);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveCV_FormResponse($"An error occurred when saving the attendence: {ex.Message}");
			}
        }
    }
}