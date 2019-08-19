using System.Collections.Generic;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Domain.Resources
{
    //represents a address containing only its name
    public class AddressResource
    {
       public int addId{get;set;}
        public string line_1{get;set;}
        public string line_2{get;set;}
        public int township_Id{get;set;}
        public TownShipResourse Township{get;set;}
     
        public string region{get;set;}
        public string country{get;set;}
    }
}