using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Resources;
using Hr_Management_final_api.Domain.SaveResources;
using Hr_Management_final_api.Extensions;
using Hr_Management_final_api.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Hr_Management_final_api.Controllers
{
  [Route("[controller]")]
    public class RewardController: Controller
    {     //use interface IEmployeeService
         private readonly IRewardService _rewardService;
		
		private readonly IMapper _mapper;
		//param IEmployeeService employeeService,IMapper mapper
        public RewardController(IRewardService rewardService,IMapper mapper)
        {
           _rewardService = rewardService;
			_mapper=mapper;
        }

		//  GET Employee 
        [HttpGet]
        public async Task<IEnumerable<RewardResource>> ListAsync() //
        {//get data form _employeeService
            var reward = await _rewardService.ListAsync();
            //data to add Employee View Table using AutoMapper
            var resources = _mapper.Map<IEnumerable<Reward>, IEnumerable<RewardResource>>(reward);
             //show EmployeeAttendence View Table 
			return resources;
			
        }
		

	   // GET  Employee/id  
		[HttpGet("{id}")]
		public async Task<ActionResult<RewardResource>> GetRateItem(int id)
        {//check employee !null Or null
            var rewardItem = await _rewardService.GetByIdAsync(id);

            if (rewardItem == null)
            {
                return NotFound();
            }
			//if employee !null then data to add Employee View Table using AutoMapper
			var resources = _mapper.Map<Reward, RewardResource>(rewardItem);
            return Ok(resources);
			
        }

        // POST Employee  
        [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Reward reward)
		{// if Model is invalid show error message by using ModelState
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());
            //otherwise data save in database 
	
			var result = await _rewardService.SaveAsync(reward);
            //if result is not success show error Message
			if (!result.Success)
				return BadRequest(result.Message);

		
			return Ok();
		}

		//  PUT employee/id  
         [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Reward resource)
		{// if Model is invalid show error message by using ModelState
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());
            //get data form EmployeeAttendenceResource by id using AutoMapper
			//var reward=_mapper.Map<SaveRewardResource,Reward>(resource);
			//update data by id
			var result = await _rewardService.UpdateAsync(id, resource);
            //if updated data is null
			if (result==null)
			return BadRequest(result);
            //get result data from SaveEmployeeResource after update data using automapper
			var rewardResource= _mapper.Map<Reward,RewardResource>(result.Reward);
            //show data
			return Ok(rewardResource);
		}

      //  DELETE EmployeeAttendence/id 

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{ //EmployeeAttendence data delete by id
			var result = await _rewardService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);
            //show message
			return Ok(result.Message);

		}
        
    }
}
