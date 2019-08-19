//Created by Soe Min Thu
//Created date is 21.6.2019

using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IRepositories {
    //ShiftRepository interface
    //interface IShiftRepository for ShiftRepository
    public interface IShiftRepository {
        Task<IEnumerable<Shift>> ListAsync ();
        Task AddAsync (Shift shift);
        Task<Shift> FindByIdAsync (int id);
        void Update (Shift shift);
        void Remove (Shift shift);
    }
}