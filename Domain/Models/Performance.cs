//by Zayar Phyo
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr_Management_final_api.Domain.Models
{
    public class Performance
    {//column=id,employee_id,task_id,reward_id,remark
    //primary key=id,foreign key=employee_id,task_id,reward_id
        public int id { get; set; }
        public int employee_id { get; set; }
        public Employee Employee {get;set;}
        public int task_id { get; set; }
        public int reward_id { get; set; }
        public string remark { get; set; }

        public Tasked Task { get; set; }
        public Reward Reward { get; set; } 
    }
}
