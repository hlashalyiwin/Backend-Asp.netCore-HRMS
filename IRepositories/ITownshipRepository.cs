using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;
namespace Hr_Management_final_api.IRepositories
{
    public interface ITownshipRepository
    {
    Task<IEnumerable<Township>> ListAsync();//return all leave data
	 Task AddAsync(Township township); //add leave item

     Task<Township> FindByIdAsync(int id); //find by id for existing leave item
	 void Update(Township township);
     void Remove(Township township); //for removing leave item
    }
}