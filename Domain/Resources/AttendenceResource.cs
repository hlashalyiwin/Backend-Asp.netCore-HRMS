using System;
using System.Collections.Generic;
using Hr_Management_final_api.Domain.ENumType;
namespace Hr_Management_final_api.Domain.Resources
{
    //represents a attendence containing only its name.
    public class AttendenceResource
    {
        public int attId{get;set;}
        public string date{get;set;}
        public string start_time{get;set;}
        public string end_time{get;set;}

        //EAttendenceType is enum class type
        public string attendenceType { get;set; }
        public string remark{get;set;}  
        public int empId{get;set;}
         public EmployeeResource Employees {get;set;} 
    }
}