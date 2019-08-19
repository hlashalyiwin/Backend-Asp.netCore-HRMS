namespace Hr_Management_final_api.Domain.SaveResources
{
    //represents a address containing only its name.
    public class SaveAddressResource
    {
        public string line_1{get;set;}
        public string line_2{get;set;}
        public string township{get;set;}
        public string city{get;set;}
        public string region{get;set;}
        public string country{get;set;}
    }
}