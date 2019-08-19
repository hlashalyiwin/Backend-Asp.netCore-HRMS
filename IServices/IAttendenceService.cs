using System.Collections.Generic;
using System.Threading.Tasks;
using HR_MANAGEMENT.Communication;
using Hr_Management_final_api.Domain.Models;

namespace HR_MANAGEMENT.IServices
{
    //return an enumeration of attendence
    public interface IAttendenceService
    {
        Task<IEnumerable<Attendence>> ListAsync();                    //return all attendence data
         
        Task<Attendence> GetByIdAsync(int id);   
        ///IList<Attendence> FindByName(int month,int year);    
         Task<IEnumerable<Attendence>> FindByName(int month,int year);    
                          //find by id for existing attendence item
         Task<IEnumerable<Attendence>> FindByEmpId(int empId);
        Task<IEnumerable<Attendence>> FindByDay(int day,int month,int year);            
        Task<SaveAttendenceResponse> SaveAsync(Attendence attendence);    //add attendence item
        Task<SaveAttendenceResponse> UpdateAsync(int id,Attendence attendence);        //update attendence item
        Task<SaveAttendenceResponse> DeleteAsync(int id);   //delete attendence item
    }
}