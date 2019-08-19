using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IServices
{
    public interface ITownshipService
    {
        Task<IEnumerable<Township>> ListAsync();                    //return all leave data

        Task<Township> GetByIdAsync(int id);                       //find by id for existing leave item
        Task<SaveTownshipResponse> SaveAsync(Township township);    //add leave item
        Task<SaveTownshipResponse> UpdateAsync(int id,Township township);        //update leave item
        Task<SaveTownshipResponse> DeleteAsync(int id); //delete leave item
    }
}