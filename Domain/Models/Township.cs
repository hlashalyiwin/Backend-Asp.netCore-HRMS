using System.Collections.Generic;

namespace Hr_Management_final_api.Domain.Models
{
    public class Township
    {
        public int townshipId{get;set;}
        public string Name{get;set;}
        public int city_Id{get;set;}
        public City city{get;set;}
        public IList<Address> Address { get; set; } = new List<Address>();
    }
}