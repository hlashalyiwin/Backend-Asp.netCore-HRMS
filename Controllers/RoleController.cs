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
    [Route("/[controller]")]
    public class RoleController: Controller
    { 
        private readonly IRoleService _roleService;
		
        //private readonly AppDbContext _bdcontext;
		private readonly IMapper _mapper;
        public RoleController(IRoleService roleService,IMapper mapper)
        {
           _roleService = roleService;
			_mapper=mapper;
        }

		//GET address
        [HttpGet]
        public async Task<IEnumerable<RoleResource>> ListAsync() //
        {
            var role= await _roleService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleResource>>(role);
            return resources;
			
        }
		

		// get leave by id
		[HttpGet("{id}")]
		public async Task<ActionResult<RoleResource>> GetleaveItem(int id)
        {
            var roleItem = await _roleService.GetByIdAsync(id);

            if (roleItem == null)
            {
                return NotFound();
            }
			var resources = _mapper.Map<Role, RoleResource>(roleItem);
            return Ok(resources);
			
        }


		// POST leave 
        [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Role role)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());

		    var result = await _roleService.SaveAsync(role);

			if (!result.Success)
				return BadRequest(result.Message);

			return Ok();
		}

        //PUT Leave
        [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Role resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());//test valid or not
			//map data from SaveResource & save back

            //var role=_mapper.Map<SaveRoleResource,Role>(resource);
			var result = await _roleService.UpdateAsync(id, resource);

			if (result==null)
			return BadRequest(result);

			var roleResource= _mapper.Map<Role,RoleResource>(result.Role);

			return Ok(roleResource);
		}
        
		//Delete leave

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _roleService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);

			return Ok(result.Message);

		}

        
    }
}