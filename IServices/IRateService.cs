using System.Collections.Generic;
using System.Threading.Tasks;

using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace HR_MANAGEMENT.IServices
{
    public interface IRateService
    {
        Task<IEnumerable<Rate>> ListAsync();                    //return all shipping data
         
        Task<Rate> GetByIdAsync(int rateId);                        //add shipping item
        Task<SaveRateResponse> SaveAsync(Rate rate);    //find by id for existing shipping item
        Task<SaveRateResponse> DeleteAsync(int rateId);  
        Task<SaveRateResponse> UpdateAsync(int rateId,Rate rate);        //update shipping item
    }
}