using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Hr_Management_final_api.IServices;
using Hr_Management_final_api.Domain.Resource;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Extensions;
using Microsoft.AspNetCore.Cors;


//21.6.2019
//authorized by Ni Ni Win May
namespace Hr_Management_final_api.Controllers
{
    [Route("/[controller]")]
	[EnableCors("Global.CORS_ALLOW_ALL_POLICY_NAME")] 
    public class EmployeeRoleController : Controller
    {
        private readonly IEmployeeRoleService _employeeRoleService;
		private readonly IMapper _mapper;

		//Constructor
        public EmployeeRoleController(IEmployeeRoleService employeeRoleService,IMapper mapper)
        {
            _employeeRoleService = employeeRoleService;
			_mapper=mapper;
        }

		/// <summary>
		/// Getting data from employee role table
		/// </summary>
		/// <returns>employeeRole</returns>
        [HttpGet]
         public async Task<IEnumerable<EmployeeRoleResource>> ListAsync() //
        {
            var employeeRole = await _employeeRoleService.ListAsync();
            var resources = _mapper.Map<IEnumerable<EmployeeRoles>, IEnumerable<EmployeeRoleResource>>(employeeRole);
            return resources;
			
        }
		
		/// <summary>
		/// Getting data from employee role table with the specified ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Action result</returns>
		[HttpGet("{id}")]
		public async Task<ActionResult<EmployeeRoleResource>> GetEmployeeRoleItem(int id)
        {
            var employeeRoleItem = await _employeeRoleService.GetByIdAsync(id);
			var resources = _mapper.Map<EmployeeRoles, EmployeeRoleResource>(employeeRoleItem);
            if (resources == null)
            {
                return BadRequest("EmployeeRole Not Found!");
            }
			
            return Ok(resources);
        }


		/// <summary>
		/// Save data to employee role table
		/// </summary>
		/// <param name="resource"></param>
		/// <returns>Action result</returns>
        [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] EmployeeRoles resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());

			var result = await _employeeRoleService.SaveAsync(resource);

			if (!result.Success)
				return BadRequest(result.Message);

			return Ok();
		}
		/// <summary>
		/// Update data in employee role table with the specified ID
		/// </summary>
		/// <param name="id"></param>
		/// <param name="resource"></param>
		/// <returns>Action result</returns>
        [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] EmployeeRoles resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());

			var result = await _employeeRoleService.UpdateAsync(id, resource);

			if (result==null)
			return BadRequest(result);
			var employeeResource= _mapper.Map<EmployeeRoles,EmployeeRoleResource>(result.EmployeeRole);

			return Ok();
		}
			[HttpGet("api/emp/{id}")]
		public  async Task<IEnumerable<EmployeeRoleResource>> FindByEmp(int id)
        {//check employee !null Or null
            var employeeRoleItem= await _employeeRoleService.FindByEmpId(id);
           
         
			//if employee !null then data to add Employee View Table using AutoMapper
			var resources = _mapper.Map<IEnumerable<EmployeeRoles>,IEnumerable <EmployeeRoleResource>>(employeeRoleItem);
            return resources;
			
        }
		[HttpGet("api/{id}")]
		public  async Task<IEnumerable<EmployeeRoleResource>> FindByName(int  id)
        {//check employee !null Or null
            var employeeRoleItem= await _employeeRoleService.FindByDeptIdAsync(id);
           
         
			//if employee !null then data to add Employee View Table using AutoMapper
			var resources = _mapper.Map<IEnumerable<EmployeeRoles>,IEnumerable <EmployeeRoleResource>>(employeeRoleItem);
            return resources;
			
        }

		/// <summary>
		/// Remove data from employee role table with user specified id
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Action result</returns>
        [HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _employeeRoleService.DeleteAsync(id);

			if (result==null)
			return BadRequest(result.Message);

			return Ok();

		}
    }
}
