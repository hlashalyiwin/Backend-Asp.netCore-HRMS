//Created by Soe Min Thu
//Created date is 21.6.2019

using System.ComponentModel.DataAnnotations;

namespace Hr_Management_final_api.Domain.SaveResources
 {
    //SaveShiftResource class
    public class SaveShiftResource {
        [Required]
        [MaxLength (250)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Start_Time { get; set; }
        public string End_Time { get; set; }
     
    }
}