using System.Collections.Generic;

namespace Hr_Management_final_api.Domain.Models
{//Table name=Department
    public class Department
    { //column count=6
    
    //primary key=dept_id , foreign key=branch_id
    //attributes for table
        public int? dept_id{get;set;}
        public string dept_name{get;set;}
        public string priority{get;set;}

        public string phone_no {get;set;}

        public string remark {get;set;}

        public int? branch_id{get;set;}

        public Branch Branches{get;set;}

        public IList<EmployeeRoles> EmployeeRoles { get; set; } = new List<EmployeeRoles>();
      
      
    }
}