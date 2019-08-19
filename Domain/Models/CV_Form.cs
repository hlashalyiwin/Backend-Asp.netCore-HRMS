//by Hla shalyi Win
using System;
using System.Threading.Tasks;

namespace Hr_Management_final_api.Domain.Models
{
    //table name=Department
    public class CV_Form
    {
      //colum count=18, name = (id , announcement_id , date , name , email , dob , nrc , ph_no_work , ph_no_personal, gender, marital_status, nationality , religion , permanent_address , qualification , address_id, joined_date, status)
      
      //primary key=id,
        public int? id { get ; set ; }
        
        public DateTime date { get ; set ; }
        public string name { get ; set ; }
        public string email { get ; set ; }
        public string dob { get ; set ; }
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
        public Address Addresses {get;set;}
        public int? announcement_id { get ; set ; }
        public Announcement Announcement { get; set; }
        
    }
}