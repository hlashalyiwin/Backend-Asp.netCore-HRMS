using System.Security.AccessControl;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using System.Linq;

namespace Hr_Management_final_api.Domain.Repositories
{ //to manage data from databases.
    public class Employee_trainingRepository: BaseRepository, IEmployee_trainingRepository
    {
        public Employee_trainingRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Employee_training>> ListAsync()
        {
            await _context.Employee_trainings.Include(p=>p.Trainings).ToListAsync();  
            return await _context.Employee_trainings.Include(p=>p.Employees).ThenInclude(p=>p.Addresses).ToListAsync();
             
                                          
        }
        public async Task<Employee_training> GetByIdAsync(int id){
            return await _context.Employee_trainings.FindAsync(id);
        }


        public async Task AddAsync(Employee_training Employee_training)
	    {
		    await _context.Employee_trainings.AddAsync(Employee_training);
        }


        public async Task<Employee_training> FindByIdAsync(int id)
        {
             var employee_training= await _context.Employee_trainings.FindAsync(id);
            var training=await _context.Trainings.FindAsync(employee_training.trainingId);
            var employee=await _context.Employees.FindAsync(employee_training.employee_id);
            //var branch=await _context.Branchs.FindAsync(department.branch_id);
            var address=await _context.Addresses.FindAsync(employee.addressId);
            employee_training.Employees=employee;
            employee_training.Trainings=training;
            employee.Addresses=address;
            
	        return employee_training;
        }

        public void Update(Employee_training employee_training)
        {
            
	        _context.Employee_trainings.Update(employee_training);
        }

        public void Remove(Employee_training employee_training)
        {
	        _context.Employee_trainings.Remove(employee_training);

        }

        public async Task<IEnumerable<Employee_training>> FindByMonth(int sdate, int smonth, int syear, int edate, int emonth, int eyear)
        {
           var empTraining= await _context.Employee_trainings
                                .Where(e=>e.from_date.Day==sdate)
                                .Where(e=>e.from_date.Month==smonth)
                                .Where(e=>e.from_date.Year==syear)
                                .Where(e=>e.to_date.Day==edate)
                                .Where(e=>e.to_date.Month==emonth)
                                .Where(e=>e.to_date.Year==eyear)
                                .Include(e=>e.Trainings)
                                .Include(e=>e.Employees)

          .ToListAsync();
          return empTraining;
        }

        public async Task<IEnumerable<Employee_training>> FindByTrainingId(int trainingId)
        {
           var trainName=await _context.Employee_trainings.Where(e=>e.Trainings.Id==trainingId)
           .Include(e=>e.Employees).ToListAsync();
           return trainName;
        }

        public async Task<IEnumerable<Employee_training>> FindByEmpId(int empId,int sdate, int smonth, int syear, int edate, int emonth, int eyear,string trainingName)
        {
            var employeeId=await _context.Employee_trainings
                               .Where(e=>e.from_date.Day==sdate)
                                .Where(e=>e.from_date.Month==smonth)
                                .Where(e=>e.from_date.Year==syear)
                                .Where(e=>e.to_date.Day==edate)
                                .Where(e=>e.to_date.Month==emonth)
                                .Where(e=>e.to_date.Year==eyear)
                                .Where(e=>e.Trainings.training==trainingName)
                                .Where(e=>e.employee_id==empId)
                                 .Include(e=>e.Employees)
                                 .ToListAsync();
                return employeeId;
        }
    }
}