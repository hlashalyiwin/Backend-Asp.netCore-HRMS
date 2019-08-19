using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Microsoft.EntityFrameworkCore;
 //to manage data from databases.
namespace Hr_Management_final_api.Domain.Repositories {
    public class PointRepository : BaseRepository, IPointRepository 
    {
        public PointRepository (AppDbContext context) : base (context) { }

        public async Task<IEnumerable<Point>> ListAsync () {
            return await _context.Points.ToListAsync ();
        }

        public async Task AddAsync (Point point) {
            await _context.Points.AddAsync (point);
        }

        public async Task<Point> FindByIdAsync (int id) {
            return await _context.Points.FindAsync (id);
        }

        public void Update (Point point) {
            _context.Points.Update (point);
        }

        public void Remove (Point point) {
            _context.Points.Remove (point);
        }

    }
}