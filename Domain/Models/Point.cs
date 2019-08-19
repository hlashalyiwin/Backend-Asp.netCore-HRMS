//by Soe Min Thu
using System.Collections.Generic;

namespace Hr_Management_final_api.Domain.Models
{
    public class Point
    {//column=id,Name,Price,Remark
    //primary key=id
          public int? Id { get; set;}

          public string Name {get;set;}
          public int? Price {get;set;}
          public string Remark {get;set;}
          
          public IList<Product_Performance> Product_Performances {get;set;} =new List<Product_Performance>(); 
    }
}