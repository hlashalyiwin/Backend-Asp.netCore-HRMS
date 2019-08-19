using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Resources;
using Hr_Management_final_api.Domain.SaveResources;
using Hr_Management_final_api.Extensions;
using Hr_Management_final_api.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Hr_Management_final_api.Controllers
{	[Route("/[controller]")]
    public class LocationController: Controller
    { 
        private readonly ILocationService _locationService;
		
        //private readonly AppDbContext _bdcontext;
		private readonly IMapper _mapper;
        public LocationController(ILocationService locationService,IMapper mapper)
        {
           _locationService = locationService;
			_mapper=mapper;
        }

		//GET address
        [HttpGet]
        public async Task<IEnumerable<LocationResource>> ListAsync() //
        {
            var location= await _locationService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Location>, IEnumerable<LocationResource>>(location);
            return resources;
			
        }
		

		// get leave by id
		[HttpGet("{id}")]
		public async Task<ActionResult<LocationResource>> GetleaveItem(int id)
        {
            var locationItem = await _locationService.GetByIdAsync(id);

            if (locationItem == null)
            {
                return NotFound();
            }
			var resources = _mapper.Map<Location, LocationResource>(locationItem);
            return Ok(resources);
			
        }


		// POST leave 
        [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Location location)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());

		    var result = await _locationService.SaveAsync(location);

			if (!result.Success)
				return BadRequest(result.Message);

			return Ok();
		}

        //PUT Leave
        [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Location resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());//test valid or not
			//map data from SaveResource & save back

            //var location=_mapper.Map<SaveLocationResources,Location>(resource);
			var result = await _locationService.UpdateAsync(id, resource);

			if (result==null)
			return BadRequest(result);

			var locationResource= _mapper.Map<Location,LocationResource>(result.Location);

			return Ok(locationResource);
		}
        
		//Delete leave

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _locationService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);

			return Ok(result.Message);

		}

        
    }
    }
