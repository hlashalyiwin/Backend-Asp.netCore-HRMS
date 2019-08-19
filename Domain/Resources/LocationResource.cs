namespace Hr_Management_final_api.Domain.Resources
{
    public class LocationResource
    {
       //represents a location containing only its name.
        public int? locId {get;set;}
        public string lotitude {get;set;}
        public string longitude {get;set;}
        public string remark {get;set;} 
    }
}