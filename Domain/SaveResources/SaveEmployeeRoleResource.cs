using System;

namespace Hr_Management_final_api.Domain.SaveResources
{
    public class SaveEmployeeRoleResource
    {
         public DateTime start_date{get;set;}
        public string end_date{get;set;}
        public string remark{get;set;}
        public int department_id{get;set;}
        public int employee_id{get;set;}
        public int rule_id{get;set;}
         public int roleid{get;set;}
        public int rankId{get;set;}
        
    }
}