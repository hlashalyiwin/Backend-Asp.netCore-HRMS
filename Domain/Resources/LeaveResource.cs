using Hr_Management_final_api.Domain.ENumType;
using System;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Domain.Resources
{//represents a leave containing only its name.
    //represents a leave containing only its name
    public class LeaveResource
    {
        public int? id { get;set; }

        //ELeaveType is enum class type
        public string Leave_type{get;set;}
        public DateTime from_date{ get; set; }
        public DateTime to_date { get; set; }
         public int? employee_id{get;set;}

         public EmployeeResource Employees{get;set;}
    }
}