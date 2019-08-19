using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Domain.Resources
{
    public class PerformanceResource
    {
        //represents Performance containing only its name.
        public int id { get; set; }
        public int employee_id { get; set; }
        public EmployeeResource Employee { get; set; }
        public int task_id { get; set; }
        public int reward_id { get; set; }
        public string remark { get; set; }


        public TaskedResource Task { get; set; }
        public RewardResource Reward { get; set; } 
    }
}