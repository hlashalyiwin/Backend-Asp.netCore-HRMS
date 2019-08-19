//Created by Sai Nay Lynn
//Created date is 21.6.2019

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Resources;
using Hr_Management_final_api.Domain.SaveResources;
using Hr_Management_final_api.Extensions;
using Hr_Management_final_api.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Hr_Management_final_api.Controllers {
    [Route("[controller]")]
    public class TaskedController: Controller
    {     //use interface IEmployeeService
         private readonly ITaskedService _taskedService;
		
		private readonly IMapper _mapper;
		//param IEmployeeService employeeService,IMapper mapper
        public TaskedController(ITaskedService taskedService,IMapper mapper)
        {
           _taskedService = taskedService;
			_mapper=mapper;
        }

		//  GET Employee 
        [HttpGet]
        public async Task<IEnumerable<TaskedResource>> ListAsync() //
        {//get data form _employeeService
            var tasked = await _taskedService.ListAsync();
            //data to add Employee View Table using AutoMapper
            var resources = _mapper.Map<IEnumerable<Tasked>, IEnumerable<TaskedResource>>(tasked);
             //show EmployeeAttendence View Table 
			return resources;
			
        }
		

	   // GET  Employee/id  
		[HttpGet("{id}")]
		public async Task<ActionResult<TaskedResource>> GetRateItem(int id)
        {//check employee !null Or null
            var taskedItem = await _taskedService.GetByIdAsync(id);

            if (taskedItem == null)
            {
                return NotFound();
            }
			//if employee !null then data to add Employee View Table using AutoMapper
			var resources = _mapper.Map<Tasked, TaskedResource>(taskedItem);
            return Ok(resources);
			
        }

        // POST Employee  
        [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Tasked tasked)
		{// if Model is invalid show error message by using ModelState
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());
            //otherwise data save in database 
	
			var result = await _taskedService.SaveAsync(tasked);
            //if result is not success show error Message
			if (!result.Success)
				return BadRequest(result.Message);

		
			return Ok();
		}

		//  PUT employee/id  
         [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Tasked resource)
		{// if Model is invalid show error message by using ModelState
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());
            //get data form EmployeeAttendenceResource by id using AutoMapper
			//var tasked=_mapper.Map<SaveTaskedResource,Tasked>(resource);
			//update data by id
			var result = await _taskedService.UpdateAsync(id, resource);
            //if updated data is null
			if (result==null)
			return BadRequest(result);
            //get result data from SaveEmployeeResource after update data using automapper
			var taskedResource= _mapper.Map<Tasked,TaskedResource>(result.Tasked);
            //show data
			return Ok(taskedResource);
		}

      //  DELETE EmployeeAttendence/id 

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{ //EmployeeAttendence data delete by id
			var result = await _taskedService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);
            //show message
			return Ok(result.Message);

		}
        
    }
}