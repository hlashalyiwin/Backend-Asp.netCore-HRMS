//by Zayar Phyo
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr_Management_final_api.Domain.Models
{
    public class Reward
    {//column=id,name,qty,payment,remark
    //primary key=id
        public int id { get; set; }
        public string name { get; set; }
        public int qty { get; set; }
        public string payment { get; set; }
        public string remark { get; set; }

        public IList<Performance> performance { get; set; } =new List<Performance>();
    }
}
