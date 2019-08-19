//Created by Soe Min Thu
//Created date is 21.6.2019
using System;
using System.Collections.Generic;


namespace Hr_Management_final_api.Domain.Models
 {
    //Shift class
    public class Shift {
        //column=Id,Name,Start_Time,End_Time
        //Primary Key=id
        public int Id { get; set; }
        public string Name { get; set; }
        public string Start_Time { get; set; }
        public string End_Time { get; set; }
        public IList<DutyRoster> DutyRosters {get;set;}=new List<DutyRoster>();
    
        
    }
}