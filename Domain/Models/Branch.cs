//by Wai Mar Lwin
using System.Collections.Generic;

namespace Hr_Management_final_api.Domain.Models
{
    public class Branch
    {//table name=Branch
    //column=id,name,ph1,ph2
        //primary key=Id,ForeignKey=addressId
        public int? Id { get;set; }
        public string name { get;set;}
        public string phone_1 { get;set; }
        public string phone_2 { get;set;} 

        public int? addressId{get;set;}
        public Address Addresses {get;set;}

       public IList<Department> Departments {get;set;} =new List<Department>();
       //public IList<Employee> Employees {get;set;} =new List<Employee>();
    }
}