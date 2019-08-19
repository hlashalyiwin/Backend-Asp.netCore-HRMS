//Developed by Nang Ah: Mon(Lashio)

using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;


namespace Hr_Management_final_api.Domain.IRepositories
{
  //IProduct_Performance_Repository interface
  //interface IProduct_PerformanceRepository for Product_PerformanceRepository
    public interface IProduct_Performance_Repository
    {
         Task<IEnumerable<Product_Performance>> ListAsync();
        Task AddAsync(Product_Performance Product_Performancel);
        
        Task<Product_Performance> FindByIdAsync(int id);
        Task<IEnumerable<Product_Performance>> FindByDate (int day,int month,int year);
	       void Update(Product_Performance Product_Performance);
          void Remove(Product_Performance Product_Performance);
    }
}