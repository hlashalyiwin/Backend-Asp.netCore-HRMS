using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;

 //to manage data from databases.
namespace Hr_Management_final_api.Domain.Repositories
{ public class TrainingRepository : BaseRepository, ITrainingRepository
    {
        public TrainingRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Training>> ListAsync()
        {
            return await _context.Trainings.ToListAsync();
             
                                          
        }
        public async Task<Training> GetByIdAsync(int id){
            return await _context.Trainings.FindAsync(id);
        }


        public async Task AddAsync(Training Training)
	    {
		    await _context.Trainings.AddAsync(Training);
        }


        public async Task<Training> FindByIdAsync(int id)
        {
            var training= await _context.Trainings.FindAsync(id);

            
	        return training;
        }

        public void Update(Training training)
        {
            
	        _context.Trainings.Update(training);
        }

        public void Remove(Training training)
        {
	        _context.Trainings.Remove(training);

        }
    }
}