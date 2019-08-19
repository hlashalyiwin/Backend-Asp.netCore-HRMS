using System.Collections.Generic;
using System.Threading.Tasks;
using HR_MANAGEMENT.Communication;
using Hr_Management_final_api.Domain.Models;

namespace HR_MANAGEMENT.IServices
{
    //return an enumeration of address
    public interface IAddressService
    {
                             
        Task<IEnumerable<Address>> ListAsync();//return all address data                   

        Task<Address> GetByIdAsync(int id);          //find by id for existing address item              
        Task<SaveAddressResponse> SaveAsync(Address address);    //add address item
        Task<SaveAddressResponse> UpdateAsync(int id,Address address);     //update address item  
        Task<SaveAddressResponse> DeleteAsync(int id);        //delete address item
    }
}