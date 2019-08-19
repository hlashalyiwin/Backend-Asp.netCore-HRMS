using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HR_MANAGEMENT.IServices;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Resources;
using Hr_Management_final_api.Domain.SaveResources;
using Hr_Management_final_api.Extensions;
using Microsoft.AspNetCore.Mvc;
namespace HR1.Controllers
{
	//to handle requests and responses.
    [Route("/[controller]")]
    public class CV_FormController: Controller
    {
        private readonly ICV_FormService _cvService;
		
        //private readonly AppDbContext _bdcontext;
		private readonly IMapper _mapper;
        public CV_FormController(ICV_FormService attendenceService,IMapper mapper)
        {
           _cvService = attendenceService;
			_mapper=mapper;
        }

		//  GET  cv_form 
        [HttpGet]
        public async Task<IEnumerable<CV_FormResource>> ListAsync() //
        {
            var attendence = await _cvService.ListAsync();
            var resources = _mapper.Map<IEnumerable<CV_Form>, IEnumerable<CV_FormResource>>(attendence);
            return resources;
			
        }
          
		  //POST cv_form
         [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] CV_Form attendence)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());    //test valid or not

			var result = await _cvService.SaveAsync(attendence);

			if (!result.Success)
				return BadRequest(result.Message);

			
			return Ok();
		}

          //PUT cv_form
         [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] CV_Form resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());

             //map data from SaveResource & save back
            //var attendence=_mapper.Map<SaveCV_FormResource,CV_Form>(resource);
			var result = await _cvService.UpdateAsync(id, resource);

			if (result==null)
			return BadRequest(result);

			var attendenceResource= _mapper.Map<CV_Form,CV_FormResource>(result.CV_Form);

		 
			return Ok();
		}

         //DELETE attendence
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _cvService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);

			return Ok(result.Message);

		}
		[HttpGet("{id}")]
		public async Task<ActionResult<CV_FormResource>> GetCV_FromItem(int id)
        {
            var cvItem = await _cvService.GetByIdAsync(id);

            if (cvItem == null)
            {
                return NotFound();
            }
			var resources = _mapper.Map<CV_Form, CV_FormResource>(cvItem);
            return Ok(resources);
        }
		[HttpGet("api/{announceid}")]
		public async Task<IEnumerable<CV_FormResource>> GetByAnnouncementId(int announceid)
        {
            var cvItem = await _cvService.FindByAnnouncementId(announceid);
          
		  	var resources = _mapper.Map<IEnumerable<CV_Form>,IEnumerable <CV_FormResource>>(cvItem);
            return resources;
           
        }
		[HttpGet("{day}/{month}/{year}")]
		public async Task<IEnumerable<CV_FormResource>> GetByAnnouncementDate(int day,int month,int year)
        {
            var cvItem = await _cvService.FindByAnnouncementDate(day,month,year);
          
		  	var resources = _mapper.Map<IEnumerable<CV_Form>,IEnumerable <CV_FormResource>>(cvItem);
            return resources;
           
        }
        
        
    }
}