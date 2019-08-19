using Hr_Management_final_api.Domain.ENumType;
namespace Hr_Management_final_api.Domain.Resource
{
    public class RateResource
    {//represents a Ratecontaining only its name.
        public int rateId{get;set;}
        public string Name{get;set;}
        public string rate{get;set;}

        //ERateType is enum class type
        public string type{get;set;}
        public string description{get;set;}
    }
}