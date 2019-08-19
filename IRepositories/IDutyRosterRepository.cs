using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IRepositories {
    public interface IDutyRosterRepository {
        //interface IDutyRosterRepository for DutyRosterRepository
        Task<IEnumerable<DutyRoster>> ListAsync ();
        Task AddAsync (DutyRoster dutyRoster);
        Task<DutyRoster> FindByIdAsync (int id);
        void Update (DutyRoster dutyRoster);
        void Remove (DutyRoster dutyRoster);
    }
}