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
    public class DutyRosterDetailController: Controller
    { //use interface IDepartmentService
         private readonly IDutyRosterDetailService _dutyRosterDetailService;
		
        //private readonly AppDbContext _bdcontext;
		private readonly IMapper _mapper;
		//param IDepartmentService departmentService,IMapper mapper

        public DutyRosterDetailController(IDutyRosterDetailService dutyRosterDetailService,IMapper mapper)
        {
           _dutyRosterDetailService = dutyRosterDetailService;
			_mapper=mapper;
        }

		//  GET  Department data form Resource 
        [HttpGet]
        public async Task<IEnumerable<DutyRosterDetailResource>> ListAsync() //
        {  //get data form _departmentService
            var dutyRoster = await _dutyRosterDetailService.ListAsync();
			//data to add Department View Table using AutoMapper
            var resources = _mapper.Map<IEnumerable<DutyRosterDetail>, IEnumerable<DutyRosterDetailResource>>(dutyRoster);
              //show Department View Table
			return resources;
			
        }
		// GET  Department/id  
		[HttpGet("{id}")]
		public async Task<ActionResult<DutyRosterDetailResource>> GetEmployeeItem(int id)
        {  //get data form _departmentService by id
            var dutyRoster = await _dutyRosterDetailService.GetByIdAsync(id);
            //check Department !null Or null
            if (dutyRoster == null)
            {
                return NotFound();
            }
            //if Department !null then data to add Department View Table using AutoMapper
			var resources = _mapper.Map<DutyRosterDetail, DutyRosterDetailResource>(dutyRoster);
            //show Department View Table
            return Ok(resources);
			
       
        }

		[HttpGet("api/{empid}")]
		public  async Task<IEnumerable<DutyRosterDetailResource>> FindByShift(int empid)
        {
            var shift= await _dutyRosterDetailService.findByEmpId(empid);
             
         
			//if employee !null then data to add Employee View Table using AutoMapper
			var resources = _mapper.Map<IEnumerable<DutyRosterDetail>,IEnumerable <DutyRosterDetailResource>>(shift);
            return resources;
			
        }
	
		
        //Post  Department data to database 
         [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] DutyRosterDetail dutyRoster)
		{ //get data form _departmentService by id
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());
	        //otherwise data save in database 
			var result = await _dutyRosterDetailService.SaveAsync(dutyRoster);
			
			//if result is not success show error Message
			if (!result.Success)
				return BadRequest(result.Message);

			return Ok();
		}

         [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] DutyRosterDetail resource)
		{ // if Model is invalid show error message by using ModelState
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());
            //get data form EmployeeAttendenceResource by id using AutoMapper
			//var dutyRoster=_mapper.Map<SaveDutyRosterDetailResource,DutyRosterDetail>(resource);
			//update data by id
			var result = await _dutyRosterDetailService.UpdateAsync(id, resource);
            //if update data is null

			if (result==null)
			return BadRequest(result);
            //get result data from SaveDepartmentResource after update data using automapper
			var roleResource= _mapper.Map<DutyRosterDetail,DutyRosterDetailResource>(result.DutyRosterDetail);
			 //show data
			return Ok(roleResource);
		}

        //  DELETE Department/id 
        [HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{//EmployeeAttendence data delete by id
			var result = await _dutyRosterDetailService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);
			  //show message
			return Ok(result.Message);

		}
        
		
     }
    }