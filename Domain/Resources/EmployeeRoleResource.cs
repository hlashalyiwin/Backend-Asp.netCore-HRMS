using System;
using Hr_Management_final_api.Domain.Resources;
//represents a EmployeeRole containing only its name.
namespace Hr_Management_final_api.Domain.Resource
{
    //21.6.2019
    //Authorized by NiNiWinMay
    public class EmployeeRoleResource
    {
        public int id{get;set;}
        public DateTime start_date{get;set;}
        public string end_date{get;set;}
        public string remark{get;set;}
        public int department_id{get;set;}
        public DepartmentResource Department{get;set;}
         public int employee_id{get;set;}
         public EmployeeResource Employee{get;set;}
         public int roleid{get;set;}

        public RoleResource Role{get;set;}
        public int rankId{get;set;}
        public RankResource Ranks{get;set;}
    }
}