using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IRepositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> ListAsync();
	    Task AddAsync(City city);
        Task<City> FindByIdAsync(int id);
	    void Update(City city);
        void Remove(City city);
    }
}