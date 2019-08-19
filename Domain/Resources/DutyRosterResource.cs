using System;
using System.Collections.Generic;
using Hr_Management_final_api.Domain.Resource;

//represents a DutyRoster containing only its name.
namespace Hr_Management_final_api.Domain.Resources {
    public class DutyRosterResource {
        public int Id { get; set; }
        
        
        public DateTime From_Date { get; set; }
        public DateTime To_Date { get; set; }
        public int Shift_Id { get; set; }
        public ShiftResource Shift { get; set; }

    }
}