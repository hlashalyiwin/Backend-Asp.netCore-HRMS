using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Hr_Management_final_api.Domain.IServices;
using Hr_Management_final_api.Domain.Resources;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Extensions;
using Hr_Management_final_api.Domain.SaveResources;
using Microsoft.AspNetCore.Cors;

namespace Hr_Management_final_api.Controllers
{    [Route("/[controller]")]
    [EnableCors("Global.CORS_ALLOW_ALL_POLICY_NAME")] 
    public class EmployeeController: Controller
    {     //use interface IEmployeeService
         private readonly IEmployeeService _employeeService;
		
		private readonly IMapper _mapper;
		//param IEmployeeService employeeService,IMapper mapper
        public EmployeeController(IEmployeeService employeeService,IMapper mapper)
        {
           _employeeService = employeeService;
			_mapper=mapper;
        }

		//  GET Employee 
        [HttpGet]
        public async Task<IEnumerable<EmployeeResource>> ListAsync() //
        {//get data form _employeeService
            var employee = await _employeeService.ListAsync();
            //data to add Employee View Table using AutoMapper
            var resources = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(employee);
             //show EmployeeAttendence View Table 
			return resources;
			
        }
		

	   // GET  Employee/id  
		[HttpGet("{id}")]
		public async Task<ActionResult<EmployeeResource>> GetEmployeeItem(int id)
        {//check employee !null Or null
            var employeeItem = await _employeeService.GetByIdAsync(id);

            if (employeeItem == null)
            {
                return NotFound();
            }
			//if employee !null then data to add Employee View Table using AutoMapper
			var resources = _mapper.Map<Employee, EmployeeResource>(employeeItem);
            return Ok(resources);
			
        }

        // POST Employee  
        [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Employee employee)
		{// if Model is invalid show error message by using ModelState
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());
            //otherwise data save in database 
	
			var result = await _employeeService.SaveAsync(employee);
            //if result is not success show error Message
			if (!result.Success)
				return BadRequest(result.Message);

		
			return Ok();
		}

		//  PUT employee/id  
         [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Employee resource)
		{// if Model is invalid show error message by using ModelState
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());
            //get data form EmployeeAttendenceResource by id using AutoMapper
			//var employee=_mapper.Map<SaveEmployeeResource,Employee>(resource);
			//update data by id
			var result = await _employeeService.UpdateAsync(id, resource);
            //if updated data is null
			if (result==null)
			return BadRequest(result);
            //get result data from SaveEmployeeResource after update data using automapper
			var employeeResource= _mapper.Map<Employee,EmployeeResource>(result.Employee);
            //show data
			return Ok(employeeResource);
		}

      //  DELETE EmployeeAttendence/id 

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{ //EmployeeAttendence data delete by id
			var result = await _employeeService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);
            //show message
			return Ok(result.Message);

		}
        
    }
}