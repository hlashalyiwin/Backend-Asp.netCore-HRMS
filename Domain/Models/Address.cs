//by May Hnin Thu
using System;
using System.Collections.Generic;

namespace Hr_Management_final_api.Domain.Models
{
    //table="Address"
    public class Address
    {
        //columnn="addId,line_1,line_2,township,city,region,country"
        //primaryKey=addId
        public int addId{get;set;}
        public string line_1{get;set;}
        public string line_2{get;set;}
        public int township_Id{get;set;}
        public Township Township{get;set;}
     
        public string region{get;set;}
        public string country{get;set;}
        public IList<Employee> Employees{get;set;} =new List<Employee>();
        public IList<Branch> Branches{get;set;} =new List<Branch>();
         public IList<CV_Form> CV_Forms { get; set; } = new List<CV_Form>();



    }
}