//Created by Soe Min Thu
//Created date is 21.6.2019

using System;

namespace Hr_Management_final_api.Domain.Resource
 {//represents a Shift containing only its name.
    //ShiftResource class
    public class ShiftResource {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Start_Time { get; set; }
        public string End_Time { get; set; }
    }
}