using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IServices
{
    public interface ITrainingService
    {
        //return an enumeration of training
        Task<IEnumerable<Training>> ListAsync();
         
         Task<Training> GetByIdAsync(int id);
        Task<SaveTrainingResponse> SaveAsync(Training Training);
         Task<SaveTrainingResponse> UpdateAsync(int id, Training Training);
        Task<SaveTrainingResponse> DeleteAsync(int id);   
    }
}