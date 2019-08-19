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
    //to handle requests and responses. 
    [Route("[controller]")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
		
        //private readonly AppDbContext _bdcontext;
		private readonly IMapper _mapper;
        public AnnouncementController(IAnnouncementService AnnouncementService,IMapper mapper)
        {
           _announcementService = AnnouncementService;
			_mapper=mapper;
        }

		//  GET  announcement
        [HttpGet]
        public async Task<IEnumerable<AnnouncementResource>> ListAsync() 
        {
            var address= await _announcementService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Announcement>, IEnumerable<AnnouncementResource>>(address);
            return resources;
			
        }
		//get announcement by id
		[HttpGet("{id}")]
		public async Task<ActionResult<AnnouncementResource>> GetAddress(int id)
        {
            var addressItem = await _announcementService.GetByIdAsync(id);

            if (addressItem == null)
            {
                return NotFound();
            }
			var resources = _mapper.Map<Announcement, AnnouncementResource>(addressItem);
            return Ok(resources);	
        }
		// POST announcement  
        [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Announcement address)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());  //test valid or not

		    var result = await _announcementService.SaveAsync(address);

			if (!result.Success)
				return BadRequest(result.Message);

			return Ok();
		}
        //PUT announcement
        [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Announcement resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages()); //test valid or not
 
            //map data from SaveResource & save back
            //var address=_mapper.Map<SaveAnnouncementResource,Announcement>(resource);
			var result = await _announcementService.UpdateAsync(id, resource);

			if (result==null)
			return BadRequest(result);

			var addressResource= _mapper.Map<Announcement,AnnouncementResource>(result.Announcement);

			return Ok(addressResource);
		}

         //DELETE announcement
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _announcementService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);

			return Ok(result.Message);

		}
    }
}