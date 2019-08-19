using Hr_Management_final_api.Domain.Models;
//represents a EmployeeAttendencecontaining only its name.
namespace Hr_Management_final_api.Domain.Resources
{
    public class EmployeeAttendenceResource
    {
       
       public int empAttendenceId{get;set;}
        public int location_Id{get;set;}
        public LocationResource Locations {get;set;}
       
        public int attendence_Id{get;set;}

       public AttendenceResource Attendences {get;set;}
       
    }
}