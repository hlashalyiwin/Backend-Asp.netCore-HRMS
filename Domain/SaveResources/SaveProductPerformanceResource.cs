using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Domain.SaveResources
{
    public class SaveProductPerformanceResource
    {
        public string id{get; set;}
        // public int unit_id{get; set;}
        // public string finished_goods{get; set;}
        
        // public int duty_roster_id{get; set;}
        // public int attendence_id{get; set;}
        public int attendence_id{get; set;}
        public Attendence Attendence {get; set; }
        public int unit_id{get; set;}
        public string finished_goods{get; set;}

        public int duty_roster_id{get; set;}
        public DutyRoster DutyRoster {get; set;}
        
    }
}