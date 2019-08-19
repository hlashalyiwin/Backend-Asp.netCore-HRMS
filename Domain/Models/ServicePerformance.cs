//by Nam Seng Leng Aung
namespace Hr_Management_final_api.Domain.Models
{
    //table="ServicePerformance"
    public class ServicePerformance
    {   //**service_performance(id , work_done , attendence_id , remark)
        //columnn="addId,line_1,line_2,township,city,region,country"
        //primaryKey= id
        public int servicePerformanceId {get;set;}
        public string work_done{get;set;}
        public string remark{get;set;}
        public int attendence_id{get;set;}
        public Attendence Attendence {get; set; }
        
    }
}