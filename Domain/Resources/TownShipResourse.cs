using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Domain.Resources
{
    public class TownShipResourse
    {
        public int townshipId{get;set;}
        public string Name{get;set;}
        public int city_Id{get;set;}
        public CityResource city{get;set;}
    }
}