//by May Hnin Thu
using System;
using System.Collections.Generic;
using Hr_Management_final_api.Domain.ENumType;
namespace Hr_Management_final_api.Domain.Models
{
    //table="Attendence"
    public class Attendence
    {
        //column="attId,employee_id,date,start_time,end_time,attendenceType,remark"
        //primaryKey="attId",foreignKey=employee_id
       public int attId{get;set;}

        public DateTime date{get;set;}
        public string start_time{get;set;}
        public string end_time{get;set;}
        public EAttendenceType attendenceType { get; set; }
        public string remark{get;set;} 
         public int? empId{get;set;}
         public Employee Employees {get;set;} 
        public IList<EmployeeAttendence> EmployeeAttendences {get;set;} =new List<EmployeeAttendence>(); 
        public IList<ServicePerformance> ServicePerformances { get; set; } = new List<ServicePerformance>();
    
    public IList<Product_Performance> Product_Performances { get; set; } = new List<Product_Performance>();
    }
}