//Created by Soe Min Thu
//Created date is 21.6.2019

using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IServices {
    //IShiftService interface
    //return an enumeration of shift
    public interface IShiftService {
        Task<IEnumerable<Shift>> ListAsync ();
        Task<Shift> GetByIdAsync (int id);
        Task<SaveShiftResponse> SaveAsync (Shift shift);
        Task<SaveShiftResponse> UpdateAsync (int id, Shift shift);
        Task<SaveShiftResponse> DeleteAsync (int id);
    }

}