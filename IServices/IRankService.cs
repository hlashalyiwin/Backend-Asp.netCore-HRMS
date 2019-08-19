using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IServices
{
    public interface IRankService
    {
        Task<IEnumerable<Rank>> ListAsync();                    //return all shipping data
         
        Task<Rank> GetByIdAsync(int rankId);                        //add shipping item
        Task<SaveRankResponse> SaveAsync(Rank rate);    //find by id for existing shipping item
        Task<SaveRankResponse> DeleteAsync(int rankId);  
        Task<SaveRankResponse> UpdateAsync(int rankId,Rank rank);       
    }
}