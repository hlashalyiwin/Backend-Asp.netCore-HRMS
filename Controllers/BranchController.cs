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
    [Route("/[controller]")]
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;
		
        //private readonly AppDbContext _bdcontext;
		private readonly IMapper _mapper;
        public BranchController(IBranchService branchService,IMapper mapper)
        {
           	_branchService = branchService;
			_mapper=mapper;
        }

		//  GET  Branch 
        [HttpGet]
        public async Task<IEnumerable<BranchResource>> ListAsync() //
        {
            var branch= await _branchService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Branch>, IEnumerable<BranchResource>>(branch);
            return resources;
			
        }	
		// GET Branch by id  
		[HttpGet("{id}")]
		public async Task<ActionResult<BranchResource>> GetBrachItem(int id)
        {
            var branchItem = await _branchService.GetByIdAsync(id);

            if (branchItem == null)
            {
                return NotFound();
            }
			var resources = _mapper.Map<Branch, BranchResource>(branchItem);
            return Ok(resources);
        }
		// POST Branch 
        [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Branch branch)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());

		    var result = await _branchService.SaveAsync(branch);

			if (!result.Success)
				return BadRequest(result.Message);

			return Ok();
		}

		//Update Branch
        [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Branch resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());

            //var branch=_mapper.Map<SaveBranchResource,Branch>(resource);
			var result = await _branchService.UpdateAsync(id, resource);

			if (result==null)
			return BadRequest(result);

			var branchResource= _mapper.Map<Branch, BranchResource>(result.branch);

			return Ok(branchResource);
		}

		//Delete Branch Data
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _branchService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);

			return Ok(result.Message);

		}  
    }
}