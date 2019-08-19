using Hr_Management_final_api.Domain.Resources;

namespace Hr_Management_final_api.Domain.Resource
{//represents a ServicePerformance containing only its name.
    //represents a address containing only its name
    public class ServicePerformanceResource
    {
        public int? servicePerformanceId {get;set;}
        public string work_done{get;set;}
        public string remark{get;set;}
        public int attendence_id{get;set;} 
        public AttendenceResource Attendence {get; set; }
 
    }
}