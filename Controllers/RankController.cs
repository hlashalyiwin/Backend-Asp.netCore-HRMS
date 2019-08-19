using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Resources;
using Hr_Management_final_api.Extensions;
using Hr_Management_final_api.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Hr_Management_final_api.Controllers
{[Route("[controller]")]
    public class RankController: Controller
    {     //use interface IEmployeeService
         private readonly IRankService _rankService;
		
		private readonly IMapper _mapper;
		//param IEmployeeService employeeService,IMapper mapper
        public RankController(IRankService rankService,IMapper mapper)
        {
           _rankService = rankService;
			_mapper=mapper;
        }

		//  GET Employee 
        [HttpGet]
        public async Task<IEnumerable<RankResource>> ListAsync() //
        {//get data form _employeeService
            var rank = await _rankService.ListAsync();
            //data to add Employee View Table using AutoMapper
            var resources = _mapper.Map<IEnumerable<Rank>, IEnumerable<RankResource>>(rank);
             //show EmployeeAttendence View Table 
			return resources;
			
        }
		

	   // GET  Employee/id  
		[HttpGet("{id}")]
		public async Task<ActionResult<RankResource>> GetRateItem(int id)
        {//check employee !null Or null
            var rateItem = await _rankService.GetByIdAsync(id);

            if (rateItem == null)
            {
                return NotFound();
            }
			//if employee !null then data to add Employee View Table using AutoMapper
			var resources = _mapper.Map<Rank, RankResource>(rateItem);
            return Ok(resources);
			
        }

        // POST Employee  
        [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Rank rank)
		{// if Model is invalid show error message by using ModelState
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());
            //otherwise data save in database 
	
			var result = await _rankService.SaveAsync(rank);
            //if result is not success show error Message
			if (!result.Success)
				return BadRequest(result.Message);

		
			return Ok();
		}

		//  PUT employee/id  
         [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Rank resource)
		{// if Model is invalid show error message by using ModelState
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());
            //get data form EmployeeAttendenceResource by id using AutoMapper
			//var rate=_mapper.Map<SaveRateResource,Rate>(resource);
			//update data by id
			var result = await _rankService.UpdateAsync(id, resource);
            //if updated data is null
			if (result==null)
			return BadRequest(result);
            //get result data from SaveEmployeeResource after update data using automapper
			var rateResource= _mapper.Map<Rank,RankResource>(result.Rank);
            //show data
			return Ok(rateResource);
		}

      //  DELETE EmployeeAttendence/id 

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{ //EmployeeAttendence data delete by id
			var result = await _rankService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);
            //show message
			return Ok(result.Message);

		}
        
    }
}