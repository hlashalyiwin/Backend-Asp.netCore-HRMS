//by Htwe Khan
using System;

namespace Hr_Management_final_api.Domain.Models
{
    public class Rule
    {
        //column=Rule_Id,Rule_No,Description
        //primary key=Rule_Id
        public int Rule_Id { get; set; }
        public int Rule_no{ get; set; }
        public string Description{ get; set; }
    }
}