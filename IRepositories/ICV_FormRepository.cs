using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IRepositories
{
    
    public interface ICV_FormRepository
    {
        Task<IEnumerable<CV_Form>> ListAsync();    //return all cv_form data
        Task AddAsync(CV_Form cv);           //add cv_form item
        Task<IEnumerable<CV_Form>> FindByAnnouncementDate(int day,int month, int year);
        Task<IEnumerable<CV_Form>> FindByAnnouncementId(int announcementId);
        Task<CV_Form> FindByIdAsync(int id);       //find by id for existing cv_form item
	    void Update(CV_Form cv);             //update cv_form item
        void Remove(CV_Form cv);  //remove cv_form item
    }
}