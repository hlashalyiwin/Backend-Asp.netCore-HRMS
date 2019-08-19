//by Htwe Khan
using System;
using System.Collections.Generic;

namespace Hr_Management_final_api.Domain.Models
{
      //table name="Role"
    public class Role
    {
       // column=Id,Name,Priority,Salary_range
       //primary key=role_id
          public int Role_Id { get; set; }
          public string Name { get; set; }

          public string Priority{ get; set; }
          public string Salary_range{ get; set; }
          public IList<EmployeeRoles> EmployeeRole { get; set; } = new List<EmployeeRoles>();
    }
}