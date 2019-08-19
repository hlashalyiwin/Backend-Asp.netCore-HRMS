using System;
using System.Collections.Generic;

namespace Hr_Management_final_api.Domain.Models 
{
    public class DutyRoster {
        //column=Id,Shift_id,From_Date,To_Date
        //primary key=id,foreign Key=Shift_id
        public int Id { get; set; }
        public int Shift_Id { get; set; }
        public Shift Shift { get; set; }
        public DateTime From_Date { get; set; }
        public DateTime To_Date { get; set; }

        public IList<DutyRosterDetail> DutyRosterDetails {get;set;}=new List<DutyRosterDetail>();
        public IList<Product_Performance> Product_Performances{get;set;}=new List<Product_Performance>();

    
    }
}