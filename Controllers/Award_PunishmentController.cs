using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HR_MANAGEMENT.IServices;
using Hr_Management_final_api.Domain.IServices;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Resources;
using Hr_Management_final_api.Domain.SaveResources;
using Hr_Management_final_api.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Hr_Management_final_api.Controllers
{
	//to handle requests and responses.
	[Route("[controller]")]
    public class Award_PunishmentController: Controller
    { 
        private readonly IAward_PunishmentService _award_punishmentService;
		
        
		private readonly IMapper _mapper;
        public Award_PunishmentController(IAward_PunishmentService award_punishmentService,IMapper mapper)
        {
           _award_punishmentService = award_punishmentService;
			_mapper=mapper;
        }

		//GET address
        [HttpGet]
        public async Task<IEnumerable<Award_PunishmentResource>> ListAsync() 
        {
            var award_punishments= await _award_punishmentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Award_Punishment>, IEnumerable<Award_PunishmentResource>>(award_punishments);
            return resources;
			
        }
		

		// get leave by id
		[HttpGet("{id}")]
		public async Task<ActionResult<Award_PunishmentResource>> Getaward_punishmentItem(int id)
        {
            var award_punishmentItem = await _award_punishmentService.GetByIdAsync(id);

            if (award_punishmentItem == null)
            {
                return NotFound();
            }
			var resources = _mapper.Map<Award_Punishment, Award_PunishmentResource>(award_punishmentItem);
            return Ok(resources);
			
        }
        [HttpPost]//Post Method
		public async Task<IActionResult> PostAsync([FromBody] Award_Punishment resource)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState.GetErrorMessages()); //test valid or not

			//var award_punishment = _mapper.Map<SaveAward_PunishmentResource, Award_Punishment>(resource);
			var result = await _award_punishmentService.SaveAsync(resource);

			if (!result.Success)
				return BadRequest(result.Message);

			//var award_punishmentResource = _mapper.Map<Award_Punishment, Award_PunishmentResource>(result.Award_Punishment);
			return Ok();
		}
		[HttpPut("{id}")]//Put Method
		public async Task<IActionResult> PutAsync(int id, [FromBody] Award_Punishment resource)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState.GetErrorMessages());

			//var award_punishment = _mapper.Map<SaveAward_PunishmentResource, Award_Punishment>(resource);
			var result = await _award_punishmentService.UpdateAsync(id, resource);

			if (!result.Success)
				return BadRequest(result.Message);

			//var award_punishmentResource = _mapper.Map<Award_Punishment, Award_PunishmentResource>(result.Award_Punishment);
			return Ok();
		}
		
		[HttpDelete("{id}")]//Delete Method
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _award_punishmentService.DeleteAsync(id);

			if (!result.Success)
				return BadRequest(result.Message);

			var award_punishmentResource = _mapper.Map<Award_Punishment, Award_PunishmentResource>(result.Award_Punishment);
			return Ok(award_punishmentResource);
		}


        
    }
}


		