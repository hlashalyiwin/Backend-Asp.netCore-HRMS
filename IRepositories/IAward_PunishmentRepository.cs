using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IRepositories

{
    public interface IAward_PunishmentRepository
    //interface IAward_PubishmentRepository for Award_PunishmentRepository
        
    {
         Task<IEnumerable<Award_Punishment>> ListAsync();
         Task AddAsync(Award_Punishment award_punishment);
         Task<Award_Punishment> FindByIdAsync(int id);
	     void Update(Award_Punishment award_punishment);
         void Remove(Award_Punishment award_punishment);

    }  

}