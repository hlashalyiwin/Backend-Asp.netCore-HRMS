using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Resources;
using Hr_Management_final_api.Domain.SaveResources;
using Hr_Management_final_api.Extensions;
using Hr_Management_final_api.IServices;
using Hr_Management_final_api.IServicess;
using Microsoft.AspNetCore.Mvc;

namespace Hr_Management_final_api.Controllers
{   [Route("/[controller]")]
    public class RuleController: Controller
    { 
        private readonly IRuleService _ruleService;
		
        //private readonly AppDbContext _bdcontext;
		private readonly IMapper _mapper;
        public RuleController(IRuleService ruleService,IMapper mapper)
        {
           _ruleService = ruleService;
			_mapper=mapper;
        }

		//GET address
        [HttpGet]
        public async Task<IEnumerable<RuleResource>> ListAsync() //
        {
            var rule= await _ruleService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Rule>, IEnumerable<RuleResource>>(rule);
            return resources;
			
        }
		

		// get leave by id
		[HttpGet("{id}")]
		public async Task<ActionResult<RuleResource>> GetleaveItem(int id)
        {
            var ruleItem = await _ruleService.GetByIdAsync(id);

            if (ruleItem == null)
            {
                return NotFound();
            }
			var resources = _mapper.Map<Rule, RuleResource>(ruleItem);
            return Ok(resources);
			
        }


		// POST leave 
        [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Rule rule)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());

		    var result = await _ruleService.SaveAsync(rule);

			if (!result.Success)
				return BadRequest(result.Message);

			return Ok();
		}

        //PUT Leave
        [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Rule resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());//test valid or not
			//map data from SaveResource & save back

            //var rule=_mapper.Map<SaveRuleResource,Rule>(resource);
			var result = await _ruleService.UpdateAsync(id, resource);

			if (result==null)
			return BadRequest(result);

			var ruleResource= _mapper.Map<Rule,RuleResource>(result.Rule);

			return Ok(ruleResource);
		}
        
		//Delete leave

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _ruleService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);

			return Ok(result.Message);

		}

        
    }
}