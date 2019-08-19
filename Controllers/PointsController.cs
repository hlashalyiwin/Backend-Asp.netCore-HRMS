
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Resources;
using Hr_Management_final_api.Domain.SaveResources;
using Hr_Management_final_api.Extensions;
using Hr_Management_final_api.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Hr_Management_final_api.Controllers {
    [Route ("[controller]")]
    public class PointsController : Controller {
        private readonly IPointService _pointService;
        private readonly IMapper _mapper;

        public PointsController (IPointService pointService, IMapper mapper) {
            _pointService = pointService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Point>> GetAllAsync () {
            var points = await _pointService.ListAsync ();
            //var resources = _mapper.Map<IEnumerable<Point>, IEnumerable<PointResource>> (points);

            return points;
        }

        [HttpGet ("{id}")]
        public async Task<Point> GetByIdAsync (int id) {
            var points = await _pointService.GetByIdAsync (id);
            //var resources = _mapper.Map<IEnumerable<Point>, IEnumerable<PointResource>> (points);

            return points;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync ([FromBody] Point point) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState.GetErrorMessages ());

            //var point = _mapper.Map<SavePointResource, Point> (resource);
            var result = await _pointService.SaveAsync (point);

            if (!result.Success)
                return BadRequest (result.Message);

            //var pointResource = _mapper.Map<Point, PointResource> (result.Point);
            return Ok (result);
        }

       [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Point resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages()); //test valid or not
 
            //map data from SaveResource & save back
            //var point=_mapper.Map<SavePointResource , Point>(resource);
			var result = await _pointService.UpdateAsync(id, resource);

			if (result==null)
			return BadRequest(result);

			var productResource= _mapper.Map<Point,PointResource>(result.Point);

			return Ok(productResource);
		}

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteAsync (int id) {
            var result = await _pointService.DeleteAsync (id);

            if (!result.Success)
                return BadRequest (result.Message);

            var pointResource = _mapper.Map<Point, PointResource> (result.Point);
            return Ok (pointResource);
        }

    }
}