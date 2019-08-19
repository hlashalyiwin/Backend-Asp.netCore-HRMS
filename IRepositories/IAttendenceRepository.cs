using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using  Hr_Management_final_api.Domain.Models;
namespace  Hr_Management_final_api.IRepositories
{
    
    public interface IAttendenceRepository
    {
        Task<IEnumerable<Attendence>> ListAsync();    //return all attendence data
        Task AddAsync(Attendence attendence);           //add dattendence item
       // IList<Attendence> FindByName(int month,int year); 
        Task<IEnumerable<Attendence>> FindByNameAsync(int month,int year); 
     
        Task<IEnumerable<Attendence>> FindByEmpId(int empId) ;
        Task<IEnumerable<Attendence>> FindByDayAsync (int day,int month,int year);
        Task<Attendence> FindByIdAsync(int id);       //find by id for existing attendence item
	    void Update(Attendence attendence);             //update attendence item
        void Remove(Attendence attendence);  //remove attendence item
    }
}