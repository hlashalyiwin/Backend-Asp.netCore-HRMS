//by Hanni Zaw
using System;
using System.Collections.Generic;

namespace Hr_Management_final_api.Domain.Models
{
     //table="Award_Punishment"

    public class Award_Punishment
    {
        
        //column="award_punishment_Id,employee_id,award_punishment,date,description,remark"
        //attributes for table
        //primary key=award_punishment_Id
        //foreign key=employee_Id
        public int award_punishment_Id { get; set; }
        
        public string award_punishment { get; set; }
        public string date {get;set;}
        public string description { get; set; }
        public string remark { get; set; }
        
        public int employee_id { get; set; }
        public Employee Employees {get; set;}

    }
}