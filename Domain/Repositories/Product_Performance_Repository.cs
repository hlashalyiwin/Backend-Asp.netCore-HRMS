//Developed by Nang Ah: Mon(Lashio)

using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace HR1.Domain.Repositories
{
  //  Product_Performance_Repository class
 //to manage data from databases.
    public class Product_Performance_Repository : BaseRepository, IProduct_Performance_Repository
    {
        public Product_Performance_Repository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product_Performance>> ListAsync()//List all the data
        {
           
            return await _context.Product_Performances.Include(p => p.Attendence).ThenInclude
                                                        (p =>p.Employees).ThenInclude(p => p.Addresses)
                                                        .Include(p=>p.DutyRoster).ThenInclude(p=>p.Shift)
                                                        .Include(p=>p.Point)
                                                        .ToListAsync();
             
                                          
        }
        public async Task<Product_Performance> GetByIdAsync(int id)//Get by id
        {
            return await _context.Product_Performances.FindAsync(id);
        }


        public async Task AddAsync(Product_Performance Product_Performance)// add data
	    {
		    await _context.Product_Performances.AddAsync(Product_Performance);
        }


        public async Task<Product_Performance> FindByIdAsync(int id)//find by id
        {
            var Product_Performance= await _context.Product_Performances.FindAsync(id);
            var  attendence=await _context.Attendences.FindAsync(Product_Performance.attendence_id);
            var employee=await _context.Employees.FindAsync(attendence.empId);
            var address=await _context.Addresses.FindAsync(employee.addressId);
            var dutyroster=await _context.DutyRoster.FindAsync(Product_Performance.duty_roster_id);
            var shift=await _context.Shifts.FindAsync(dutyroster.Shift_Id);
            dutyroster.Shift=shift;
            employee.Addresses=address;
            attendence.Employees=employee;
            Product_Performance.Attendence=attendence;
            Product_Performance.DutyRoster=dutyroster;
	        return Product_Performance;
        }

        public void Update(Product_Performance Product_Performance)//update data
        {
            
	        _context.Product_Performances.Update(Product_Performance);
        }

        public void Remove(Product_Performance Product_Performance)//remove data
        {
	        _context.Product_Performances.Remove(Product_Performance);

        }

        public async Task<IEnumerable<Product_Performance>> FindByDate(int day,int month,int year){
            var performace=await _context.Product_Performances.Where(p=>p.Attendence.date.Day==day)
            .Where(p=>p.Attendence.date.Month==month)
            .Where(p=>p.Attendence.date.Year==year)
            .Include(p=>p.Attendence).ThenInclude(a=>a.Employees)
            .Include(p=>p.DutyRoster).ThenInclude(d=>d.Shift)
            .ToListAsync();
            return performace;
        }
    }
}