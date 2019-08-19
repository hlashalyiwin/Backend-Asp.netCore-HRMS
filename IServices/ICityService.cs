using System.Collections.Generic;
using System.Threading.Tasks;
using HR_MANAGEMENT.Communication;
using Hr_Management_final_api.Communication;
//using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IServices
{
    public interface ICityService
    {
        Task<IEnumerable<City>> ListAsync();//return all City data

        Task<City> GetByIdAsync(int id); //find by id for existing City item                       
        Task<SaveCityResponse> SaveAsync(City city); //add City item   
        Task<SaveCityResponse> UpdateAsync(int id,City city); //update City item
        Task<SaveCityResponse> DeleteAsync(int id);  //delete City item
    }
}