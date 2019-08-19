using System.Collections.Generic;
using System.Threading.Tasks;
using HR_MANAGEMENT.Communication;
using Hr_Management_final_api.Domain.Models;

namespace HR_MANAGEMENT.IServices
{
    //return an enumeration of absence
    public interface IAbsenceService
    {
                            //return all shipping data
        Task<IEnumerable<Absence>> ListAsync();                    //return all shipping data

        Task<Absence> GetByIdAsync(int id);     
        Task<IEnumerable<Absence>> FindByNameAsync(string name); 
                   //add shipping item
        Task<SaveAbsenceResponse> SaveAsync(Absence absence);    //find by id for existing shipping item
        Task<SaveAbsenceResponse> UpdateAsync(int id,Absence absence);        //update shipping item
        Task<SaveAbsenceResponse> DeleteAsync(int id); 
    }
}