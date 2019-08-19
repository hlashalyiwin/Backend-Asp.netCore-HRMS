
using System;
using Hr_Management_final_api.Domain.Resource;

namespace Hr_Management_final_api.Domain.Resources
{//represents a Absence containing only its name.
    public class AbsenceResource
    {
        public int? Id{get;set;}
       
        public DateTime? date{get;set;}
        public int? rate_id{get;set;}
        public RateResource Rates{get;set;}
        public int? employee_id{get;set;}
        public EmployeeResource Employees {get;set;}
    }
}