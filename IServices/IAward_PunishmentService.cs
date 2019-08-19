using System.Collections.Generic;
using System.Threading.Tasks;
using HR_MANAGEMENT.Communication;
using Hr_Management_final_api.Domain.Models;

namespace HR_MANAGEMENT.IServices

{//return an enumeration of award_punishment
    public interface IAward_PunishmentService
    {
          Task<IEnumerable<Award_Punishment>> ListAsync();
          Task<Award_Punishment> GetByIdAsync(int id); //find by id for existing award_ punishment item   
          Task<SaveAward_PunishmentResponse> SaveAsync(Award_Punishment award_punishment);
          Task<SaveAward_PunishmentResponse> UpdateAsync(int id, Award_Punishment award_punishment);
          Task<SaveAward_PunishmentResponse> DeleteAsync(int id);

    }
}