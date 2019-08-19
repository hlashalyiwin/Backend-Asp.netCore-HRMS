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
{[Route("/[controller]")]
    public class EmployeeAttendenceController: Controller
    { //use interface IDepartmentService
         private readonly IEmployeeAttendenceService _employeeAttendenceService;
		
        //private readonly AppDbContext _bdcontext;
		private readonly IMapper _mapper;
		//param IDepartmentService departmentService,IMapper mapper

        public EmployeeAttendenceController(IEmployeeAttendenceService employeeAttendenceService,IMapper mapper)
        {
           _employeeAttendenceService = employeeAttendenceService;
			_mapper=mapper;
        }

		//  GET  Department data form Resource 
        [HttpGet]
        public async Task<IEnumerable<EmployeeAttendenceResource>> ListAsync() //
        {  //get data form _departmentService
            var employeeattendence = await _employeeAttendenceService.ListAsync();
			//data to add Department View Table using AutoMapper
            var resources = _mapper.Map<IEnumerable<EmployeeAttendence>, IEnumerable<EmployeeAttendenceResource>>(employeeattendence);
              //show Department View Table
			return resources;
			
        }
		// GET  Department/id  
		[HttpGet("{id}")]
		public async Task<ActionResult<EmployeeAttendenceResource>> GetEmployeeItem(int id)
        {  //get data form _departmentService by id
            var employeeattendence = await _employeeAttendenceService.GetByIdAsync(id);
            //check Department !null Or null
            if (employeeattendence == null)
            {
                return NotFound();
            }
            //if Department !null then data to add Department View Table using AutoMapper
			var resources = _mapper.Map<EmployeeAttendence, EmployeeAttendenceResource>(employeeattendence);
            //show Department View Table
            return Ok(resources);
			
       
        }
		
        //Post  Department data to database 
         [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] EmployeeAttendence employeeAttendence)
		{ //get data form _departmentService by id
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());
	        //otherwise data save in database 
			var result = await _employeeAttendenceService.SaveAsync(employeeAttendence);
			
			//if result is not success show error Message
			if (!result.Success)
				return BadRequest(result.Message);

			return Ok();
		}

         [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] EmployeeAttendence resource)
		{ // if Model is invalid show error message by using ModelState
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());
            //get data form EmployeeAttendenceResource by id using AutoMapper
			//var employeeattendence=_mapper.Map<SaveEmployeeAttendenceResource,EmployeeAttendence>(resource);
			//update data by id
			var result = await _employeeAttendenceService.UpdateAsync(id, resource);
            //if update data is null

			if (result==null)
			return BadRequest(result);
            //get result data from SaveDepartmentResource after update data using automapper
			var roleResource= _mapper.Map<EmployeeAttendence,EmployeeAttendenceResource>(result.EmployeeAttendence);
			 //show data
			return Ok(roleResource);
		}

        //  DELETE Department/id 
        [HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{//EmployeeAttendence data delete by id
			var result = await _employeeAttendenceService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);
			  //show message
			return Ok(result.Message);

		}
        
		
    
    }
}