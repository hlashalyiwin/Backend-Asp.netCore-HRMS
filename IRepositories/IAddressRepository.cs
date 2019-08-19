using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IRepositories
{
    public interface IAddressRepository
    {
     Task<IEnumerable<Address>> ListAsync();     //return all address data
	 Task AddAsync(Address address);               //add address item

     Task<Address> FindByIdAsync(int id);          //find by id for existing address item
	 void Update(Address address);                 //update attendence item
     void Remove(Address address);             //for removing address item
    }
}