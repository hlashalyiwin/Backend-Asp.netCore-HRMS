using System.Collections.Generic;
using System.Threading.Tasks;
using HR_MANAGEMENT.Communication;
using Hr_Management_final_api.Domain.Models;


namespace HR_MANAGEMENT.IServices
{
     //return an enumeration of announcement
    public interface IAnnouncementService
    {
        Task<IEnumerable<Announcement>> ListAsync();//return all announcement data                   

        Task<Announcement> GetByIdAsync(int id);          //find by id for existing announcement item              
        Task<SaveAnnouncementResponse> SaveAsync(Announcement address);    //add announcement item
        Task<SaveAnnouncementResponse> UpdateAsync(int id,Announcement address);     //update announcement item  
        Task<SaveAnnouncementResponse> DeleteAsync(int id);  //delete announcement item
    }
}