using System.Collections.Generic;
using System.Threading.Tasks;
using HR_MANAGEMENT.Communication;
using Hr_Management_final_api.Domain.Models;

namespace HR_MANAGEMENT.IServices
{
    //return an enumeration of cv_form
    public interface ICV_FormService
    {
        Task<IEnumerable<CV_Form>> ListAsync();                    //return all cv_form data
        Task<IEnumerable<CV_Form>> FindByAnnouncementId(int announcementId);
        Task<IEnumerable<CV_Form>> FindByAnnouncementDate(int day,int month, int year);
        Task<CV_Form> GetByIdAsync(int id);                        //find by id for existing cv_form item
        Task<SaveCV_FormResponse> SaveAsync(CV_Form cv);    //add attendence item
        Task<SaveCV_FormResponse> UpdateAsync(int id,CV_Form cv);        //update cv_form item
        Task<SaveCV_FormResponse> DeleteAsync(int id);   //delete cv_form item
    }
}