using System;
namespace Hr_Management_final_api.Domain.Resources
{
    //represents a cv_form containing only its name.
    public class CV_FormResource
    {
        public int? id { get ; set ; }
        
        public string date { get ; set ; }
        public string name { get ; set ; }
        public string email { get ; set ; }
        public DateTime? dob { get ; set ; }
        public string nrc { get ; set ; }
        public string ph_no_work { get ; set ; }
        public string ph_no_personal { get ; set ; }
        public string gender { get ; set ; }
        public string marital_status { get ; set ; }
        public string nationality { get ; set ; }
        public string religion { get ; set ; }
        public string permanent_address { get ; set ; }
        public string qualification { get ; set ; }

        public DateTime joined_date { get ; set ; }
        public string status { get ; set ; }
        public int address_id { get ; set ; }
        public AddressResource Addresses { get ; set ; }
        public int? announcement_id { get ; set ; }
        public AnnouncementResource Announcement { get; set; } 

    }
}