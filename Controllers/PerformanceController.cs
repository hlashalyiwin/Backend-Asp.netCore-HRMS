using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Resources;
using Hr_Management_final_api.Domain.SaveResources;
using Hr_Management_final_api.Extensions;
using Hr_Management_final_api.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Hr_Management_final_api.Controllers
{
    //to handle requests and responses. 
    [Route("/[controller]")]
    public class PerformanceController: Controller
    { 
        private readonly IPerformanceService _performanceService;	
        //private readonly AppDbContext _bdcontext;
		private readonly IMapper _mapper;
        public PerformanceController(IPerformanceService performanceServicee,IMapper mapper)
        {
           _performanceService = performanceServicee;
			_mapper=mapper;
        }
		//  GET  performance
        [HttpGet]
        public async Task<IEnumerable<PerformanceResource>> ListAsync() //
        {
            var performance= await _performanceService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Performance>, IEnumerable<PerformanceResource>>(performance);
            return resources;	
        }
		//get performance by id
		[HttpGet("{id}")]
		public async Task<ActionResult<PerformanceResource>> Getperformance(int id)
        {
            var performanceItem = await _performanceService.GetByIdAsync(id);

            if (performanceItem == null)
            {
                return NotFound();
            }
			var resources = _mapper.Map<Performance, PerformanceResource>(performanceItem);
            return Ok(resources);	
        }
		// POST performance  
        [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Performance performance)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());  //test valid or not

		    var result = await _performanceService.SaveAsync(performance);

			if (!result.Success)
				return BadRequest(result.Message);

			return Ok();
		}
        //PUT performance
        [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Performance resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages()); //test valid or not
 
            //map data from SaveResource & save back
            //var performance=_mapper.Map<SavePerformanceResource , Performance>(resource);
			var result = await _performanceService.UpdateAsync(id, resource);

			if (result==null)
			return BadRequest(result);

			var performanceResource= _mapper.Map<Performance,PerformanceResource>(result.Performance);

			return Ok();
		}

         //DELETE performance
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _performanceService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);

			return Ok(result.Message);

		}  
    }
}