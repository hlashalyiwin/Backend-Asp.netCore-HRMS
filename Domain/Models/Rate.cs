//by Than Than Win
using System.Collections.Generic;
using Hr_Management_final_api.Domain.ENumType;
namespace Hr_Management_final_api.Domain.Models
{
    public class Rate
    {
        //column=rateId,Name,rate,type,description
        //primary key=rateId
        public int rateId{get;set;}
        public string Name{get;set;}
        public string rate{get;set;}
        public ERateType type {get;set;}
        public string description{get;set;} 
        public IList<Absence> Absences {get;set;} =new List<Absence>();

        
    }
}