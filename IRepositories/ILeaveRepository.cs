using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Domain.IRepositories
{
    public interface ILeaveRepository
    {

     Task<IEnumerable<Leave>> ListAsync();//return all leave data
	 Task AddAsync(Leave leave); //add leave item

     Task<Leave> FindByIdAsync(int id); //find by id for existing leave item
	 void Update(Leave leave);
     void Remove(Leave leave); //for removing leave item
    }
         
}