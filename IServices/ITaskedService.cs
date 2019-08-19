//Created by Sai Nay Lynn
//Created date is 21.6.2019

using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IServices {
    //ITaskedService interface
    //return an enumeration of tasked
    public interface ITaskedService {
        Task<IEnumerable<Tasked>> ListAsync ();
        Task<Tasked> GetByIdAsync (int id);
        Task<SaveTaskedResponse> SaveAsync (Tasked tasked);
        Task<SaveTaskedResponse> UpdateAsync (int id, Tasked tasked);
        Task<SaveTaskedResponse> DeleteAsync (int id);
    }

}