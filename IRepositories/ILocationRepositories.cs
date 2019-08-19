using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IRepositories
{
    public interface ILocationRepositories
    {
     Task<IEnumerable<Location>> ListAsync();//return all location data
	 Task AddAsync(Location location); //add location item

     Task<Location> FindByIdAsync(int id); //find by id for existing location item
	 void Update(Location location); //for update location item
     void Remove(Location location); //for removing location item   
    }
}