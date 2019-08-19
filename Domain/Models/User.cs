namespace Hr_Management_final_api.Domain.Models
{
    public class User
    {
        public int id{get;set;}
        public string firstName{ get;set;}
        public string lastName{ get;set;}
        public string userName{get;set;}
        public string email{get;set;}
        public string password{get;set;}
       
        public string phone{get;set;}
        public string position{get;set;}
    }
}