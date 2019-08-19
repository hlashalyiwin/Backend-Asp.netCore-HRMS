//by Pan War War Lin
using System;
using System.Collections.Generic;
namespace Hr_Management_final_api.Domain.Models
{
    //table name= Employee_Training
    //column="id,from_date,to_date,remark,employee_id,trainig_id
    //primary Key=id,Foreign Key=employee_id,training_id
    public class Employee_training
    {
        public int id{get;set;} 
        public DateTime from_date{get;set;}
        public DateTime to_date{get;set;}
        public string remark{get;set;}
         public int employee_id{get;set;}
        public Employee Employees{get;set;}
         public int trainingId{get;set;}
        public Training Trainings{get;set;}
    
       
    }
}