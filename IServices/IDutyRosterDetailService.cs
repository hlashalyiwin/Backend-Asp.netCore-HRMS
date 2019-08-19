using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace HR_MANAGEMENT.IServices
{
    //return an enumeration of leave
    public interface IDutyRosterDetailService
    {
      
        Task<IEnumerable<DutyRosterDetail>> ListAsync();                    //return all leave data

        Task<DutyRosterDetail> GetByIdAsync(int id);   
         Task<IEnumerable<DutyRosterDetail>> findByEmpId(int empId);                    //find by id for existing leave item
        Task<SaveDutyRosterDetailResponse> SaveAsync(DutyRosterDetail dutyRosterDetail);    //add leave item
        Task<SaveDutyRosterDetailResponse> UpdateAsync(int id,DutyRosterDetail dutyRosterDetail);        //update leave item
        Task<SaveDutyRosterDetailResponse> DeleteAsync(int id); //delete leave item
    }
}