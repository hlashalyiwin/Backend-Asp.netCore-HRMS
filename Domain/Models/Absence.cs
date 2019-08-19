//Aye Myat Myat Aung
//absence table
using System;
using System.Collections.Generic;

namespace Hr_Management_final_api.Domain.Models
{   //table name=Absence
    public class Absence
    {
    //primary key=Id
       public int Id{get;set;}
        public DateTime date{get;set;}
        public int rate_id{get;set;}
        public Rate Rates {get;set;}
        public int employee_id{get;set;}
        
        public Employee Employees {get;set;}

       
    }
}