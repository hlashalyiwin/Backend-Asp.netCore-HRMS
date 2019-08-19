using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Resources;
using Hr_Management_final_api.Extensions;
using Hr_Management_final_api.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Hr_Management_final_api.Controllers
{
      [Route ("[controller]")]
    public class UserController: Controller {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        //ShiftsController Constructor. This constructor have two arguments shiftService and mapper
        public UserController (IUserService userService, IMapper mapper) {
            _userService = userService;
            _mapper = mapper;
        }

        //GetAllAsyc method
        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllAsync () {
            var user = await _userService.ListAsync ();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>> (user);

            return resources;

            //return shifts;
        }

       
        //PostAsync method. This method has one argument shift
        [HttpPost]
        public async Task<IActionResult> PostAsync ([FromBody] User user) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState.GetErrorMessages ());

            //var shift = _mapper.Map<SaveShiftResource, Shift> (resource);
            var result = await _userService.SaveAsync (user);

            if (!result.Success)
                return BadRequest (result.Message);

            //var shiftResource = _mapper.Map<Shift, ShiftResource> (result.Shift);
            return Ok (result);
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<UserResource>> GetByIdAsync (int id) {
            var user = await _userService.GetByIdAsync (id);
            //var resources = _mapper.Map<Email, EmailResource>(EmailItem);
            if (user == null) {
                return BadRequest ("Email Not Found!");
            }

            return Ok (user);
        }

        //PutAsync method. This method has two arguments id and resource
        [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] User user)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages()); //test valid or not
 
            //map data from SaveResource & save back
            //var shift=_mapper.Map<SaveShiftResource , Shift>(resource);
			var result = await _userService.UpdateAsync(id, user);

			if (result==null)
			return BadRequest(result);

			var userResource= _mapper.Map<User,UserResource>(result.User);

			return Ok(userResource);
		}


        //DeleteAsync method. This method has one argument id
        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteAsync (int id) {
            var result = await _userService.DeleteAsync (id);

            if (!result.Success)
                return BadRequest (result.Message);

            var userResource = _mapper.Map<User, UserResource> (result.User);
            return Ok (userResource);
        }

    }
}