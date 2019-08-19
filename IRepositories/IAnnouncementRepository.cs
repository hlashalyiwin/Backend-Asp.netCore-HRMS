using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;


namespace Hr_Management_final_api.IRepositories
{
    public interface IAnnouncementRepository
    {
        Task<IEnumerable<Announcement>> ListAsync();    //return all announcement data
        Task AddAsync(Announcement announcement);           //add announcement item
        
        Task<Announcement> FindByIdAsync(int id);       //find by id for existing announcement item
	    void Update(Announcement announcement);             //update announcement item
        void Remove(Announcement announcement);  //remove announcement item
    }
}