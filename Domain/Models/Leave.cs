using System;
using System.Collections.Generic;
using Hr_Management_final_api.Domain.ENumType;
namespace Hr_Management_final_api.Domain.Models
{
    //table="Leave"
    public class Leave
    {
        //column="id,employee_id,Leave_type,from_date,to_date"
        //primaryKey=id,foreign key=employee_id
        public int? id{get;set;}
       
        public ELeaveType Leave_type{get;set;}
        public DateTime from_date{ get; set; }
        public DateTime to_date { get; set; }
         public int? employee_id{get;set;}

         public Employee Employees{get;set;}

         


        
       
    }
}