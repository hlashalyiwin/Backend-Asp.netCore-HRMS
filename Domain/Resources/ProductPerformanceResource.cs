

namespace Hr_Management_final_api.Domain.Resources
{//represents a ProductPerformancecontaining only its name.
    public class ProductPerformanceResource
    {    public int id{get;set;}
        public int unit_id{get; set;}
        public PointResource Point { get; set; }
        public string finished_goods{get; set;}
        
        public int attendence_id{get; set;}
        public AttendenceResource Attendence {get; set; }
        public int duty_roster_id{get; set;}
        public DutyRosterResource DutyRoster {get; set; }
    }
}