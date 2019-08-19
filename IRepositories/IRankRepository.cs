using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IRepositories
{
    public interface IRankRepository
    {
     Task<IEnumerable<Rank>> ListAsync();
	 Task AddAsync(Rank rank);
      Task<Rank> FindByIdAsync(int rankId);
	 void Update(Rank rank);
     void Remove(Rank rank);    
    }
}