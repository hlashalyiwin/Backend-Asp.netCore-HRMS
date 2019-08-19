using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IRepositories
{
    public interface IDutyRosterDetailRepository
    {

     Task<IEnumerable<DutyRosterDetail>> ListAsync();//return all leave data
	 Task AddAsync(DutyRosterDetail dutyRosterDetail); //add leave item
    Task<IEnumerable<DutyRosterDetail>> findByEmpId(int empId);
     Task<DutyRosterDetail> FindByIdAsync(int id); //find by id for existing leave item
	 void Update(DutyRosterDetail dutyRosterDetail);
     void Remove(DutyRosterDetail dutyRosterDetail); //for removing leave item
    }
         
}