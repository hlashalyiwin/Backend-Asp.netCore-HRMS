using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace HR_MANAGEMENT.IServicess {

    public interface IDutyRosterService {
        Task<IEnumerable<DutyRoster>> ListAsync ();
        Task<DutyRoster> GetByIdAsync (int id);
        Task<SaveDutyRosterResponse> SaveAsync (DutyRoster dutyRoster);
        Task<SaveDutyRosterResponse> UpdateAsync (int id, DutyRoster dutyRoster);
        Task<SaveDutyRosterResponse> DeleteAsync (int id);
    }

}