using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HR_MANAGEMENT.IServices;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Resources;
using Hr_Management_final_api.Domain.SaveResources;
using Hr_Management_final_api.Extensions;
using Microsoft.AspNetCore.Mvc;
namespace Hr_Management_final_api.Controllers 
{
	//to handle requests and responses. 
    [Route("/[controller]")]
    public class AddressController: Controller
    { 
        private readonly IAddressService _addressService;
		
        //private readonly AppDbContext _bdcontext;
		private readonly IMapper _mapper;
        public AddressController(IAddressService AddressService,IMapper mapper)
        {
           _addressService = AddressService;
			_mapper=mapper;
        }

		//  GET  address
        [HttpGet]
        public async Task<IEnumerable<AddressResource>> ListAsync() //
        {
            var address= await _addressService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Address>, IEnumerable<AddressResource>>(address);
            return resources;
			
        }
		

		//get address by id
		[HttpGet("{id}")]
		public async Task<ActionResult<AddressResource>> GetAddress(int id)
        {
            var addressItem = await _addressService.GetByIdAsync(id);

            if (addressItem == null)
            {
                return NotFound();
            }
			var resources = _mapper.Map<Address, AddressResource>(addressItem);
            return Ok(resources);
			
        }


		// POST address  
        [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Address address)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());  //test valid or not

		    var result = await _addressService.SaveAsync(address);

			if (!result.Success)
				return BadRequest(result.Message);

			return Ok();
		}

        //PUT address
        [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Address resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages()); //test valid or not
 
            //map data from SaveResource & save back
            //var address=_mapper.Map<SaveAddressResource,Address>(resource);
			var result = await _addressService.UpdateAsync(id, resource);

			if (result==null)
			return BadRequest(result);

			var addressResource= _mapper.Map<Address,AddressResource>(result.Address);

			return Ok(addressResource);
		}

         //DELETE address
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _addressService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);

			return Ok(result.Message);

		}

           
    }
}