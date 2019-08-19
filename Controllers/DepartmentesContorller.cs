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
{  [Route("/[controller]")]
    
    public class DepartmentesController: Controller
    { //use interface IDepartmentService
         private readonly IDepartmentService _departmentService;
		
        //private readonly AppDbContext _bdcontext;
		private readonly IMapper _mapper;
		//param IDepartmentService departmentService,IMapper mapper

        public DepartmentesController(IDepartmentService departmentService,IMapper mapper)
        {
           _departmentService = departmentService;
			_mapper=mapper;
        }

		//  GET  Department data form Resource 
        [HttpGet]
        public async Task<IEnumerable<DepartmentResource>> ListAsync() //
        {  //get data form _departmentService
            var department = await _departmentService.ListAsync();
			//data to add Department View Table using AutoMapper
            var resources = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentResource>>(department);
              //show Department View Table
			return resources;
			
        }
		// GET  Department/id  
		[HttpGet("{id}")]
		public async Task<ActionResult<DepartmentResource>> GetEmployeeItem(int id)
        {  //get data form _departmentService by id
            var department = await _departmentService.GetByIdAsync(id);
            //check Department !null Or null
            if (department == null)
            {
                return NotFound();
            }
            //if Department !null then data to add Department View Table using AutoMapper
			var resources = _mapper.Map<Department, DepartmentResource>(department);
            //show Department View Table
            return Ok(resources);
			
       
        }
			[HttpGet("api/{id}")]
		public  async Task<IEnumerable<DepartmentResource>> FindByBranch(int id)
        {//check employee !null Or null
            var dept= await _departmentService.FindByBranchsId(id);
           
         
			//if employee !null then data to add Employee View Table using AutoMapper
			var resources = _mapper.Map<IEnumerable<Department>,IEnumerable <DepartmentResource>>(dept);
            return resources;
			
        }
	
		
        //Post  Department data to database 
         [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Department department)
		{ //get data form _departmentService by id
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());
	        //otherwise data save in database 
			var result = await _departmentService.SaveAsync(department);
			
			//if result is not success show error Message
			if (!result.Success)
				return BadRequest(result.Message);

			return Ok();
		}

         [HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Department resource)
		{ // if Model is invalid show error message by using ModelState
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());
            //get data form EmployeeAttendenceResource by id using AutoMapper
			//var department=_mapper.Map<SaveDepartmentResource,Department>(resource);
			//update data by id
			var result = await _departmentService.UpdateAsync(id, resource);
            //if update data is null

			if (result==null)
			return BadRequest(result);
            //get result data from SaveDepartmentResource after update data using automapper
			var roleResource= _mapper.Map<Department,DepartmentResource>(result.Department);
			 //show data
			return Ok(roleResource);
		}

        //  DELETE Department/id 
        [HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{//EmployeeAttendence data delete by id
			var result = await _departmentService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);
			  //show message
			return Ok(result.Message);

		}
        
		
     }
}