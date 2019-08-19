using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IRepositories
{
    public interface ITrainingRepository
    {
        //interface ITrainingRepository for TrainingRepository
     Task<IEnumerable<Training>> ListAsync();//return all Training data
	 Task AddAsync(Training training); //add Training item

     Task<Training> FindByIdAsync(int id); //find by id for existing Training item
	 void Update(Training training); //for update Training item
     void Remove(Training training); //for removing Training item     
    }
}