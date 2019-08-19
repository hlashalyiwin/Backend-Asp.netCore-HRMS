using System.Collections.Generic;

namespace Hr_Management_final_api.Domain.Resources
{
    public class RewardResource
    {//represents a Rewardcontaining only its name.
        public int id { get; set; }
        public string name { get; set; }
        public int qty { get; set; }
        public string payment { get; set; }
        public string remark { get; set; }

        
    }
}