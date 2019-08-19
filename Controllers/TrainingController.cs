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
{ [Route("/[controller]")]
    public class TrainingController : Controller
    {
		//implements the service interface
       private readonly ITrainingService _trainingService;
		
        //private readonly AppDbContext _bdcontext;
		private readonly IMapper _mapper;
        public TrainingController(ITrainingService trainingService,IMapper mapper)
        {
           _trainingService = trainingService;
			_mapper=mapper;
        }

		//GET address
        [HttpGet]
        public async Task<IEnumerable<TrainingResource>> ListAsync() //
        {
            var training= await _trainingService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Training>, IEnumerable<TrainingResource>>(training);
            return resources;
			
        }
		

		// get leave by id
		[HttpGet("{id}")]
		public async Task<ActionResult<TrainingResource>> GetleaveItem(int id)
        {
            var trainingItem = await _trainingService.GetByIdAsync(id);

            if (trainingItem == null)
            {
                return NotFound();
            }
			var resources = _mapper.Map<Training, TrainingResource>(trainingItem);
            return Ok(resources);
			
        }


		// POST leave 
        [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Training training)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());

		    var result = await _trainingService.SaveAsync(training);

			if (!result.Success)
				return BadRequest(result.Message);

			return Ok();
		}

        //PUT Leave
        [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Training resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());//test valid or not
			//map data from SaveResource & save back

            //var training=_mapper.Map<SaveTrainingResource,Training>(resource);
			var result = await _trainingService.UpdateAsync(id, resource);

			if (result==null)
			return BadRequest(result);

			var trainingResource= _mapper.Map<Training,TrainingResource>(result.Training);

			return Ok(trainingResource);
			}
        
		//Delete leave

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _trainingService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);

			return Ok(result.Message);

		}

        
    }
}