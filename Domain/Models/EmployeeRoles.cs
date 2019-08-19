
using System;

namespace Hr_Management_final_api.Domain.Models
{
    //21.6.2019
    //authorized by Ni Ni Win May
    public class EmployeeRoles
    {
        //column=id,start_date,end_date,remark,roleId,departmentId
        //primary Key=id,ForeignKey=roleId,departmentId
        public int id{get;set;}
        public DateTime start_date{get;set;}
        public string end_date{get;set;}
        public string remark{get;set;}
        public int roleid{get;set;}
        public Role Role{get;set;}
        public int rankId{get;set;}
        public Rank Ranks{get;set;}
        public int employee_id{get;set;}
        public Employee Employee{get;set;}
        public int department_id{get;set;}
        public Department Department{get;set;}
        
    }
}