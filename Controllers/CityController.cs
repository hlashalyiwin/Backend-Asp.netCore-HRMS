using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Resources;
using Hr_Management_final_api.Extensions;
using Hr_Management_final_api.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Hr_Management_final_api.Controllers
{
    //to handle requests and responses.
	[Route("[controller]")]
    public class CityController: Controller
    {
         private readonly ICityService _cityService;
		
        //private readonly AppDbContext _bdcontext;
		private readonly IMapper _mapper;
        public CityController(ICityService cityService,IMapper mapper)
        {
           _cityService = cityService;
			_mapper=mapper;
        }

		//  GET  City 
        [HttpGet]
        public async Task<IEnumerable<CityResource>> ListAsync() //
        {
            var city = await _cityService.ListAsync();
            var resources = _mapper.Map<IEnumerable<City>, IEnumerable<CityResource>>(city);
            return resources;
			
        }
          
		  //POST City
         [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] City city)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());    //test valid or not

			var result = await _cityService.SaveAsync(city);

			if (!result.Success)
				return BadRequest(result.Message);

			
			return Ok();
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<CityResource>> GetCityItem(int id)
        {//check City !null Or null
            var CityItem = await _cityService.GetByIdAsync(id);

            if (CityItem == null)
            {
                return NotFound();
            }
			//if City !null then data to add City View Table using AutoMapper
			var resources = _mapper.Map<City, CityResource>(CityItem);
            return Ok(resources);
			
        }

          //PUT City
         [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] City resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());

             //map data from SaveResource & save back
            
			var result = await _cityService.UpdateAsync(id, resource);

			if (result==null)
			return BadRequest(result);

			var cityResource= _mapper.Map<City,CityResource>(result.City);

		 
			return Ok(cityResource);
		}

         //DELETE City
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _cityService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);

			return Ok(result.Message);

		}
        
    }
}