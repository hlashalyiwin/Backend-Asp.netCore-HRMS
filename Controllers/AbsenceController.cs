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
{[Route("/[controller]")]
    public class AbsenceController: Controller
    { 
        private readonly IAbsenceService _absenceService;
		
        //private readonly AppDbContext _bdcontext;
		private readonly IMapper _mapper;
        public AbsenceController(IAbsenceService AbsenceService,IMapper mapper)
        {
           _absenceService = AbsenceService;
			_mapper=mapper;
        }

		//  GET  shipping 
        [HttpGet]
        public async Task<IEnumerable<AbsenceResource>> ListAsync() //
        {
            var absence= await _absenceService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Absence>, IEnumerable<AbsenceResource>>(absence);
            return resources;
			
        }
		

		// // GET   shipping/id  
		[HttpGet("{id}")]
		public async Task<ActionResult<AbsenceResource>> GetShippingItem(int id)
        {
            var absenceItem = await _absenceService.GetByIdAsync(id);

            if (absenceItem == null)
            {
                return NotFound();
            }
			var resources = _mapper.Map<Absence, AbsenceResource>(absenceItem);
            return Ok(resources);
			
        }
		[HttpGet("api/{name}")]
		public  async Task<IEnumerable<AbsenceResource>> FindByName(string name)
        {//check employee !null Or null
            var absenceItem= await _absenceService.FindByNameAsync(name);
           
         
			//if employee !null then data to add Employee View Table using AutoMapper
			var resources = _mapper.Map<IEnumerable<Absence>,IEnumerable <AbsenceResource>>(absenceItem);
            return resources;
			
        }


		// POST shipping  
        [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Absence absence)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());

		    var result = await _absenceService.SaveAsync(absence);

			if (!result.Success)
				return BadRequest(result.Message);

			return Ok();
		}

        [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Absence resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());

            //var employee=_mapper.Map<SaveAbsenceResource,Absence>(resource);
			var result = await _absenceService.UpdateAsync(id, resource);

			if (result==null)
			return BadRequest(result);

			var roleResource= _mapper.Map<Absence,AbsenceResource>(result.Absence);

			return Ok(roleResource);
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _absenceService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);

			return Ok(result.Message);

		}

        
    }
}