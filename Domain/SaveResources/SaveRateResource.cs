using Hr_Management_final_api.Domain.ENumType;
namespace Hr_Management_final_api.Domain.SaveResources

{
    public class SaveRateResource
    {
        public string name{get;set;}
        public string rate{get;set;}

        //ERatetype is enum class type
        public ERateType type{get;set;}
        public string description{get;set;}
    }
}