using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_final_api.Domain.Repositories
{
    //to manage data from databases.
    public class AnnouncementRepository : BaseRepository, IAnnouncementRepository
    {
        public AnnouncementRepository(AppDbContext context) : base(context)
        {
        }
        //to add announcement
        public async Task AddAsync(Announcement announcement)
        {
            await _context.Announcement.AddAsync(announcement);
        }
        //to get announcement by id
        public async Task<Announcement> FindByIdAsync(int id)
        {
           return await _context.Announcement.FindAsync(id);
        }
        //to take list announcement
        public async Task<IEnumerable<Announcement>> ListAsync()
        {
            return await _context.Announcement.ToListAsync();          

        }
        //to remove announcement
        public void Remove(Announcement announcement)
        {
          _context.Announcement.Remove(announcement); 

        }
        //to update announcement
        public void Update(Announcement announcement)
        {
             _context.Announcement.Update(announcement); 
        }
    }
}