using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace Hr_Management_final_api.Domain.Repositories
{

    //to manage data from databases.
    public class ServicePerformanceRepository : BaseRepository, IServicePerformanceRepository
    {
        //parm use AppDBContext 
        public ServicePerformanceRepository(AppDbContext context) : base(context)
        {
        }
        //to add address
        public async Task AddAsync(ServicePerformance servicePerformance)
        {
            await _context.ServicePerformances.AddAsync(servicePerformance);
        }
        //to get address by id
        public async Task<ServicePerformance> FindByIdAsync(int id)
        {
           var servicePerformance= await _context.ServicePerformances.FindAsync(id);
           var attendence=await _context.Attendences.FindAsync(servicePerformance.attendence_id);
           var employee=await _context.Employees.FindAsync(attendence.empId);
           var address=await _context.Addresses.FindAsync(employee.addressId);

           servicePerformance.Attendence=attendence;
           attendence.Employees=employee;
           employee.Addresses=address;
           
           return servicePerformance;
        }
        //to take list address
        public async Task<IEnumerable<ServicePerformance>> ListAsync()
        {
            return await _context.ServicePerformances.Include(p => p.Attendence).ThenInclude(p=>p.Employees).ThenInclude(p=>p.Addresses)  
                                          .ToListAsync();          

        }
        //to remove address
        public void Remove(ServicePerformance servicePerformance)
        {
          _context.ServicePerformances.Remove(servicePerformance); 

        }
        public void Update(ServicePerformance address)
        {
             _context.ServicePerformances.Update(address); 
        }
   }
}