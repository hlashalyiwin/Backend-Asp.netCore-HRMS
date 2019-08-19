using System;
namespace Hr_Management_final_api.Domain.Resources

{
     //represents award_punishment containing only its name

    public class Award_PunishmentResource
    {
        public int award_punishment_Id { get; set; }
        
        public string award_punishment { get; set; }
        public string date {get;set;}
        public string description { get; set; }
        public string remark { get; set; }
        public int employee_id { get; set; }
        public EmployeeResource Employees {get;set;}

    }
}