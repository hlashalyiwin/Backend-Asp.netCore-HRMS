using System.Collections.Generic;

namespace Hr_Management_final_api.Domain.Models
{
    public class Rank
    {
        
          public int Rank_Id { get; set; }
          public string Name { get; set; }
          public IList<EmployeeRoles> EmployeeRole { get; set; } = new List<EmployeeRoles>();
    }
}