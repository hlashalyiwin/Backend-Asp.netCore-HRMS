//Developed by Nang Ah: Mon(Lashio)

using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IServices
{//return an enumeration of productPerformance
    // IProductService interface
    public interface IProductService
    {
         Task<IEnumerable<Product_Performance>> ListAsync();
       
         Task<Product_Performance> GetByIdAsync(int id);
         Task<IEnumerable<Product_Performance>> FindByDate (int day,int month,int year);
         Task<SaveProduct_Performance_Response> SaveAsync(Product_Performance Product_Performance);
         Task<SaveProduct_Performance_Response> UpdateAsync(int id, Product_Performance Product_Performance);  
         Task<SaveProduct_Performance_Response> DeleteAsync(int id);
    }
}