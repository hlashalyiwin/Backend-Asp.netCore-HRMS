using System;
using System.Collections.Generic;
using System.Linq;
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
	//to handle requests and responses.
    [Route("/[controller]")]
    public class AttendenceController: Controller
    {
         private readonly IAttendenceService _attendenceService;
		
        //private readonly AppDbContext _bdcontext;
		private readonly IMapper _mapper;
        public AttendenceController(IAttendenceService attendenceService,IMapper mapper)
        {
           _attendenceService = attendenceService;
			_mapper=mapper;
        }

		//  GET  attendence 
        [HttpGet]
        public async Task<IEnumerable<AttendenceResource>> ListAsync() //
        {
            var attendence = await _attendenceService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Attendence>, IEnumerable<AttendenceResource>>(attendence);
            return resources;
			
        }

          
		  //POST attendence
         [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Attendence attendence)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());    //test valid or not

			var result = await _attendenceService.SaveAsync(attendence);

			if (!result.Success)
				return BadRequest(result.Message);

			
			return Ok();
		}
		[HttpGet("{month}/{year}")]
		public  async Task<IEnumerable<AttendenceResource>> FindByName(int month ,int year)
        {//check employee !null Or null
            var AttendenceItem= await _attendenceService.FindByName(month,year);
             
         
			//if employee !null then data to add Employee View Table using AutoMapper
			var resources = _mapper.Map<IEnumerable<Attendence>,IEnumerable <AttendenceResource>>(AttendenceItem);
            return resources;
			
        }
		 [HttpGet("{day}/{month}/{year}")]
        public async Task<IEnumerable<AttendenceResource>> FindByDay(int day,int month,int year) //
        {
            var AttendenceItem = await _attendenceService.FindByDay(day,month,year);
            var resources = _mapper.Map<IEnumerable<Attendence>, IEnumerable<AttendenceResource>>(AttendenceItem);
            return resources;
			
        }
        [HttpGet("api/{empId}")]
        public async Task<IEnumerable<AttendenceResource>> FindByEmployeeId(int empId) //
        {
            var AttendenceItem = await _attendenceService.FindByEmpId(empId);
            var resources = _mapper.Map<IEnumerable<Attendence>, IEnumerable<AttendenceResource>>(AttendenceItem);
            return resources;
			
        }


		[HttpGet("{id}")]
		public async Task<ActionResult<AttendenceResource>> GetAttendenceItem(int id)
        {//check employee !null Or null
            var AttendenceItem = await _attendenceService.GetByIdAsync(id);

            if (AttendenceItem == null)
            {
                return NotFound();
            }
			//if employee !null then data to add Employee View Table using AutoMapper
			var resources = _mapper.Map<Attendence, AttendenceResource>(AttendenceItem);
            return Ok(resources);
			
        }

          //PUT attendence
         [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Attendence resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());

             //map data from SaveResource & save back
            //var attendence=_mapper.Map<SaveAttendenceResource,Attendence>(resource);
			var result = await _attendenceService.UpdateAsync(id, resource);

			if (result==null)
			return BadRequest(result);

			var attendenceResource= _mapper.Map<Attendence,AttendenceResource>(result.attendence);

		 
			return Ok(attendenceResource);
		}

         //DELETE attendence
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _attendenceService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);

			return Ok(result.Message);

		}
        
    }
}