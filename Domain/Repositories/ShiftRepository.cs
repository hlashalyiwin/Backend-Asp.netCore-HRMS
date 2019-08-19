//Created by Soe Min Thu
//Created date is 21.6.2019

using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;
 //to manage data from databases.
namespace Hr_Management_final_api.Domain.Repositories {
    //ShiftRepository class. This class extends BaseRepository class and implements IShiftRepository interface
    public class ShiftRepository : BaseRepository, IShiftRepository {
        //ShiftRepository constructor. This constructor has one argument context
        public ShiftRepository (AppDbContext context) : base (context) { }

        //ListAsync method
        public async Task<IEnumerable<Shift>> ListAsync () {
            return await _context.Shifts.ToListAsync ();
        }

        //AddAsync method
        public async Task AddAsync (Shift shift) {
            await _context.Shifts.AddAsync (shift);
        }

        //FindByIdAsync method
        public async Task<Shift> FindByIdAsync (int id) {
            return await _context.Shifts.FindAsync (id);
        }

        //Update method
        public void Update (Shift shift) {
            _context.Shifts.Update (shift);
        }

        //Remove method
        public void Remove (Shift shift) {
            _context.Shifts.Remove (shift);
        }

    }
}