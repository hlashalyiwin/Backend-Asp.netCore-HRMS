//by Phyo Phyo San
namespace Hr_Management_final_api.Domain.Models
{ //Table name=EmployeeAttendence
    public class EmployeeAttendence
    { //column count=3
    
    //primary key=empAttendenceId , foreign key=attendenceId,location_Id
    //attributes for table
       public int empAttendenceId{get;set;}
       
       public int location_Id{get;set;}
       public Location locations {get;set;}
       public int attendence_Id{get;set;}

       public Attendence Attendences{get;set;}
    }
}