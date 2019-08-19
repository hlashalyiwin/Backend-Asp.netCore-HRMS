//Created by Soe Min Thu
//Created date is 21.6.2019

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Resource;
using Hr_Management_final_api.Domain.SaveResources;
using Hr_Management_final_api.Extensions;
using Hr_Management_final_api.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Hr_Management_final_api.Controllers
 {
    [Route ("[controller]")]
    //ShiftsController class. This class extends Controller
    public class ShiftsController : Controller {
        private readonly IShiftService _shiftService;
        private readonly IMapper _mapper;

        //ShiftsController Constructor. This constructor have two arguments shiftService and mapper
        public ShiftsController (IShiftService shiftService, IMapper mapper) {
            _shiftService = shiftService;
            _mapper = mapper;
        }

        //GetAllAsyc method
        [HttpGet]
        public async Task<IEnumerable<ShiftResource>> GetAllAsync () {
            var shifts = await _shiftService.ListAsync ();
            var resources = _mapper.Map<IEnumerable<Shift>, IEnumerable<ShiftResource>> (shifts);

            return resources;

            //return shifts;
        }

       
        //PostAsync method. This method has one argument shift
        [HttpPost]
        public async Task<IActionResult> PostAsync ([FromBody] Shift shift) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState.GetErrorMessages ());

            //var shift = _mapper.Map<SaveShiftResource, Shift> (resource);
            var result = await _shiftService.SaveAsync (shift);

            if (!result.Success)
                return BadRequest (result.Message);

            //var shiftResource = _mapper.Map<Shift, ShiftResource> (result.Shift);
            return Ok (result);
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<ShiftResource>> GetByIdAsync (int id) {
            var shift = await _shiftService.GetByIdAsync (id);
            //var resources = _mapper.Map<Email, EmailResource>(EmailItem);
            if (shift == null) {
                return BadRequest ("Email Not Found!");
            }

            return Ok (shift);
        }

        //PutAsync method. This method has two arguments id and resource
        [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Shift resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages()); //test valid or not
 
            //map data from SaveResource & save back
            //var shift=_mapper.Map<SaveShiftResource , Shift>(resource);
			var result = await _shiftService.UpdateAsync(id, resource);

			if (result==null)
			return BadRequest(result);

			var shiftResource= _mapper.Map<Shift,ShiftResource>(result.Shift);

			return Ok(shiftResource);
		}


        //DeleteAsync method. This method has one argument id
        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteAsync (int id) {
            var result = await _shiftService.DeleteAsync (id);

            if (!result.Success)
                return BadRequest (result.Message);

            var shiftResource = _mapper.Map<Shift, ShiftResource> (result.Shift);
            return Ok (shiftResource);
        }

    }
}