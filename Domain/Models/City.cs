using System.Collections.Generic;
namespace Hr_Management_final_api.Domain.Models
{
    public class City
    {
        public int cityId{get;set;}
        public string Name{get;set;}
        public IList<Township> Township { get; set; } = new List<Township>();
     
    }
}