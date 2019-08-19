using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HR_MANAGEMENT.IServices;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Resource;
using Hr_Management_final_api.Domain.SaveResources;
using Hr_Management_final_api.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Hr_Management_final_api.Controllers
{[Route("[controller]")]
    public class RateController: Controller
    {     //use interface IEmployeeService
         private readonly IRateService _rateService;
		
		private readonly IMapper _mapper;
		//param IEmployeeService employeeService,IMapper mapper
        public RateController(IRateService rateService,IMapper mapper)
        {
           _rateService = rateService;
			_mapper=mapper;
        }

		//  GET Employee 
        [HttpGet]
        public async Task<IEnumerable<RateResource>> ListAsync() //
        {//get data form _employeeService
            var rate = await _rateService.ListAsync();
            //data to add Employee View Table using AutoMapper
            var resources = _mapper.Map<IEnumerable<Rate>, IEnumerable<RateResource>>(rate);
             //show EmployeeAttendence View Table 
			return resources;
			
        }
		

	   // GET  Employee/id  
		[HttpGet("{id}")]
		public async Task<ActionResult<RateResource>> GetRateItem(int id)
        {//check employee !null Or null
            var rateItem = await _rateService.GetByIdAsync(id);

            if (rateItem == null)
            {
                return NotFound();
            }
			//if employee !null then data to add Employee View Table using AutoMapper
			var resources = _mapper.Map<Rate, RateResource>(rateItem);
            return Ok(resources);
			
        }

        // POST Employee  
        [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Rate rate)
		{// if Model is invalid show error message by using ModelState
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());
            //otherwise data save in database 
	
			var result = await _rateService.SaveAsync(rate);
            //if result is not success show error Message
			if (!result.Success)
				return BadRequest(result.Message);

		
			return Ok();
		}

		//  PUT employee/id  
         [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Rate resource)
		{// if Model is invalid show error message by using ModelState
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());
            //get data form EmployeeAttendenceResource by id using AutoMapper
			//var rate=_mapper.Map<SaveRateResource,Rate>(resource);
			//update data by id
			var result = await _rateService.UpdateAsync(id, resource);
            //if updated data is null
			if (result==null)
			return BadRequest(result);
            //get result data from SaveEmployeeResource after update data using automapper
			var rateResource= _mapper.Map<Rate,RateResource>(result.Rate);
            //show data
			return Ok(rateResource);
		}

      //  DELETE EmployeeAttendence/id 

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{ //EmployeeAttendence data delete by id
			var result = await _rateService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);
            //show message
			return Ok(result.Message);

		}
        
    }
 }
