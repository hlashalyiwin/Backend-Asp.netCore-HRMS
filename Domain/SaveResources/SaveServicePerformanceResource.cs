using System.ComponentModel.DataAnnotations;
namespace Hr_Management_final_api.Domain.SaveResources
{
    //represents a address containing only its name.
    public class SaveServicePerformanceResource
    {
        [Required]
        //[MaxLength(30)]
        public int? servicePerformanceId {get;set;}
        public string work_done{get;set;}
        public string remark{get;set;}
        public int attendence_id{get;set;}  
    }
}