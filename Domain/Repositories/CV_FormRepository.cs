using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace Hr_Management_final_api.Domain.Repositories
{
    //to manage data from databases.
   public class CV_FormRepository: BaseRepository, ICV_FormRepository
    {
        public CV_FormRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(CV_Form cv)
        {
           await _context.CV_Forms.AddAsync(cv);
        }

       public async Task<IEnumerable<CV_Form>> FindByAnnouncementDate(int day, int month, int year)
        {
            var annDate=await _context.CV_Forms.Where(cv=>cv.Announcement.date.Day==day)
            .Where(cv=>cv.Announcement.date.Month==month)
            .Where(cv=>cv.Announcement.date.Year==year)
            .Include(cv=>cv.Addresses)
            // .Include(cv=>cv.Rank)
                                              .Include(ann=>ann.Announcement).ToListAsync();
            return annDate;
        }

        public async Task<IEnumerable<CV_Form>> FindByAnnouncementId(int announcementId)
        {
           var announcement=await _context.CV_Forms.Where(cv=>cv.announcement_id==announcementId)
           .Include(cv=>cv.Addresses)
           .Include(cv=>cv.Announcement)
                            .ToListAsync();
                return announcement;
        }
        public async Task<CV_Form> FindByIdAsync(int id)
        {
             
        var cvForm= await _context.CV_Forms.FindAsync(id);
        var address=await _context.Addresses.FindAsync(cvForm.address_id);
        var announcement=await _context.Announcement.FindAsync(cvForm.announcement_id);

        cvForm.Addresses=address;
        cvForm.Announcement=announcement;
        return cvForm;
        
        }

        public async Task<IEnumerable<CV_Form>> ListAsync()
        {
            return await _context.CV_Forms.Include(p => p.Addresses)
                                          .Include(p => p.Announcement)
                                            .ToListAsync();
        }

        public void Remove(CV_Form cv)
        {
             _context.CV_Forms.Remove(cv);
        }

        public void Update(CV_Form cv)
        {
	        _context.CV_Forms.Update(cv);
        }

    }  
}