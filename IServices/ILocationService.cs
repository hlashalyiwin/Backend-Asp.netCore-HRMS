using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IServices
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> ListAsync();                    //return all leave data

        Task<Location> GetByIdAsync(int id);                       //find by id for existing leave item
        Task<SaveLocationResponse> SaveAsync(Location location);    //add leave item
        Task<SaveLocationResponse> UpdateAsync(int id,Location location);        //update leave item
        Task<SaveLocationResponse> DeleteAsync(int id); //delete leave item 
    }
}