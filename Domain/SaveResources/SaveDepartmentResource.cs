using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Domain.SaveResources
{
    public class SaveDepartmentResource
    {
         public string dept_name{get;set;}
        public string priority{get;set;}

        public string phone_no {get;set;}

        public string remark {get;set;}  
        public int? branch_id{get;set;}

    
       
    }
}