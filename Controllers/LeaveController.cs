using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hr_Management_final_api.Domain.IServices;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Resources;
using Hr_Management_final_api.Domain.SaveResources;
using Hr_Management_final_api.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Hr_Management_final_api.Controllers
{
	//to handle requests and responses.
	[Route("/[controller]")]
    public class LeaveController: Controller
    { 
        private readonly ILeaveService _leaveService;
		
        //private readonly AppDbContext _bdcontext;
		private readonly IMapper _mapper;
        public LeaveController(ILeaveService LeaveService,IMapper mapper)
        {
           _leaveService = LeaveService;
			_mapper=mapper;
        }

		//GET address
        [HttpGet]
        public async Task<IEnumerable<LeaveResource>> ListAsync() //
        {
            var leave= await _leaveService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Leave>, IEnumerable<LeaveResource>>(leave);
            return resources;
			
        }
		

		// get leave by id
		[HttpGet("{id}")]
		public async Task<ActionResult<LeaveResource>> GetleaveItem(int id)
        {
            var leaveItem = await _leaveService.GetByIdAsync(id);

            if (leaveItem == null)
            {
                return NotFound();
            }
			var resources = _mapper.Map<Leave, LeaveResource>(leaveItem);
            return Ok(resources);
			//return await _context.Leave.FindAsync(id);
			
        }


		// POST leave 
        [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Leave leave)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());

		    var result = await _leaveService.SaveAsync(leave);

			if (!result.Success)
				return BadRequest(result.Message);

			return Ok();
		}

        //PUT Leave
        [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Leave resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());//test valid or not
			//map data from SaveResource & save back

            //var employee=_mapper.Map<SaveLeaveResource,Leave>(resource);
			var result = await _leaveService.UpdateAsync(id, resource);

			if (result==null)
			return BadRequest(result);

			//var roleResource= _mapper.Map<Leave,LeaveResource>(result.Leave);

			return Ok();
		}
        
		//Delete leave

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _leaveService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);

			return Ok(result.Message);

		}

        
    }
}