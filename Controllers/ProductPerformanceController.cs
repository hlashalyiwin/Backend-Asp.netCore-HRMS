//Developed by Nang Ah: Mon(Lashio)

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Resources;
using Hr_Management_final_api.Domain.SaveResources;
using Hr_Management_final_api.Extensions;
using Hr_Management_final_api.IServices;
using Microsoft.AspNetCore.Mvc;


namespace Hr_Management_final_api.Controllers
{//ProductPerformanceController class
    [Route("/[controller]")]
    public class ProductPerformanceController : Controller
    {
         private readonly IProductService _productPerformanceService;	
        //private readonly AppDbContext _bdcontext;
		private readonly IMapper _mapper;
        public ProductPerformanceController(IProductService ProductPerformanceService,IMapper mapper)
        {
           _productPerformanceService = ProductPerformanceService;
			_mapper=mapper;
        }
		//  GET  productPerformance
        [HttpGet]
        public async Task<IEnumerable<ProductPerformanceResource>> ListAsync() //
        {
            var servicePerformance= await _productPerformanceService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Product_Performance>, IEnumerable<ProductPerformanceResource>>(servicePerformance);
            return resources;	
        }
		[HttpGet("{day}/{month}/{year}")]
        public async Task<IEnumerable<ProductPerformanceResource>> FindByDate(int day,int month,int year) //
        {
            var perfoemance = await _productPerformanceService.FindByDate(day,month,year);
            var resources = _mapper.Map<IEnumerable<Product_Performance>, IEnumerable<ProductPerformanceResource>>(perfoemance);
            return resources;
			
        }
		//get productPerformance by id
		[HttpGet("{id}")]
		public async Task<ActionResult<ProductPerformanceResource>> GetproductPerformance(int id)
        {
            var serviceItem = await _productPerformanceService.GetByIdAsync(id);

            if (serviceItem == null)
            {
                return NotFound();
            }
			var resources = _mapper.Map<Product_Performance, ProductPerformanceResource>(serviceItem);
            return Ok(resources);	
        }
		// POST productPerformance  
        [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Product_Performance productPerformance)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());  //test valid or not

		    var result = await _productPerformanceService.SaveAsync(productPerformance);

			if (!result.Success)
				return BadRequest(result.Message);

			return Ok();
		}
        //PUT productPerformance
        [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Product_Performance resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages()); //test valid or not
 
            //map data from SaveResource & save back
           // var productPerformance=_mapper.Map<SaveProductPerformanceResource , Product_Performance>(resource);
			var result = await _productPerformanceService.UpdateAsync(id, resource);

			if (result==null)
			return BadRequest(result);

			var productResource= _mapper.Map<Product_Performance,ProductPerformanceResource>(result.ProductPerformance);

			return Ok(productResource);
		}

         //DELETE productPerformance
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _productPerformanceService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);

			return Ok(result.Message);

		} 
    }
}