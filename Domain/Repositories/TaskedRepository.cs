//Created by Sai Nay Lynn
//Created date is 21.6.2019

using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Microsoft.EntityFrameworkCore;
 //to manage data from databases.
namespace Hr_Management_final_api.Domain.Repositories {
    //ShiftRepository class. This class extends BaseRepository class and implements IShiftRepository interface
    public class TaskedRepository : BaseRepository, ITaskedRepository {
        //ShiftRepository constructor. This constructor has one argument context
        public TaskedRepository (AppDbContext context) : base (context) { }

        //ListAsync method
        public async Task<IEnumerable<Tasked>> ListAsync () {
            return await _context.Tasked.ToListAsync ();
        }

        //AddAsync method
        public async Task AddAsync (Tasked tasked) {
            await _context.Tasked.AddAsync (tasked);
        }

        //FindByIdAsync method
        public async Task<Tasked> FindByIdAsync (int id) {
            return await _context.Tasked.FindAsync (id);
        }

        //Update method
        public void Update (Tasked tasked) {
            _context.Tasked.Update (tasked);
        }

        //Remove method
        public void Remove (Tasked tasked) {
            _context.Tasked.Remove (tasked);
        }

    }
}