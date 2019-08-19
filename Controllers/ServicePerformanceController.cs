using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Resource;
using Hr_Management_final_api.Domain.SaveResources;
using Hr_Management_final_api.Extensions;
using Hr_Management_final_api.IServices;
using Microsoft.AspNetCore.Mvc;
namespace Hr_Management_final_api.Controllers
{
	//to handle requests and responses. 
    [Route("/[controller]")]
    public class ServicePerformanceController: Controller
    { 
        private readonly IServicePerformanceService _servicePerformanceService;	
        //private readonly AppDbContext _bdcontext;
		private readonly IMapper _mapper;
        public ServicePerformanceController(IServicePerformanceService servicePerformanceService,IMapper mapper)
        {
           _servicePerformanceService = servicePerformanceService;
			_mapper=mapper;
        }
		//  GET  address
        [HttpGet]
        public async Task<IEnumerable<ServicePerformanceResource>> ListAsync() //
        {
            var servicePerformance= await _servicePerformanceService.ListAsync();
            var resources = _mapper.Map<IEnumerable<ServicePerformance>, IEnumerable<ServicePerformanceResource>>(servicePerformance);
            return resources;	
        }
		//get address by id
		[HttpGet("{id}")]
		public async Task<ActionResult<ServicePerformanceResource>> GetAddress(int id)
        {
            var serviceItem = await _servicePerformanceService.GetByIdAsync(id);

            if (serviceItem == null)
            {
                return NotFound();
            }
			var resources = _mapper.Map<ServicePerformance, ServicePerformanceResource>(serviceItem);
            return Ok(resources);	
        }
		// POST address  
        [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] ServicePerformance address)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());  //test valid or not

		    var result = await _servicePerformanceService.SaveAsync(address);

			if (!result.Success)
				return BadRequest(result.Message);

			return Ok();
		}
        //PUT address
        [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] ServicePerformance resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages()); //test valid or not
 
            //map data from SaveResource & save back
            //var address=_mapper.Map<SaveServicePerformanceResource , ServicePerformance>(resource);
			var result = await _servicePerformanceService.UpdateAsync(id, resource);

			if (result==null)
			return BadRequest(result);

			//var addressResource= _mapper.Map<ServicePerformance,ServicePerformanceResource>(result.ServicePerformance);

			return Ok();
		}

         //DELETE address
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _servicePerformanceService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);

			return Ok(result.Message);

		}  
    }
}