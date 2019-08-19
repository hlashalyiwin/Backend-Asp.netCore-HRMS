namespace Hr_Management_final_api.Domain.Resources
{
    public class DutyRosterDetailResource
    {
        //represents a DutyRosterDetail containing only its name.
        public int? dutyRosterDetail_id{get;set;}
       
        public int? dutyRoster_id{get;set;}

        public DutyRosterResource DutyRosters {get;set;}
        public int? employee_id{get;set;}
        public EmployeeResource Employees {get;set;}
    }
}