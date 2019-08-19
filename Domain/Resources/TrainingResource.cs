using System;
using System.Collections.Generic;
namespace Hr_Management_final_api.Domain.Resources
{
    public class TrainingResource
    {//represents a training containing only its name.
         public int Id{get;set;}
        public string training {get; set;}
        public string duration{get; set;}
        public string pre_requestive {get; set;}
        public string remark {get; set;}
        
    }
}