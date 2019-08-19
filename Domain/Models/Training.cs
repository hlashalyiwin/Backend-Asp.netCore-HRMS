using System;
using System.Collections.Generic;

namespace Hr_Management_final_api.Domain.Models
{
    public class Training
    {
        //create table
        public int Id{get;set;}
        public string training{get; set;}
        public string duration{get; set;}
    
        public string pre_requestive{get; set;}
        public string remark{get; set;}
        
       public IList<Employee_training> Employee_trainings {get;set;}=new List<Employee_training>();
       
    
    }
}