

namespace Hr_Management_final_api.Domain.Resources
{
    public class BranchResource
    {//represents a Branch containing only its name.
       public int? Id { get;set; }
        public string name { get;set;}
        public string phone_1 { get;set; }
        public string phone_2 { get;set;} 

        public int? addressId{get;set;}
        public AddressResource Addresses {get;set;}

    }
}