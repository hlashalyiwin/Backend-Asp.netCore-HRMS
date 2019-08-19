using System;


namespace Hr_Management_final_api.Domain.SaveResources

{
      //represents award_punishment containing only its name
    public class SaveAward_PunishmentResource
    {
         
        public int employee_id { get; set; }
        public string award_punishment { get; set; }
        public string date {get;set;}
        public string description { get; set; }
        public string remark { get; set; }

    }
}