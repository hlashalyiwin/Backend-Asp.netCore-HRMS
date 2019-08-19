//by Phyo Phyo San
using System;
using System.Collections.Generic;


namespace Hr_Management_final_api.Domain.Models
{  //Table name=Employee
    public class Employee
    {
    //column count=17
    
    //primary key=employeeId , foreign key=addressId
    //attributes for table
      public int? employeeId{get;set;}

      public string employee_No{get;set;}
      public string employee_Name{get;set;}
      public  string email{get;set;}
      public DateTime dob{get;set;}

      public string nrc{get;set;}

      public string phone_no_work {get;set;}
      public string phone_no_personal{get;set;}

      public string gender{get;set;}

      public string marital_status{get;set;}
      public string nationality{get;set;}
      public string religion{get;set;}

      public string permanent_address{get;set;}

      public string education_background{get;set;}
     
      public DateTime joined_date{get;set;}
      public string employee_state{get;set;}
      public int addressId{get;set;}
      public Address Addresses {get;set;}
      public IList<Leave> leaves {get;set;} =new List<Leave>();

       public IList<Attendence> Attendences{get;set;} =new List<Attendence>(); 

       public IList<Employee_training> EmployeeTrainings {get;set;}

       public IList<Award_Punishment> Award_Punishments {get;set;} =new List<Award_Punishment>();

        public IList<Absence> Absences {get;set;} =new List<Absence>();

        public IList<Performance> Performances {get;set;} =new List<Performance>();

        public IList<DutyRosterDetail> DutyRosterDetails {get;set;}=new List<DutyRosterDetail>();
        public IList<EmployeeRoles> EmployeeRoles {get;set;}=new List<EmployeeRoles>();

     

     
    

     
   
    
     
         
      
        
        
   }
}