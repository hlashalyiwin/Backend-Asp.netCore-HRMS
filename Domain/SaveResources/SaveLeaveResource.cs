using System;
using Hr_Management_final_api.Domain.ENumType;
namespace Hr_Management_final_api.Domain.SaveResources
{
    //represents a Leave containing only its name
    public class SaveLeaveResource
    {
       
        public int? employee_id{get;set;}

        //ELeaveType is enum class type
        public ELeaveType Leave_type{get;set;}
        public DateTime from_date{ get; set; }
        public DateTime to_date { get; set; }
        
    }
}