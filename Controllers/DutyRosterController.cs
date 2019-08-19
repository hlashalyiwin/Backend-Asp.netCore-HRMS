using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HR_MANAGEMENT.IServicess;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Resources;
using Hr_Management_final_api.Domain.SaveResources;
using Hr_Management_final_api.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Hr_Management_final_api.Controllers
{[Route("/[controller]")]
    public class DutyRosterController: Controller
    { //use interface IDepartmentService
         private readonly IDutyRosterService _dutyRosterService;
		
        //private readonly AppDbContext _bdcontext;
		private readonly IMapper _mapper;
		//param IDepartmentService departmentService,IMapper mapper

        public DutyRosterController(IDutyRosterService dutyRosterService,IMapper mapper)
        {
           _dutyRosterService = dutyRosterService;
			_mapper=mapper;
        }

		//  GET  Department data form Resource 
        [HttpGet]
        public async Task<IEnumerable<DutyRosterResource>> ListAsync() //
        {  //get data form _departmentService
            var dutyRoster = await _dutyRosterService.ListAsync();
			//data to add Department View Table using AutoMapper
            var resources = _mapper.Map<IEnumerable<DutyRoster>, IEnumerable<DutyRosterResource>>(dutyRoster);
              //show Department View Table
			return resources;
			
        }
		// GET  Department/id  
		[HttpGet("{id}")]
		public async Task<ActionResult<DutyRosterResource>> GetEmployeeItem(int id)
        {  //get data form _departmentService by id
            var dutyRoster = await _dutyRosterService.GetByIdAsync(id);
            //check Department !null Or null
            if (dutyRoster == null)
            {
                return NotFound();
            }
            //if Department !null then data to add Department View Table using AutoMapper
			var resources = _mapper.Map<DutyRoster, DutyRosterResource>(dutyRoster);
            //show Department View Table
            return Ok(resources);
			
       
        }
		
        //Post  Department data to database 
         [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] DutyRoster dutyRoster)
		{ //get data form _departmentService by id
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());
	        //otherwise data save in database 
			var result = await _dutyRosterService.SaveAsync(dutyRoster);
			
			//if result is not success show error Message
			if (!result.Success)
				return BadRequest(result.Message);

			return Ok();
		}

         [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] DutyRoster resource)
		{ // if Model is invalid show error message by using ModelState
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());
            //get data form EmployeeAttendenceResource by id using AutoMapper
			//var dutyRoster=_mapper.Map<SaveDutyRosterResource,DutyRoster>(resource);
			//update data by id
			var result = await _dutyRosterService.UpdateAsync(id, resource);
            //if update data is null

			if (result==null)
			return BadRequest(result);
            //get result data from SaveDepartmentResource after update data using automapper
			var roleResource= _mapper.Map<DutyRoster,DutyRosterResource>(result.DutyRoster);
			 //show data
			return Ok(roleResource);
		}

        //  DELETE Department/id 
        [HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{//EmployeeAttendence data delete by id
			var result = await _dutyRosterService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);
			  //show message
			return Ok(result.Message);

		}
        
		
     }
}