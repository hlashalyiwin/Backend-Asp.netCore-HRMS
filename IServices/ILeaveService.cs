using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Domain.IServices
{
    //return an enumeration of leave
    public interface ILeaveService
    {
      
        Task<IEnumerable<Leave>> ListAsync();                    //return all leave data

        Task<Leave> GetByIdAsync(int id);                       //find by id for existing leave item
        Task<SaveLeaveResponse> SaveAsync(Leave leave);    //add leave item
        Task<SaveLeaveResponse> UpdateAsync(int id,Leave leave);        //update leave item
        Task<SaveLeaveResponse> DeleteAsync(int id); //delete leave item
    }
}