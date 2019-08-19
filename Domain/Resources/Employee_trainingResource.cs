
using System;
//represents a Employee_training containing only its name.
namespace Hr_Management_final_api.Domain.Resources
{
    public class Employee_trainingResource
    {
        public int? id{get;set;}
       public DateTime from_date{get;set;}
        public DateTime to_date{get;set;}
        public string remark{get;set;}
        public int? employee_id{get;set;}
        public EmployeeResource Employees{get;set;}
         public int trainingId{get;set;}
        public TrainingResource Trainings{get;set;}
    }
}