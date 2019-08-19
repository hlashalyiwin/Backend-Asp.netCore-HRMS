using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Domain.SaveResources 
{
    public class SaveDutyRosterResource {
       
        [Required]
        [MaxLength (250)]

        public int Shift_Id { get; set; }
        public string From_Date { get; set; }

        [Required]
        [MaxLength (250)]
        public string To_Date { get; set; }
    
    }
}