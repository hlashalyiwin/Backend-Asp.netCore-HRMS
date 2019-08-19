//by Than Than Win
using System.Collections.Generic;

namespace Hr_Management_final_api.Domain.Models
{
    public class Location
    {//column=locId,lotitude,longtitude,remark
    //primaryKey=locId
        public int? locId {get;set;}
        public string lotitude {get;set;}
        public string longitude {get;set;}
        public string remark {get;set;}
        public IList<EmployeeAttendence> EmployeeAttendences {get;set;} =new List<EmployeeAttendence>(); 
    }
}