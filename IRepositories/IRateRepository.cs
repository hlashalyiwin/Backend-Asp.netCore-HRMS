using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IRepositories
{
    public interface IRateRepository
    {//interface IRateRepository for RateRepository
    Task<IEnumerable<Rate>> ListAsync();
	 Task AddAsync(Rate rate);
     

     Task<Rate> FindByIdAsync(int rateId);
	 void Update(Rate rate);
     void Remove(Rate rate);       
    }
}