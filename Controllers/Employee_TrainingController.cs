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
    public class EmployeeTrainingController: Controller
    {     //use interface IEmployeeService
         private readonly IEmployee_trainingService _employeeTrainingService;
		
		private readonly IMapper _mapper;
		//param IEmployeeService employeeService,IMapper mapper
        public EmployeeTrainingController(IEmployee_trainingService employeeTrainingService,IMapper mapper)
        {
           _employeeTrainingService = employeeTrainingService;
			_mapper=mapper;
        }

		//  GET Employee 
        [HttpGet]
        public async Task<IEnumerable<Employee_trainingResource>> ListAsync() //
        {//get data form _employeeService
            var employeeTraining = await _employeeTrainingService.ListAsync();
            //data to add Employee View Table using AutoMapper
            var resources = _mapper.Map<IEnumerable<Employee_training>, IEnumerable<Employee_trainingResource>>(employeeTraining);
             //show EmployeeAttendence View Table 
			return resources;
			
        }
		

	   // GET  Employee/id  
		[HttpGet("{id}")]
		public async Task<ActionResult<Employee_trainingResource>> GetEmployeeItem(int id)
        {//check employee !null Or null
            var employeeTrainingItem = await _employeeTrainingService.GetByIdAsync(id);

            if (employeeTrainingItem == null)
            {
                return NotFound();
            }
			//if employee !null then data to add Employee View Table using AutoMapper
			var resources = _mapper.Map<Employee_training, Employee_trainingResource>(employeeTrainingItem);
            return Ok(resources);
			
        }
		[HttpGet("{sday}/{smonth}/{syear}/{eday}/{emonth}/{eyear}")]
		public  async Task<IEnumerable<Employee_trainingResource>> FindByName(int sday ,int smonth,int syear,int eday,int emonth,int eyear)
        {//check employee !null Or null
            var traindate= await _employeeTrainingService.FindByMonth(sday,smonth,syear,eday,emonth,eyear);
             
         
			//if employee !null then data to add Employee View Table using AutoMapper
			var resources = _mapper.Map<IEnumerable<Employee_training>,IEnumerable <Employee_trainingResource>>(traindate);
            return resources;
			
        }
		[HttpGet("api/{id}")]
		public  async Task<IEnumerable<Employee_trainingResource>> FindByTrainingId(int id)
        {//check employee !null Or null
            var trainName= await _employeeTrainingService.FindByTrainingId(id);
             
         
			//if employee !null then data to add Employee View Table using AutoMapper
			var resources = _mapper.Map<IEnumerable<Employee_training>,IEnumerable <Employee_trainingResource>>(trainName);
            return resources;
			
        }
		[HttpGet("api/{empId}/{sday}/{smonth}/{syear}/{eday}/{emonth}/{eyear}/{trainname}")]
		public  async Task<IEnumerable<Employee_trainingResource>> FindBy(int empId,int sday ,int smonth,int syear,int eday,int emonth,int eyear,string trainname)
        {//check employee !null Or null
            var employeeId= await _employeeTrainingService.FindByEmpId(empId,sday,smonth,syear,eday,emonth,eyear,trainname);
             
         //if employee !null then data to add Employee View Table using AutoMapper
			var resources = _mapper.Map<IEnumerable<Employee_training>,IEnumerable <Employee_trainingResource>>(employeeId);
            return resources;
			
        }


        // POST Employee  
        [HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Employee_training employee_training)
		{// if Model is invalid show error message by using ModelState
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());
            //otherwise data save in database 
	
			var result = await _employeeTrainingService.SaveAsync(employee_training);
            //if result is not success show error Message
			if (!result.Success)
				return BadRequest(result.Message);

		
			return Ok();
		}

		//  PUT employee/id  
         [HttpPut("{id}")]
	public async Task<IActionResult> PutAsync(int id, [FromBody] Employee_training resource)
		{
			if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());

			var result = await _employeeTrainingService.UpdateAsync(id, resource);

			if (result==null)
			return BadRequest(result);

			return Ok(result);
		}

      //  DELETE EmployeeAttendence/id 

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{ //EmployeeAttendence data delete by id
			var result = await _employeeTrainingService.DeleteAsync(id);

			if (result == null)
			return BadRequest(result.Message);
            //show message
			return Ok(result.Message);

		}
        
    }
        
    }
